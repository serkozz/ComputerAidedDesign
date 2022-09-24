using System.Diagnostics;

namespace SAPR1
{
    public partial class Form1 : Form
    {
        public string TestDir { get; private set; } = @"C:\TEST\";
        public int DocumentRootNodesCount { get; private set; } = 1;
        public int DocumentObjectNodesCount { get; private set; } = 1;
        public int ObjectRootNodesCount { get; private set; } = 1;
        public int ObjectNodesCount { get; private set; } = 1;
        public List<(string, List<string>, Color)> DocumentNodeTupleList { get; private set; } = new List<(string, List<string>, Color)>();

        public Form1()
        {
            InitializeComponent();
            createTreeOnDiskButton.Enabled = false;
            removeObjectButton.Enabled = false;
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
            if (useObjectStructureCheckBox.Checked)
            {
                FillDocumentTuple();
                TreeCreate(TreeViewType.ObjectTreeView);
            }
            else if (!useObjectStructureCheckBox.Checked)
                TreeCreate(TreeViewType.DocumentTreeView);
            createTreeOnDiskButton.Enabled = true;
        }

        private void FillDocumentTuple()
        {
            DocumentNodeTupleList.Add(("ИРД", new List<string>() { "ЗУ", "ГПЗУ", "РС", "ТУ", "ПрДекл"}, Color.Green));
            DocumentNodeTupleList.Add(("ИИ", new List<string>() { "ИГдИ", "ИГлИ", "ИЭИ"}, Color.Blue));
            DocumentNodeTupleList.Add(("ПД", new List<string>() { "ПЗ", "СПОЗУ", "АР", "КР"}, Color.Red));
            DocumentNodeTupleList.Add(("РД", new List<string>() { "ГП", "КЖ"}, Color.Orange));
        }

        private void TreeCreate(TreeViewType treeViewType)
        {
            
            if (treeViewType == TreeViewType.DocumentTreeView)
            {
                TreeClear(TreeViewType.DocumentTreeView);
                AddDocumentRootNode("ИРД", new List<string>() { "ЗУ", "ГПЗУ", "РС", "ТУ", "ПрДекл"}, Color.Green);
                AddDocumentRootNode("ИИ", new List<string>() { "ИГдИ", "ИГлИ", "ИЭИ"}, Color.Blue);
                AddDocumentRootNode("ПД", new List<string>() { "ПЗ", "СПОЗУ", "АР", "КР"}, Color.Red);
                AddDocumentRootNode("РД", new List<string>() { "ГП", "КЖ"}, Color.Orange);
                documentTreeView.ExpandAll();
            }
            else if (treeViewType == TreeViewType.ObjectTreeView)
            {
                TreeClear(TreeViewType.ObjectTreeView);
                AddObjectRootNode($"Объект {ObjectRootNodesCount}", DocumentNodeTupleList);
                objectTreeView.ExpandAll();
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

        private void AddDocumentRootNode(string text, List<string> innerNodesText, Color innerNodesTextColor)
        {
            TreeNode rootNode = new TreeNode($"{DocumentRootNodesCount.ToString()}. {text}");
            TreeNode innerNodesCollection = new TreeNode($"{DocumentRootNodesCount.ToString()}.{DocumentObjectNodesCount.ToString()} Объект {DocumentObjectNodesCount.ToString()}");

            int index = 1; // Номер пункта внутренней ноды 

            foreach (var str in innerNodesText)
            {
                innerNodesCollection.Nodes.Add($"{DocumentRootNodesCount.ToString()}.{DocumentObjectNodesCount.ToString()}.{index} {str}");
                index++;
            }
            ColorNode(innerNodesCollection, innerNodesTextColor);

            rootNode.Nodes.Add(innerNodesCollection);
            documentTreeView.Nodes.Add(rootNode);
            DocumentRootNodesCount++;
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

        private void UpdateClonedDocumentNodeObjectText(TreeNode node, int rootNodeIndex, int objectIndex)
        {
            int nodeIndex = 1;
            foreach (TreeNode innerNode in node.Nodes)
            {
                string[] unUpdatedString = innerNode.Text.Split(' ');
                innerNode.Text = $"{(rootNodeIndex).ToString()}.{objectIndex}.{nodeIndex} {unUpdatedString[1]}";
                nodeIndex++;
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
            if(Directory.Exists(TestDir))
                Directory.Delete(TestDir, true);

            if (useObjectStructureCheckBox.Checked)
                CallRecursive(objectTreeView);
            else
                CallRecursive(documentTreeView);

            MessageBox.Show("Операция успешно выполнена!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addObjectButton_Click(object sender, EventArgs e)
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
                    UpdateClonedDocumentNodeObjectText(clonedNode, updatedRootNodeIndex, DocumentObjectNodesCount);
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
            if (DocumentObjectNodesCount > 1)
            {
                if (DocumentObjectNodesCount == 2) removeObjectButton.Enabled = false;
                int rootNodeIndex = documentTreeView.Nodes.Count - 1;
                foreach (TreeNode node in documentTreeView.Nodes)
                {
                    int nodesCount = documentTreeView.Nodes[node.Level].Nodes.Count;
                    documentTreeView.Nodes[rootNodeIndex].Nodes.RemoveAt(nodesCount-1);
                    rootNodeIndex--;
                }
                DocumentObjectNodesCount--;
            }
        }

        private void addDocumentButton_Click(object sender, EventArgs e)
        {
            DocumentNodeTupleList.Add(("Новый документ", new List<string>() { "Неопределено", "Неизвестно"}, Color.Brown));
            TreeCreate(TreeViewType.ObjectTreeView);
        }

        private void removeDocumentButton_Click(object sender, EventArgs e)
        {
            DocumentNodeTupleList.RemoveAt(DocumentNodeTupleList.Count - 1);
            TreeCreate(TreeViewType.ObjectTreeView);
        }

        private void useObjectStructureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox? cb = sender as CheckBox;

            if (cb != null && cb.Checked)
            {
                addObjectButton.Enabled = true;
                removeObjectButton.Enabled = true;
                addDocumentButton.Enabled = true;
                removeDocumentButton.Enabled = true;
            }
            if (cb != null && !cb.Checked)
            {
                addObjectButton.Enabled = true;
                removeObjectButton.Enabled = true;
                addDocumentButton.Enabled = true;
                removeDocumentButton.Enabled = true;
            }

        }
    }
}