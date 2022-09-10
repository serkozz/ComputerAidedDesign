using System.Diagnostics;

namespace SAPR1
{
    public partial class Form1 : Form
    {
        public string TestDir { get; private set; } = @"C:\TEST\";
        public int RootNodesCount { get; private set; } = 1;
        public int ObjectNodesCount { get; private set; } = 1;

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
            TreeCreate();
            createTreeOnDiskButton.Enabled = true;
        }

        private void TreeCreate()
        {
            TreeClear();
            AddRootNode("ИРД", new List<string>() { "ЗУ", "ГПЗУ", "РС", "ТУ", "ПрДекл"}, Color.Green);
            AddRootNode("ИИ", new List<string>() { "ИГдИ", "ИГлИ", "ИЭИ"}, Color.Blue);
            AddRootNode("ПД", new List<string>() { "ПЗ", "СПОЗУ", "АР", "КР"}, Color.Red);
            AddRootNode("РД", new List<string>() { "ГП", "КЖ"}, Color.Orange);
            treeView.ExpandAll();
        }

        private void TreeClear()
        {
            treeView.Nodes.Clear();
            RootNodesCount = 1; ObjectNodesCount = 1;
        }

        private void AddRootNode(string text, List<string> innerNodesText, Color innerNodesTextColor)
        {
            TreeNode rootNode = new TreeNode($"{RootNodesCount.ToString()}. {text}");
            TreeNode innerNodesCollection = new TreeNode($"{RootNodesCount.ToString()}.{ObjectNodesCount.ToString()} Объект {ObjectNodesCount.ToString()}");

            int index = 1; // Номер пункта внутренней ноды 

            foreach (var str in innerNodesText)
            {
                innerNodesCollection.Nodes.Add($"{RootNodesCount.ToString()}.{ObjectNodesCount.ToString()}.{index} {str}");
                index++;
            }
            ColorNode(innerNodesCollection, innerNodesTextColor);

            rootNode.Nodes.Add(innerNodesCollection);
            treeView.Nodes.Add(rootNode);
            RootNodesCount++;
        }

        private void UpdateClonedNodeObjectText(TreeNode node, int rootNodeIndex, int objectIndex)
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
            MessageBox.Show("Операция успешно выполнена!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(Directory.Exists(TestDir))
                Directory.Delete(TestDir, true);

            CallRecursive(treeView);
        }

        private void addObject_Click(object sender, EventArgs e)
        {
            int rootNodeIndex = 0;
            int updatedRootNodeIndex = 0;

            ObjectNodesCount = treeView.Nodes[0].Nodes.Count;
            ObjectNodesCount++;

            foreach (TreeNode node in treeView.Nodes)
            {
                TreeNode? clonedNode = treeView.Nodes[rootNodeIndex].Nodes[treeView.Nodes[rootNodeIndex].Nodes.Count - 1].Clone() as TreeNode;
                
                if (clonedNode != null)
                {
                    clonedNode.Text = $"{(rootNodeIndex + 1).ToString()}.{ObjectNodesCount.ToString()} Объект {ObjectNodesCount.ToString()}";
                    updatedRootNodeIndex = rootNodeIndex + 1;
                    UpdateClonedNodeObjectText(clonedNode, updatedRootNodeIndex, ObjectNodesCount);
                }
                else
                    return;

                treeView.Nodes[rootNodeIndex].Nodes.Add(clonedNode);
                rootNodeIndex++;
            }
            removeObjectButton.Enabled = true;
            treeView.ExpandAll();
        }

        private void removeObject_Click(object sender, EventArgs e)
        {
            if (ObjectNodesCount > 1)
            {
                if (ObjectNodesCount == 2) removeObjectButton.Enabled = false;
                int rootNodeIndex = treeView.Nodes.Count - 1;
                foreach (TreeNode node in treeView.Nodes)
                {
                    int nodesCount = treeView.Nodes[node.Level].Nodes.Count;
                    treeView.Nodes[rootNodeIndex].Nodes.RemoveAt(nodesCount-1);
                    rootNodeIndex--;
                }
                ObjectNodesCount--;
            }
        }
    }
}