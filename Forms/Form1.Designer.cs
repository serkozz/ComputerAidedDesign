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
            this.documentDataGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_from1 = new System.Windows.Forms.Label();
            this.label_to1 = new System.Windows.Forms.Label();
            this.openSelectedDocButton = new System.Windows.Forms.Button();
            this.barcodeBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.barcodeValueLabel = new System.Windows.Forms.Label();
            this.dropDocsToDBButton = new System.Windows.Forms.Button();
            this.removeSelectedDocButton = new System.Windows.Forms.Button();
            this.downloadDocumentFromDBButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.documentDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBox)).BeginInit();
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
            this.createTreeOnDiskButton.Location = new System.Drawing.Point(12, 109);
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
            this.addObjectButton.Location = new System.Drawing.Point(12, 185);
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
            this.removeObjectButton.Location = new System.Drawing.Point(12, 261);
            this.removeObjectButton.Name = "removeObjectButton";
            this.removeObjectButton.Size = new System.Drawing.Size(152, 70);
            this.removeObjectButton.TabIndex = 3;
            this.removeObjectButton.Text = "Удалить объект в программе";
            this.removeObjectButton.UseVisualStyleBackColor = true;
            this.removeObjectButton.Click += new System.EventHandler(this.removeObjectButton_Click);
            // 
            // documentTreeView
            // 
            this.documentTreeView.HideSelection = false;
            this.documentTreeView.LabelEdit = true;
            this.documentTreeView.Location = new System.Drawing.Point(170, 69);
            this.documentTreeView.Name = "documentTreeView";
            this.documentTreeView.Size = new System.Drawing.Size(300, 672);
            this.documentTreeView.TabIndex = 4;
            // 
            // objectTreeView
            // 
            this.objectTreeView.AllowDrop = true;
            this.objectTreeView.LabelEdit = true;
            this.objectTreeView.Location = new System.Drawing.Point(476, 69);
            this.objectTreeView.Name = "objectTreeView";
            this.objectTreeView.Size = new System.Drawing.Size(300, 672);
            this.objectTreeView.TabIndex = 5;
            this.objectTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.objectTreeView_DragDrop);
            this.objectTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.objectTreeView_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(170, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Структура документов по видам";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(476, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Структура документов по объектам";
            // 
            // removeDocumentButton
            // 
            this.removeDocumentButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeDocumentButton.Location = new System.Drawing.Point(12, 413);
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
            this.addDocumentButton.Location = new System.Drawing.Point(12, 337);
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
            this.useObjectStructureCheckBox.Location = new System.Drawing.Point(12, 495);
            this.useObjectStructureCheckBox.Name = "useObjectStructureCheckBox";
            this.useObjectStructureCheckBox.Size = new System.Drawing.Size(141, 64);
            this.useObjectStructureCheckBox.TabIndex = 10;
            this.useObjectStructureCheckBox.Text = "Использование\r\nструктуры\r\nпо объектам\r\n";
            this.useObjectStructureCheckBox.UseVisualStyleBackColor = true;
            // 
            // documentDataGrid
            // 
            this.documentDataGrid.AllowDrop = true;
            this.documentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentDataGrid.Location = new System.Drawing.Point(782, 69);
            this.documentDataGrid.Name = "documentDataGrid";
            this.documentDataGrid.RowHeadersWidth = 51;
            this.documentDataGrid.RowTemplate.Height = 29;
            this.documentDataGrid.Size = new System.Drawing.Size(788, 596);
            this.documentDataGrid.TabIndex = 11;
            this.documentDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.documentDataGrid_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(782, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "База данных";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(170, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Откуда";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(782, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Куда";
            // 
            // label_from1
            // 
            this.label_from1.AutoSize = true;
            this.label_from1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_from1.Location = new System.Drawing.Point(234, 12);
            this.label_from1.Name = "label_from1";
            this.label_from1.Size = new System.Drawing.Size(23, 18);
            this.label_from1.TabIndex = 17;
            this.label_from1.Text = "...";
            // 
            // label_to1
            // 
            this.label_to1.AutoSize = true;
            this.label_to1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_to1.Location = new System.Drawing.Point(829, 12);
            this.label_to1.Name = "label_to1";
            this.label_to1.Size = new System.Drawing.Size(23, 18);
            this.label_to1.TabIndex = 18;
            this.label_to1.Text = "...";
            // 
            // openSelectedDocButton
            // 
            this.openSelectedDocButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openSelectedDocButton.Location = new System.Drawing.Point(1418, 671);
            this.openSelectedDocButton.Name = "openSelectedDocButton";
            this.openSelectedDocButton.Size = new System.Drawing.Size(152, 70);
            this.openSelectedDocButton.TabIndex = 19;
            this.openSelectedDocButton.Text = "Открыть выбранный документ";
            this.openSelectedDocButton.UseVisualStyleBackColor = true;
            this.openSelectedDocButton.Click += new System.EventHandler(this.openSelectedDocButton_Click);
            // 
            // barcodeBox
            // 
            this.barcodeBox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.barcodeBox.Location = new System.Drawing.Point(1264, 1);
            this.barcodeBox.Name = "barcodeBox";
            this.barcodeBox.Size = new System.Drawing.Size(125, 62);
            this.barcodeBox.TabIndex = 21;
            this.barcodeBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1395, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Значение";
            // 
            // barcodeValueLabel
            // 
            this.barcodeValueLabel.AutoSize = true;
            this.barcodeValueLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.barcodeValueLabel.Location = new System.Drawing.Point(1473, 9);
            this.barcodeValueLabel.Name = "barcodeValueLabel";
            this.barcodeValueLabel.Size = new System.Drawing.Size(23, 18);
            this.barcodeValueLabel.TabIndex = 24;
            this.barcodeValueLabel.Text = "...";
            // 
            // dropDocsToDBButton
            // 
            this.dropDocsToDBButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropDocsToDBButton.Location = new System.Drawing.Point(782, 671);
            this.dropDocsToDBButton.Name = "dropDocsToDBButton";
            this.dropDocsToDBButton.Size = new System.Drawing.Size(152, 70);
            this.dropDocsToDBButton.TabIndex = 25;
            this.dropDocsToDBButton.Text = "Выгрузить документы в БД";
            this.dropDocsToDBButton.UseVisualStyleBackColor = true;
            this.dropDocsToDBButton.Click += new System.EventHandler(this.dropDocumentsToDBButton_Click);
            // 
            // removeSelectedDocButton
            // 
            this.removeSelectedDocButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeSelectedDocButton.Location = new System.Drawing.Point(1260, 671);
            this.removeSelectedDocButton.Name = "removeSelectedDocButton";
            this.removeSelectedDocButton.Size = new System.Drawing.Size(152, 70);
            this.removeSelectedDocButton.TabIndex = 26;
            this.removeSelectedDocButton.Text = "Удалить выбранный документ";
            this.removeSelectedDocButton.UseVisualStyleBackColor = true;
            // 
            // downloadDocumentFromDBButton
            // 
            this.downloadDocumentFromDBButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.downloadDocumentFromDBButton.Location = new System.Drawing.Point(940, 671);
            this.downloadDocumentFromDBButton.Name = "downloadDocumentFromDBButton";
            this.downloadDocumentFromDBButton.Size = new System.Drawing.Size(152, 70);
            this.downloadDocumentFromDBButton.TabIndex = 27;
            this.downloadDocumentFromDBButton.Text = "Загрузить документ из БД";
            this.downloadDocumentFromDBButton.UseVisualStyleBackColor = true;
            this.downloadDocumentFromDBButton.Click += new System.EventHandler(this.downloadDocumentFromDBButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.downloadDocumentFromDBButton);
            this.Controls.Add(this.removeSelectedDocButton);
            this.Controls.Add(this.dropDocsToDBButton);
            this.Controls.Add(this.barcodeValueLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.barcodeBox);
            this.Controls.Add(this.openSelectedDocButton);
            this.Controls.Add(this.label_to1);
            this.Controls.Add(this.label_from1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.documentDataGrid);
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
            ((System.ComponentModel.ISupportInitialize)(this.documentDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBox)).EndInit();
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
        private DataGridView documentDataGrid;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label_from1;
        private Label label_to1;
        private Button openSelectedDocButton;
        private PictureBox barcodeBox;
        private Label label7;
        private Label barcodeValueLabel;
        private Button dropDocsToDBButton;
        private Button removeSelectedDocButton;
        private Button downloadDocumentFromDBButton;
    }
}