namespace SAPR1
{
    // Made by Sergey Kozlov 4-IAIT-3
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createDocumentTreeButton = new System.Windows.Forms.Button();
            this.createTreeOnDiskButton = new System.Windows.Forms.Button();
            this.addObjectButton = new System.Windows.Forms.Button();
            this.removeObjectButton = new System.Windows.Forms.Button();
            this.documentTreeView = new System.Windows.Forms.TreeView();
            this.objectTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.removeDocumentButton = new System.Windows.Forms.Button();
            this.addDocumentButton = new System.Windows.Forms.Button();
            this.useObjectStructureCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // createDocumentTreeButton
            // 
            this.createDocumentTreeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createDocumentTreeButton.Location = new System.Drawing.Point(12, 12);
            this.createDocumentTreeButton.Name = "createDocumentTreeButton";
            this.createDocumentTreeButton.Size = new System.Drawing.Size(152, 91);
            this.createDocumentTreeButton.TabIndex = 0;
            this.createDocumentTreeButton.Text = "Сформировать дерево каталогов в программе по видам документов";
            this.createDocumentTreeButton.UseVisualStyleBackColor = true;
            this.createDocumentTreeButton.Click += new System.EventHandler(this.createTreeButton_Click);
            // 
            // createTreeOnDiskButton
            // 
            this.createTreeOnDiskButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createTreeOnDiskButton.Location = new System.Drawing.Point(12, 107);
            this.createTreeOnDiskButton.Name = "createTreeOnDiskButton";
            this.createTreeOnDiskButton.Size = new System.Drawing.Size(152, 70);
            this.createTreeOnDiskButton.TabIndex = 1;
            this.createTreeOnDiskButton.Text = "Сформировать дерево каталогов на жестком диске";
            this.createTreeOnDiskButton.UseVisualStyleBackColor = true;
            this.createTreeOnDiskButton.Click += new System.EventHandler(this.createTreeOnDiskButton_Click);
            // 
            // addObjectButton
            // 
            this.addObjectButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addObjectButton.Location = new System.Drawing.Point(12, 183);
            this.addObjectButton.Name = "addObjectButton";
            this.addObjectButton.Size = new System.Drawing.Size(152, 70);
            this.addObjectButton.TabIndex = 2;
            this.addObjectButton.Text = "Добавить объект в программе";
            this.addObjectButton.UseVisualStyleBackColor = true;
            this.addObjectButton.Click += new System.EventHandler(this.addObjectButton_Click);
            // 
            // removeObjectButton
            // 
            this.removeObjectButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeObjectButton.Location = new System.Drawing.Point(12, 259);
            this.removeObjectButton.Name = "removeObjectButton";
            this.removeObjectButton.Size = new System.Drawing.Size(152, 70);
            this.removeObjectButton.TabIndex = 3;
            this.removeObjectButton.Text = "Удалить объект в программе";
            this.removeObjectButton.UseVisualStyleBackColor = true;
            this.removeObjectButton.Click += new System.EventHandler(this.removeObjectButton_Click);
            // 
            // documentTreeView
            // 
            this.documentTreeView.Location = new System.Drawing.Point(170, 49);
            this.documentTreeView.Name = "documentTreeView";
            this.documentTreeView.Size = new System.Drawing.Size(300, 692);
            this.documentTreeView.TabIndex = 4;
            // 
            // objectTreeView
            // 
            this.objectTreeView.Location = new System.Drawing.Point(476, 49);
            this.objectTreeView.Name = "objectTreeView";
            this.objectTreeView.Size = new System.Drawing.Size(300, 692);
            this.objectTreeView.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(200, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Структура документов по видам";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(499, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Структура документов по объектам";
            // 
            // removeDocumentButton
            // 
            this.removeDocumentButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeDocumentButton.Location = new System.Drawing.Point(12, 411);
            this.removeDocumentButton.Name = "removeDocumentButton";
            this.removeDocumentButton.Size = new System.Drawing.Size(152, 70);
            this.removeDocumentButton.TabIndex = 9;
            this.removeDocumentButton.Text = "Удалить вид документов в программе";
            this.removeDocumentButton.UseVisualStyleBackColor = true;
            this.removeDocumentButton.Click += new System.EventHandler(this.removeDocumentButton_Click);
            // 
            // addDocumentButton
            // 
            this.addDocumentButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addDocumentButton.Location = new System.Drawing.Point(12, 335);
            this.addDocumentButton.Name = "addDocumentButton";
            this.addDocumentButton.Size = new System.Drawing.Size(152, 70);
            this.addDocumentButton.TabIndex = 8;
            this.addDocumentButton.Text = "Добавить вид документов в программе";
            this.addDocumentButton.UseVisualStyleBackColor = true;
            this.addDocumentButton.Click += new System.EventHandler(this.addDocumentButton_Click);
            // 
            // useObjectStructureCheckBox
            // 
            this.useObjectStructureCheckBox.AutoSize = true;
            this.useObjectStructureCheckBox.Location = new System.Drawing.Point(12, 498);
            this.useObjectStructureCheckBox.Name = "useObjectStructureCheckBox";
            this.useObjectStructureCheckBox.Size = new System.Drawing.Size(141, 64);
            this.useObjectStructureCheckBox.TabIndex = 10;
            this.useObjectStructureCheckBox.Text = "Использование\r\nструктуры\r\nпо объектам\r\n";
            this.useObjectStructureCheckBox.UseVisualStyleBackColor = true;
            this.useObjectStructureCheckBox.CheckedChanged += new System.EventHandler(this.useObjectStructureCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.useObjectStructureCheckBox);
            this.Controls.Add(this.removeDocumentButton);
            this.Controls.Add(this.addDocumentButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.objectTreeView);
            this.Controls.Add(this.documentTreeView);
            this.Controls.Add(this.removeObjectButton);
            this.Controls.Add(this.addObjectButton);
            this.Controls.Add(this.createTreeOnDiskButton);
            this.Controls.Add(this.createDocumentTreeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // Made by Sergey Kozlov 4-IAIT-3
        #endregion

        private Button createDocumentTreeButton;
        private Button createTreeOnDiskButton;
        private Button addObjectButton;
        private Button removeObjectButton;
        private TreeView documentTreeView;
        private TreeView objectTreeView;
        private Label label1;
        private Label label2;
        private Button removeDocumentButton;
        private Button addDocumentButton;
        private CheckBox useObjectStructureCheckBox;
    }
}