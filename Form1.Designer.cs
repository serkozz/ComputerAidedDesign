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
            this.createTreeButton = new System.Windows.Forms.Button();
            this.createTreeOnDiskButton = new System.Windows.Forms.Button();
            this.addObject = new System.Windows.Forms.Button();
            this.removeObjectButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // createTreeButton
            // 
            this.createTreeButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createTreeButton.Location = new System.Drawing.Point(12, 12);
            this.createTreeButton.Name = "createTreeButton";
            this.createTreeButton.Size = new System.Drawing.Size(152, 70);
            this.createTreeButton.TabIndex = 0;
            this.createTreeButton.Text = "Сформировать дерево каталогов в программе";
            this.createTreeButton.UseVisualStyleBackColor = true;
            this.createTreeButton.Click += new System.EventHandler(this.createTreeButton_Click);
            // 
            // createTreeOnDiskButton
            // 
            this.createTreeOnDiskButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createTreeOnDiskButton.Location = new System.Drawing.Point(12, 88);
            this.createTreeOnDiskButton.Name = "createTreeOnDiskButton";
            this.createTreeOnDiskButton.Size = new System.Drawing.Size(152, 70);
            this.createTreeOnDiskButton.TabIndex = 1;
            this.createTreeOnDiskButton.Text = "Сформировать дерево каталогов на жестком диске";
            this.createTreeOnDiskButton.UseVisualStyleBackColor = true;
            this.createTreeOnDiskButton.Click += new System.EventHandler(this.createTreeOnDiskButton_Click);
            // 
            // addObject
            // 
            this.addObject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addObject.Location = new System.Drawing.Point(12, 164);
            this.addObject.Name = "addObject";
            this.addObject.Size = new System.Drawing.Size(152, 70);
            this.addObject.TabIndex = 2;
            this.addObject.Text = "Добавить объект в программе";
            this.addObject.UseVisualStyleBackColor = true;
            this.addObject.Click += new System.EventHandler(this.addObject_Click);
            // 
            // removeObjectButton
            // 
            this.removeObjectButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeObjectButton.Location = new System.Drawing.Point(12, 240);
            this.removeObjectButton.Name = "removeObject";
            this.removeObjectButton.Size = new System.Drawing.Size(152, 70);
            this.removeObjectButton.TabIndex = 3;
            this.removeObjectButton.Text = "Удалить объект в программе";
            this.removeObjectButton.UseVisualStyleBackColor = true;
            this.removeObjectButton.Click += new System.EventHandler(this.removeObject_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(170, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(600, 729);
            this.treeView.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.removeObjectButton);
            this.Controls.Add(this.addObject);
            this.Controls.Add(this.createTreeOnDiskButton);
            this.Controls.Add(this.createTreeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        // Made by Sergey Kozlov 4-IAIT-3
        #endregion

        private Button createTreeButton;
        private Button createTreeOnDiskButton;
        private Button addObject;
        private Button removeObjectButton;
        private TreeView treeView;
    }
}