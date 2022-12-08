namespace SAPR1.Forms
{
    partial class KPGForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.expandTreeButton = new System.Windows.Forms.Button();
            this.shrinkTreeButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.loadButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.deleteGridViewButton = new System.Windows.Forms.Button();
            this.deletePictureButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 88);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(310, 653);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // expandTreeButton
            // 
            this.expandTreeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expandTreeButton.Location = new System.Drawing.Point(12, 12);
            this.expandTreeButton.Name = "expandTreeButton";
            this.expandTreeButton.Size = new System.Drawing.Size(135, 75);
            this.expandTreeButton.TabIndex = 3;
            this.expandTreeButton.Text = "Расширить";
            this.expandTreeButton.UseVisualStyleBackColor = true;
            this.expandTreeButton.Click += new System.EventHandler(this.expandTreeButton_Click);
            // 
            // shrinkTreeButton
            // 
            this.shrinkTreeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.shrinkTreeButton.Location = new System.Drawing.Point(187, 12);
            this.shrinkTreeButton.Name = "shrinkTreeButton";
            this.shrinkTreeButton.Size = new System.Drawing.Size(135, 75);
            this.shrinkTreeButton.TabIndex = 5;
            this.shrinkTreeButton.Text = "Сузить";
            this.shrinkTreeButton.UseVisualStyleBackColor = true;
            this.shrinkTreeButton.Click += new System.EventHandler(this.shrinkTreeButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(328, 88);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(772, 653);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyUp);
            this.dataGridView.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseWheel);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadButton.Location = new System.Drawing.Point(328, 12);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(135, 75);
            this.loadButton.TabIndex = 7;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playButton.Location = new System.Drawing.Point(469, 12);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(135, 75);
            this.playButton.TabIndex = 8;
            this.playButton.Text = "Запустить";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // deleteGridViewButton
            // 
            this.deleteGridViewButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteGridViewButton.Location = new System.Drawing.Point(610, 12);
            this.deleteGridViewButton.Name = "deleteGridViewButton";
            this.deleteGridViewButton.Size = new System.Drawing.Size(135, 75);
            this.deleteGridViewButton.TabIndex = 9;
            this.deleteGridViewButton.Text = "Очистить";
            this.deleteGridViewButton.UseVisualStyleBackColor = true;
            this.deleteGridViewButton.Click += new System.EventHandler(this.deleteGridViewButton_Click);
            // 
            // deletePictureButton
            // 
            this.deletePictureButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deletePictureButton.Location = new System.Drawing.Point(1106, 12);
            this.deletePictureButton.Name = "deletePictureButton";
            this.deletePictureButton.Size = new System.Drawing.Size(135, 75);
            this.deletePictureButton.TabIndex = 10;
            this.deletePictureButton.Text = "Очистить";
            this.deletePictureButton.UseVisualStyleBackColor = true;
            this.deletePictureButton.Click += new System.EventHandler(this.deletePictureButton_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.Location = new System.Drawing.Point(1270, 56);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(130, 31);
            this.dateLabel.TabIndex = 11;
            this.dateLabel.Text = "03.12.2022";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox.Location = new System.Drawing.Point(1106, 88);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(464, 653);
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            // 
            // KPGForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.deletePictureButton);
            this.Controls.Add(this.deleteGridViewButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.shrinkTreeButton);
            this.Controls.Add(this.expandTreeButton);
            this.Controls.Add(this.treeView);
            this.Name = "KPGForm";
            this.Text = "KPGForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private TreeView treeView;
        private Button expandTreeButton;
        private Button shrinkTreeButton;
        private DataGridView dataGridView;
        private Button loadButton;
        private Button playButton;
        private Button deleteGridViewButton;
        private Button deletePictureButton;
        private Label dateLabel;
        private PictureBox pictureBox;
    }
}