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
            FillDocumentTuple();
            createTreeOnDiskButton.Enabled = false;
            addObjectButton.Enabled = false;
            removeObjectButton.Enabled = false;
            addDocumentButton.Enabled = false;
            removeDocumentButton.Enabled = false;
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
                        moreInnerNode.Text = $"{(rootNodeIndex).ToString()}.{nodeIndex}.{innerNodeIndex} {unUpdatedString[1]}";
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
    }
}