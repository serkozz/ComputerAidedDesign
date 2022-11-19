using System.Data;
using System.Diagnostics;
using System;
using System.Linq;

/// <summary>
/// Lab 4 (Adding barcode into pdf document)
/// </summary>
using BarcodeLib;
using PdfSharp;

namespace SAPR1
{
    public partial class Form1 : Form
    {
        public string TestDir { get; private set; } = @"C:\TEST\";
        public int DocumentRootNodesCount { get; private set; } = 1;
        public int DocumentObjectNodesCount { get; private set; } = 1;
        public int ObjectRootNodesCount { get; private set; } = 1;
        public int ObjectNodesCount { get; private set; } = 1;
        public bool DirectoryOnDiskCreated { get; private set; } = false;
        public List<(string, List<string>, Color)> DocumentNodeTupleList { get; private set; } = new List<(string, List<string>, Color)>();
        public List<Document> DocumentsList { get; private set; } = new List<Document>();
        public Dictionary<Document, Image> DocumentBarcodeDictionary { get; set; } = new Dictionary<Document, Image>();
        public DataSet DataSet { get; private set; } = new DataSet("documents");
        public DataTable DataTable { get; private set; } = new DataTable("documents");
        public bool DataGridCreated { get; private set; }

        public Form1()
        {
            InitializeComponent();
            FillDocumentTuple();
            CreateDataGridView();
            useObjectStructureCheckBox.Checked = true;
            createTreeOnDiskButton.Enabled = false;
            addObjectButton.Enabled = false;
            removeObjectButton.Enabled = false;
            addDocumentButton.Enabled = false;
            removeDocumentButton.Enabled = false;
            openSelectedDocButton.Enabled = false;
        }

        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists) Directory.CreateDirectory(path);
        }

        private void PrintRecursive(TreeNode treeNode)
        {
            Debug.WriteLine(treeNode.Nodes);
            CreateIfMissing(TestDir + treeNode.FullPath);

            foreach (TreeNode node in treeNode.Nodes)
            {
                PrintRecursive(node);
            }
        }

        private void CallRecursive(TreeView treeView)
        {
            TreeNodeCollection nodes = treeView.Nodes;

            foreach (TreeNode node in nodes)
            {
                PrintRecursive(node);
            }
        }

        private void createTreeButton_Click(object sender, EventArgs e)
        {
            TreeCreate(TreeViewType.DocumentTreeView, true);
            createTreeOnDiskButton.Enabled = true;
            addObjectButton.Enabled = true;
            addDocumentButton.Enabled = true;
        }

        private void FillDocumentTuple()
        {
            DocumentNodeTupleList.Add(("ИРД", new List<string>() { "ЗУ", "ГПЗУ", "РС", "ТУ", "ПрДекл"}, Color.Green));
            DocumentNodeTupleList.Add(("ИИ", new List<string>() { "ИГдИ", "ИГлИ", "ИЭИ"}, Color.Blue));
            DocumentNodeTupleList.Add(("ПД", new List<string>() { "ПЗ", "СПОЗУ", "АР", "КР"}, Color.Red));
            DocumentNodeTupleList.Add(("РД", new List<string>() { "ГП", "КЖ"}, Color.Orange));
        }

        private void TreeCreate(TreeViewType treeViewType, bool createBothTrees)
        {
            
            if (treeViewType == TreeViewType.DocumentTreeView || createBothTrees == true)
            {
                TreeClear(TreeViewType.DocumentTreeView);
                AddDocumentRootNode(DocumentNodeTupleList);
                documentTreeView.ExpandAll();
            }
            if (treeViewType == TreeViewType.ObjectTreeView || createBothTrees == true)
            {
                TreeClear(TreeViewType.ObjectTreeView);
                AddObjectRootNode($"Объект {ObjectRootNodesCount}", DocumentNodeTupleList);
                objectTreeView.ExpandAll();
            }
        }

        private void AddDocumentRootNode(List<(string documentNodeText, List<string> innerNodesText, Color innerNodesTextColor)> documentNodeTupleList)
        {
            for (int i = 0; i <= documentNodeTupleList.Count - 1; i++)
            {
                TreeNode rootNode = new TreeNode($"{DocumentRootNodesCount.ToString()}. {documentNodeTupleList[i].documentNodeText}");
                TreeNode innerNodesCollection = new TreeNode($"{DocumentRootNodesCount.ToString()}.{DocumentObjectNodesCount.ToString()} Объект {DocumentObjectNodesCount.ToString()}");

                int innerIndex = 1; // Номер пункта внутренней ноды 

                foreach (var str in documentNodeTupleList[i].innerNodesText)
                {
                    innerNodesCollection.Nodes.Add($"{DocumentRootNodesCount.ToString()}.{DocumentObjectNodesCount.ToString()}.{innerIndex} {str}");
                    innerIndex++;
                }
                ColorNode(innerNodesCollection, documentNodeTupleList[i].innerNodesTextColor);
                rootNode.Nodes.Add(innerNodesCollection);
                DocumentRootNodesCount++;
                documentTreeView.Nodes.Add(rootNode);
            }
        }

        private void TreeClear(TreeViewType treeViewType)
        {
            if (treeViewType == TreeViewType.DocumentTreeView)
            {
                documentTreeView.Nodes.Clear();
                DocumentRootNodesCount = 1; DocumentObjectNodesCount = 1;
            }
            else if (treeViewType == TreeViewType.ObjectTreeView)
            {
                objectTreeView.Nodes.Clear();
                ObjectRootNodesCount = 1; ObjectNodesCount = 1;
            }
        }

        private void AddObjectRootNode(string text, List<(string documentNodeText, List<string> innerNodesText, Color innerNodesTextColor)> documentNodeTupleList)
        {
            TreeNode rootNode = new TreeNode($"{ObjectRootNodesCount.ToString()}. {text}");

            for (int i = 0; i <= documentNodeTupleList.Count - 1; i++)
            {
                TreeNode innerNodesCollection = new TreeNode($"{ObjectRootNodesCount.ToString()}.{ObjectNodesCount.ToString()} {documentNodeTupleList[i].documentNodeText}");

                int innerIndex = 1; // Номер пункта внутренней ноды 

                foreach (var str in documentNodeTupleList[i].innerNodesText)
                {
                    innerNodesCollection.Nodes.Add($"{ObjectRootNodesCount.ToString()}.{ObjectNodesCount.ToString()}.{innerIndex} {str}");
                    innerIndex++;
                }
                ColorNode(innerNodesCollection, documentNodeTupleList[i].innerNodesTextColor);
                rootNode.Nodes.Add(innerNodesCollection);
                ObjectNodesCount++;
            }

            objectTreeView.Nodes.Add(rootNode);
            ObjectRootNodesCount++;
        }

        private void UpdateClonedDocumentNodeObjectText(TreeNode node, int rootNodeIndex, int objectIndex, TreeViewType treeViewType)
        {
            if (treeViewType == TreeViewType.DocumentTreeView)
            {
                int nodeIndex = 1;
                foreach (TreeNode innerNode in node.Nodes)
                {
                    string[] unUpdatedString = innerNode.Text.Split(' ');
                    
                    innerNode.Text = $"{(rootNodeIndex).ToString()}.{objectIndex}.{nodeIndex} {unUpdatedString[1]}";
                    nodeIndex++;
                }
            }
            if (treeViewType == TreeViewType.ObjectTreeView)
            {
                int nodeIndex = 1;

                foreach (TreeNode innerNode in node.Nodes)
                {
                    int innerNodeIndex = 1;
                    string[] unUpdatedString = innerNode.Text.Split(' ');
                    
                    innerNode.Text = $"{(rootNodeIndex).ToString()}.{nodeIndex} {unUpdatedString[1]}";

                    foreach (TreeNode moreInnerNode in innerNode.Nodes)
                    {
                        string[] unUpdatedInnerString = moreInnerNode.Text.Split(' ');
                        moreInnerNode.Text = $"{(rootNodeIndex).ToString()}.{nodeIndex}.{innerNodeIndex} {unUpdatedInnerString[1]}";
                        innerNodeIndex++;
                    }
                    nodeIndex++;
                }
            }
        }

        private void ColorNode(TreeNode treeNode, Color color)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.ForeColor = color;
            }
        }

        private void createTreeOnDiskButton_Click(object sender, EventArgs e)
        {
            CreateTreeOnDisk();
            MessageBox.Show("Операция успешно выполнена!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateTreeOnDisk()
        {
            if (Directory.Exists(TestDir))
                Directory.Delete(TestDir, true);

            if (useObjectStructureCheckBox.Checked)
                CallRecursive(objectTreeView);
            else
                CallRecursive(documentTreeView);

            DirectoryOnDiskCreated = true;
        }

        private void addObjectButton_Click(object sender, EventArgs e)
        {
            DocumentTreeViewAddObject();
            ObjectTreeViewAddObject();
        }

        private void ObjectTreeViewAddObject()
        {
            ObjectRootNodesCount = objectTreeView.Nodes.Count;

            TreeNode? clonedNode = objectTreeView.Nodes[objectTreeView.Nodes.Count - 1].Clone() as TreeNode;
            
            if (clonedNode != null)
            {
                clonedNode.Text = $"{(ObjectRootNodesCount + 1).ToString()}. Объект {DocumentObjectNodesCount.ToString()}";
                UpdateClonedDocumentNodeObjectText(clonedNode, ObjectRootNodesCount + 1, DocumentObjectNodesCount, TreeViewType.ObjectTreeView);
            }
            else
                return;

            ObjectRootNodesCount++;
            objectTreeView.Nodes.Add(clonedNode);
            removeObjectButton.Enabled = true;
            objectTreeView.ExpandAll();
        }

        private void DocumentTreeViewAddObject()
        {
            int rootNodeIndex = 0;
            int updatedRootNodeIndex = 0;

            DocumentObjectNodesCount = documentTreeView.Nodes[0].Nodes.Count;
            DocumentObjectNodesCount++;

            foreach (TreeNode node in documentTreeView.Nodes)
            {
                TreeNode? clonedNode = documentTreeView.Nodes[rootNodeIndex].Nodes[documentTreeView.Nodes[rootNodeIndex].Nodes.Count - 1].Clone() as TreeNode;
                
                if (clonedNode != null)
                {
                    clonedNode.Text = $"{(rootNodeIndex + 1).ToString()}.{DocumentObjectNodesCount.ToString()} Объект {DocumentObjectNodesCount.ToString()}";
                    updatedRootNodeIndex = rootNodeIndex + 1;
                    UpdateClonedDocumentNodeObjectText(clonedNode, updatedRootNodeIndex, DocumentObjectNodesCount, TreeViewType.DocumentTreeView);
                }
                else
                    return;

                documentTreeView.Nodes[rootNodeIndex].Nodes.Add(clonedNode);
                rootNodeIndex++;
            }
            removeObjectButton.Enabled = true;
            documentTreeView.ExpandAll();
        }

        private void removeObjectButton_Click(object sender, EventArgs e)
        {
            if (DocumentObjectNodesCount > 1 && ObjectRootNodesCount > 1)
            {
                if (DocumentObjectNodesCount == 2 || ObjectRootNodesCount == 2) removeObjectButton.Enabled = false;
                int documentTreeLastNodeIndex = documentTreeView.Nodes.Count - 1;
                int objectTreeLastNodeIndex = objectTreeView.Nodes.Count - 1;
                foreach (TreeNode node in documentTreeView.Nodes)
                {
                    int nodesCount = documentTreeView.Nodes[node.Level].Nodes.Count;
                    documentTreeView.Nodes[documentTreeLastNodeIndex].Nodes.RemoveAt(nodesCount-1);
                    documentTreeLastNodeIndex--;
                }
                objectTreeView.Nodes.RemoveAt(objectTreeLastNodeIndex);
                DocumentObjectNodesCount--;
                ObjectRootNodesCount--;
            }
        }

        private void addDocumentButton_Click(object sender, EventArgs e)
        {
            DocumentNodeTupleList.Add(("Новый документ", new List<string>() { "Неопределено", "Неизвестно"}, Color.Brown));
            TreeCreate(TreeViewType.ObjectTreeView, true);
            if (DocumentNodeTupleList.Count > 1)
                removeDocumentButton.Enabled = true;
        }

        private void removeDocumentButton_Click(object sender, EventArgs e)
        {
            if (DocumentNodeTupleList.Count <= 1)
                removeDocumentButton.Enabled = false;
            else
            {
                DocumentNodeTupleList.RemoveAt(DocumentNodeTupleList.Count - 1);
                TreeCreate(TreeViewType.ObjectTreeView, true);
            }
        }

        private void objectTreeView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                TreeView? senderTreeView = sender as TreeView;
                string relativePath = string.Empty;

                if (senderTreeView is not null)
                {
                    relativePath = senderTreeView.SelectedNode.FullPath;
                    label_to1.Text = relativePath;                
                }
                
                string currentNum = (DocumentsList.Count + 1).ToString().PadLeft(4, '0');
                string fullPath = TestDir + relativePath + @"\#" + currentNum + ".pdf";

                Document createdDocument = new Document("#" + currentNum, fullPath);
                DocumentsList.Add(createdDocument);
                Barcoder barcoder = new Barcoder(fullPath, currentNum, barcodeBox);
                barcodeValueLabel.Text = currentNum;

                UpdateDocumentDataGridView();

                if (DirectoryOnDiskCreated)
                {
                    File.Copy(label_from1.Text, fullPath, true);
                    barcoder.BarcodeDocument();
                    DocumentBarcodeDictionary.Add(createdDocument, barcoder.BarcodeImage);
                }   
                else
                {
                    CreateTreeOnDisk();
                    File.Copy(label_from1.Text, fullPath, true);
                    barcoder.BarcodeDocument();
                    DocumentBarcodeDictionary.Add(createdDocument, barcoder.BarcodeImage);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Вызвано исключение: " + ex.Message, "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Возникает при перетаскивании документа на ObjectTreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void objectTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (e.Data.GetDataPresent(DataFormats.FileDrop) && Path.GetExtension(files[0]) == ".pdf" && label_to1.Text != "")
                {
                    e.Effect = DragDropEffects.All;
                    label_from1.Text = files[0];
                }
                else e.Effect = DragDropEffects.None;
            }
        }

        private void CreateDataGridView()
        {
            DataGridCreated = true;
            DataSet.Tables.Clear();
            DataSet.Tables.Add(DataTable);

            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null

            DataColumn documentName = new DataColumn("Имя", Type.GetType("System.String"));
            DataColumn documentCreationTime = new DataColumn("Дата_добавления", Type.GetType("System.DateTime"));
            DataColumn documentFullPath = new DataColumn("Полный_путь", Type.GetType("System.String"));

            DataTable.Columns.Add(idColumn);
            DataTable.Columns.Add(documentName);
            DataTable.Columns.Add(documentCreationTime);
            DataTable.Columns.Add(documentFullPath);

            // определяем первичный ключ таблицы
            DataTable.PrimaryKey = new DataColumn[] { DataTable.Columns["Id"] };

            documentDataGrid.DataSource = DataSet.Tables["documents"];
            documentDataGrid.Sort(documentDataGrid.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
            
            documentDataGrid.Columns[0].Width = 35;
            documentDataGrid.Columns[1].Width = 100;
            documentDataGrid.Columns[2].Width = 140;
            documentDataGrid.Columns[3].Width = 460;
        }

        private void UpdateDocumentDataGridView()
        {
            DataTable.Clear();
            int id = 0;

            foreach (Document doc in DocumentsList)
            {
                DataTable.Rows.Add(id, doc.Name, doc.CreationTime, doc.FullPath);
                id++;
            }
        }

        private void openSelectedDocButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selected = documentDataGrid.SelectedRows;
                Document? SelectedDoc = null;
                if (selected[0].Cells[1].Value != null)
                {
                    SelectedDoc = DocumentsList.Find(x => x.Name == selected[0].Cells[1].Value.ToString());
                    Process.Start( new ProcessStartInfo { FileName = SelectedDoc.FullPath, UseShellExecute = true } );
                }
                else
                    MessageBox.Show("Не выбран документ для открытия!!!", "Внимание!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Возникло исключение!!!" + ex.Message, "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void documentDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
                openSelectedDocButton.Enabled = false;
            else
            {
                openSelectedDocButton.Enabled = true;
                Document? selectedDocument = FindDocumentByCellIndex(e);

                if (selectedDocument is not null)
                {
                    ChangeBarcodeValue(selectedDocument);
                    ChangeBarcodeImage(selectedDocument);
                }
            }
        }

        /// <summary>
        /// Возвращает документ находящийся в ячейке таблицы
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Document? FindDocumentByCellIndex(DataGridViewCellEventArgs e)
        {
            try
            {
            /// Вообще, это немного странная реализация, можно подумать тут
            string? selectedDocFullPath = documentDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
            string selectedDocName = documentDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            DateTime selectedDocCreationTime = (DateTime)documentDataGrid.Rows[e.RowIndex].Cells[2].Value;

            return DocumentsList.Find(doc => doc.FullPath == selectedDocFullPath
                                        && doc.Name == selectedDocName
                                        && doc.CreationTime == selectedDocCreationTime);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Document? FindDocumentByCellIndex()
        {
            string? selectedDocFullPath = documentDataGrid.SelectedRows[0].Cells[3].Value.ToString();
            string? selectedDocName = documentDataGrid.SelectedRows[0].Cells[1].Value.ToString();
            DateTime selectedDocCreationTime = (DateTime)documentDataGrid.SelectedRows[0].Cells[2].Value;

            return DocumentsList.Find(doc => doc.FullPath == selectedDocFullPath
                                        && doc.Name == selectedDocName
                                        && doc.CreationTime == selectedDocCreationTime);
        }

        /// <summary>
        /// При выборе документа устанавливает значение штрихеода в поле значения
        /// </summary>
        private void ChangeBarcodeValue(Document selectedDocument)
        {
            barcodeValueLabel.Text = selectedDocument.Name.Replace("#", string.Empty);
        }

        /// <summary>
        /// При выборе документа устанавливает его штрихкод в поле для проверки значения
        /// </summary>
        private void ChangeBarcodeImage(Document selectedDocument)
        {
            barcodeBox.Image = DocumentBarcodeDictionary.First(doc => doc.Key == selectedDocument).Value;
        }

        private void dropDocumentsToDBButton_Click(object sender, EventArgs e)
        {
            DatabaseProcessor dbProcessor = new DatabaseProcessor();

            foreach (Document document in DocumentsList)
            {
                dbProcessor.AddDocumentsDataToDB(document);
            }

            MessageBox.Show("Документы успешно добавлены в базу данных", "Успех!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void downloadDocumentFromDBButton_Click(object sender, EventArgs e)
        {
            DatabaseProcessor dbProcessor = new DatabaseProcessor();
            Document selectedDocument = FindDocumentByCellIndex();

            if (selectedDocument is null)
            {
                MessageBox.Show("Выберите документ для загрузки из базы данных!!!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string filePath = @"C:\Users\Сергей\Desktop\document.pdf";
            dbProcessor.GetDocumentPDFFromDB(selectedDocument.FullPath, filePath);
            Process.Start( new ProcessStartInfo { FileName = filePath, UseShellExecute = true } );
        }
    }
}