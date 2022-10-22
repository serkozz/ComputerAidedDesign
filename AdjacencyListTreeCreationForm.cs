using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPR1
{
    public partial class AdjacencyListTreeCreationForm : Form
    {
        public Form MainForm { get; }
        public TreeView TreeView { get; private set; } = new TreeView();
        public DataSet DataSet { get; private set; } = new DataSet("dataset");
        public DataTable DataTable { get; private set; } = new DataTable("datatable");
        public List<(int, int, string)> DataGridItemsList { get; private set; } = new List<(int, int, string)>();

        public AdjacencyListTreeCreationForm(Form1 mainForm)
        {
            MainForm = mainForm;
            InitializeComponent();
            CreateDataGrid();
        }

        private void CreateDataGrid()
        {
            DataSet.Tables.Clear();
            DataSet.Tables.Add(DataTable);

            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null

            DataColumn parentColumn = new DataColumn("Родитель", Type.GetType("System.Int32"));
            DataColumn textColumn = new DataColumn("Текст", Type.GetType("System.String"));

            DataTable.Columns.Add(idColumn);
            DataTable.Columns.Add(parentColumn);
            DataTable.Columns.Add(textColumn);


            // определяем первичный ключ таблицы
            DataTable.PrimaryKey = new DataColumn[] { DataTable.Columns["Id"] };

            adjacencyListGridView.DataSource = DataSet.Tables["documents"];
            adjacencyListGridView.Sort(adjacencyListGridView.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
            
            adjacencyListGridView.Columns[0].Width = 35;
            adjacencyListGridView.Columns[1].Width = 50;
            adjacencyListGridView.Columns[2].Width = 75;
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            (int, int, string) DataGridItem = (DataTable.Rows.Count, DataTable.Rows.Count, "E");
            DataGridItemsList.Add(DataGridItem);
            DataTable.Rows.Add(null, DataGridItem.Item2, DataGridItem.Item3);
        }

        private void createTreeButton_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();

            foreach (var DataGridItem in DataGridItemsList)
            {
                
            }
        }
    }
}
