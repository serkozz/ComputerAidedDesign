using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;
using SAPR1.Forms;
using SAPR1.Types;
using QuickChart;

namespace SAPR1.Forms
{
    public partial class KPGForm : Form
    {
        public MainForm MainForm { get; private set; }
        public SvgDocument svgDocument { get; private set; }
        public string SelectedPath { get; private set; }

        private DataSet DataSet = new DataSet("dataset");
        private DataTable DataTable = new DataTable("datatable");

        private int w = 0; // Щелчки колесика мыши
        private Color NotRun = Color.FromArgb(0xF5, 0xB2, 0xB6);
        private Color execColor = Color.LimeGreen;
        private Color partColor = Color.Gold;
        private DateTime startDate = DateTime.Now;
        private string SVGName; // Имя svg элемента
        private SvgElement SVGItem; // Обозначенный элемент в svg файле
        private int duration = 2;

        public KPGForm(MainForm mainForm)
        {
            InitializeComponent();
            CreateDataGridView();
            CreateTreeView();
            SetDataGridValue();
            CreateCharts();
            MainForm = mainForm;
            LoadSvg();
            treeView.ExpandAll();
            dateLabel.Text = DateTime.Now.ToString();
            dateLabel.ForeColor = Color.Gray;
            dataGridView.MouseWheel += dataGridView_MouseWheel;
            this.FormClosed += formClosed;
        }

        private void formClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CreateDataGridView()
        {
            DataSet.Tables.Clear();
            DataSet.Tables.Add(DataTable);

            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null

            DataColumn nameColumn = new DataColumn("Имя", Type.GetType("System.String"));
            DataColumn finishTimeColumn = new DataColumn("Дата завершения", Type.GetType("System.String"));
            DataColumn partialColumn = new DataColumn("Частично", Type.GetType("System.String"));
            DataColumn daysColumn = new DataColumn("Дни", Type.GetType("System.String"));
            DataColumn priceColumn = new DataColumn("Затраты (тыс.руб)");

            DataTable.Columns.Add(idColumn);
            DataTable.Columns.Add(nameColumn);
            DataTable.Columns.Add(finishTimeColumn);
            DataTable.Columns.Add(partialColumn);
            DataTable.Columns.Add(daysColumn);
            DataTable.Columns.Add(priceColumn);

            // определяем первичный ключ таблицы
            DataTable.PrimaryKey = new DataColumn[] { DataTable.Columns["Id"] };

            dataGridView.DataSource = DataSet.Tables["datatable"];
            dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);

            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
        }

        private void CreateTreeView()
        {
            TreeNode overlapNode = new TreeNode("Перекрытие",
                new TreeNode[] { new TreeNode("1.1"),
                new TreeNode("1.2"), new TreeNode("1.3"),
                new TreeNode("1.4"), new TreeNode("1.5"),
                new TreeNode("1.6"),});
            TreeNode razuklonkaNode = new TreeNode("Разуклонка",
                new TreeNode[] { new TreeNode("2.1"),
                new TreeNode("2.2"), new TreeNode("2.3"),
                new TreeNode("2.4"), new TreeNode("2.5"),
                new TreeNode("2.6"),});
            TreeNode buckleNode = new TreeNode("Стяжка",
                new TreeNode[] { new TreeNode("3.1"),
                new TreeNode("3.2"), new TreeNode("3.3"),
                new TreeNode("3.4"), new TreeNode("3.5"),
                new TreeNode("3.6"),});
            TreeNode waterproofingNode = new TreeNode("Гидроизоляция",
                new TreeNode[] { new TreeNode("4.1"),
                new TreeNode("4.2"), new TreeNode("4.3"),
                new TreeNode("4.4"), new TreeNode("4.5"),
                new TreeNode("4.6"),});
            TreeNode plateNode = new TreeNode("Плита/Грунт",
                new TreeNode[] { new TreeNode("5.1"),
                new TreeNode("5.2"), new TreeNode("5.3"),
                new TreeNode("5.4",
                new TreeNode[] { new TreeNode("5.4.1"),
                new TreeNode("5.4.2")}),
                new TreeNode("5.5",
                new TreeNode[] { new TreeNode("5.5.1"),
                new TreeNode("5.5.2")}),
                new TreeNode("5.6",
                new TreeNode[] { new TreeNode("5.6.1"),
                new TreeNode("5.6.2")}),});
            TreeNode asphaltNode = new TreeNode("Асфальт/МАФ",
                new TreeNode[] { new TreeNode("6.1"),
                new TreeNode("6.2"), new TreeNode("6.3"),
                new TreeNode("6.4",
                new TreeNode[] { new TreeNode("6.4.1"),
                new TreeNode("6.4.2")}),
                new TreeNode("6.5",
                new TreeNode[] { new TreeNode("6.5.1"),
                new TreeNode("6.5.2")}),
                new TreeNode("6.6",
                new TreeNode[] { new TreeNode("6.6.1"),
                new TreeNode("6.6.2")}),});

            treeView.Nodes.Add(overlapNode);
            treeView.Nodes.Add(razuklonkaNode);
            treeView.Nodes.Add(buckleNode);
            treeView.Nodes.Add(waterproofingNode);
            treeView.Nodes.Add(plateNode);
            treeView.Nodes.Add(asphaltNode);
        }

        // TODO: Вынести чартокрейтер в новый класс !!!!!
        private void CreateCharts()
        {
            CreateFundingChart();
            CreateCumulativeSumChart();
            CreateFinancingLimitChart();
        }

        private void ClearCharts()
        {
            fundingChartPictureBox.Image = null;
            cumulativeSumChartPictureBox.Image = null;
            financingLimitChartPictureBox.Image = null;
        }

        private void CreateFinancingLimitChart()
        {
            string dataString = string.Empty;
            string labelsList = string.Empty;
            int financingLimit = 100000;

            foreach (DataRow row in DataTable.Rows)
            {
                financingLimit -= int.Parse(row.ItemArray[5].ToString());
                dataString += $"{financingLimit.ToString()}, ";
                labelsList += $"{row.ItemArray[0].ToString()}, ";
            }

            Chart fundingChart = new Chart();
            fundingChart.Width = 500;
            fundingChart.Height = 300;
            fundingChart.Config = $@"{{
            type: 'bar',
            data: {{
                labels: [{labelsList}],
                datasets: [{{
                label: 'Лимит финансирования (тыс. руб)',
                data: [{dataString}]
                }}]
            }}
            }}";
            Console.WriteLine(fundingChart.GetUrl());
            byte[] imageBytes = fundingChart.ToByteArray();

            MemoryStream ms = new MemoryStream(imageBytes);
            financingLimitChartPictureBox.Image = Image.FromStream(ms);
            ms.Close();
        }

        private void CreateCumulativeSumChart()
        {
            string dataString = string.Empty;
            string labelsList = string.Empty;
            int cumulativeSum = 0;

            foreach (DataRow row in DataTable.Rows)
            {
                cumulativeSum += int.Parse(row.ItemArray[5].ToString());
                dataString += $"{cumulativeSum.ToString()}, ";
                labelsList += $"{row.ItemArray[0].ToString()}, ";
            }

            Chart fundingChart = new Chart();
            fundingChart.Width = 500;
            fundingChart.Height = 300;
            fundingChart.Config = $@"{{
            type: 'bar',
            data: {{
                labels: [{labelsList}],
                datasets: [{{
                label: 'Сумма нарастающим итогом (кумулятивная сумма) (тыс. руб)',
                data: [{dataString}]
                }}]
            }}
            }}";
            Console.WriteLine(fundingChart.GetUrl());
            byte[] imageBytes = fundingChart.ToByteArray();

            MemoryStream ms = new MemoryStream(imageBytes);
            cumulativeSumChartPictureBox.Image = Image.FromStream(ms);
            ms.Close();
        }
        private void CreateFundingChart()
        {
            string dataString = string.Empty;
            string labelsList = string.Empty;

            foreach (DataRow row in DataTable.Rows)
            {
                dataString += $"{row.ItemArray[5].ToString()}, ";
                labelsList += $"{row.ItemArray[0].ToString()}, ";
            }

            Chart fundingChart = new Chart();
            fundingChart.Width = 500;
            fundingChart.Height = 300;
            fundingChart.Config = $@"{{
            type: 'bar',
            data: {{
                labels: [{labelsList}],
                datasets: [{{
                label: 'График финансирования (тыс. руб)',
                data: [{dataString}]
                }}]
            }}
            }}";
            Console.WriteLine(fundingChart.GetUrl());
            byte[] imageBytes = fundingChart.ToByteArray();

            MemoryStream ms = new MemoryStream(imageBytes);
            fundingChartPictureBox.Image = Image.FromStream(ms);
            ms.Close();
        }

        private void SetDataGridValue()
        {
            DataTable.Rows.Add("1", "_1.6", "03.12.2022", "", duration, Random.Shared.Next(0, 10000));
            DataTable.Rows.Add("2", "_1.4", "05.12.2022", "", duration, Random.Shared.Next(0, 10000));
            DataTable.Rows.Add("3", "_1.5", "08.12.2022", "", duration, Random.Shared.Next(0, 10000));
        }

        private void LoadSvg()
        {
            SvgParser.MaximumSize = new Size(pictureBox.Width, pictureBox.Height);
            SelectedPath = @"C:\Repositories\SAPR1\img\Пирог SVG num.svg";
            svgDocument = SvgParser.GetSvgDocument(SelectedPath);
            pictureBox.Image = SvgParser.GetBitmapFromSVG(SelectedPath);
        }

        private void FillCurrentElement(int i)
        {
            if (i == dataGridView.Rows.Count - 1) return;

            SVGName = dataGridView.Rows[i].Cells[1].Value.ToString();
            SVGItem = svgDocument.GetElementById(SVGName);
            if (dataGridView.Rows[i].Cells[3].Value.ToString() != "Да")
                SVGItem.Fill = new SvgColourServer(execColor);
            else
                SVGItem.Fill = new SvgColourServer(partColor);
            pictureBox.Image = svgDocument.Draw();
            dateLabel.Text = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FillCurrentElement(dataGridView.CurrentCell.RowIndex);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            playButton.Enabled = true;
            SVGName = "_" + e.Node.Text;
            SVGItem = svgDocument.GetElementById(SVGName);
            if (e.Node.FirstNode == null)
            {
                SVGItem.Fill = new SvgColourServer(execColor);
                pictureBox.Image = svgDocument.Draw();
                startDate = startDate.AddDays(1);
                DataTable.Rows.Add((dataGridView.Rows.Count + 1).ToString(), SVGName, startDate.ToString("dd-MM-yyyy"), "", ((byte)duration), Random.Shared.Next(0, 10000));
            }
        }

        private void dataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                FillCurrentElement(dataGridView.CurrentCell.RowIndex);

            if (e.KeyCode == Keys.Up)
            {
                SVGName = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[1].Value.ToString();
                SVGItem = svgDocument.GetElementById(SVGName);
                SVGItem.Fill = new SvgColourServer(NotRun);
                pictureBox.Image = svgDocument.Draw();
                dateLabel.Text = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void WaitMSeconds(int mSeconds)
        {
            if (mSeconds < 1) return;
            DateTime desired = DateTime.Now.AddMilliseconds(mSeconds);
            while (DateTime.Now < desired)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
        }

        private void expandTreeButton_Click(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        private void shrinkTreeButton_Click(object sender, EventArgs e)
        {
            treeView.CollapseAll();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            DataTable.Rows.Clear();
            LoadSvg();
            SetDataGridValue();
            dataGridView.Focus();
            playButton.Enabled = true;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            int wDays = 0;
            LoadSvg();
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                wDays = int.Parse(dataGridView.Rows[i].Cells[4].Value.ToString());
                WaitMSeconds(wDays * 10);
                {
                    dataGridView.ClearSelection();
                    FillCurrentElement(i);
                    dataGridView.Rows[i].Selected = true;
                    dateLabel.Text = dataGridView.Rows[i].Cells[2].Value.ToString();
                }
            }
            dataGridView.Rows[dataGridView.Rows.Count - 1].Selected = false;
            CreateCharts();
        }

        private void deleteGridViewButton_Click(object sender, EventArgs e)
        {
            DataTable.Rows.Clear();
            CreateCharts();
            LoadSvg();
            playButton.Enabled = false;
        }

        private void deletePictureButton_Click(object sender, EventArgs e)
        {
            LoadSvg();
        }

        private void dataGridView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0
                || dataGridView.CurrentCell.RowIndex == dataGridView.Rows.Count - 1) return;
            w = int.Parse(dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[4].Value.ToString());
            if (e.Delta == 120) w++;
            else if (w > 1) w--;
            dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[4].Value = w.ToString();
        }
    }
}
