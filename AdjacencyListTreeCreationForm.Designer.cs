namespace SAPR1
{
    partial class AdjacencyListTreeCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.adjacencyListGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.addRecordButton = new System.Windows.Forms.Button();
            this.createTreeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // adjacencyListGridView
            // 
            this.adjacencyListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adjacencyListGridView.Location = new System.Drawing.Point(12, 47);
            this.adjacencyListGridView.Name = "adjacencyListGridView";
            this.adjacencyListGridView.RowHeadersWidth = 51;
            this.adjacencyListGridView.RowTemplate.Height = 29;
            this.adjacencyListGridView.Size = new System.Drawing.Size(363, 419);
            this.adjacencyListGridView.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Матрица смежности";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(381, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Матрица смежности";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(381, 47);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(389, 419);
            this.treeView.TabIndex = 16;
            // 
            // addRecordButton
            // 
            this.addRecordButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addRecordButton.Location = new System.Drawing.Point(12, 472);
            this.addRecordButton.Name = "addRecordButton";
            this.addRecordButton.Size = new System.Drawing.Size(363, 69);
            this.addRecordButton.TabIndex = 17;
            this.addRecordButton.Text = "Добавить запись в матрицу смежности";
            this.addRecordButton.UseVisualStyleBackColor = true;
            this.addRecordButton.Click += new System.EventHandler(this.addRecordButton_Click);
            // 
            // createTreeButton
            // 
            this.createTreeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createTreeButton.Location = new System.Drawing.Point(381, 472);
            this.createTreeButton.Name = "createTreeButton";
            this.createTreeButton.Size = new System.Drawing.Size(389, 69);
            this.createTreeButton.TabIndex = 18;
            this.createTreeButton.Text = "Сформировать дерево каталогов используя матрицу смежности";
            this.createTreeButton.UseVisualStyleBackColor = true;
            this.createTreeButton.Click += new System.EventHandler(this.createTreeButton_Click);
            // 
            // AdjacencyListTreeCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.createTreeButton);
            this.Controls.Add(this.addRecordButton);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.adjacencyListGridView);
            this.Name = "AdjacencyListTreeCreationForm";
            this.Text = "AdjacencyListTreeCreationForm";
            ((System.ComponentModel.ISupportInitialize)(this.adjacencyListGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView adjacencyListGridView;
        private Label label4;
        private Label label1;
        private TreeView treeView;
        private Button addRecordButton;
        private Button createTreeButton;
    }
}