namespace Lab_1
{
    partial class MusicCatalog
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
            treeView1 = new TreeView();
            label1 = new Label();
            label2 = new Label();
            treeViewCollections = new TreeView();
            textBoxSearch = new TextBox();
            label3 = new Label();
            buttonSearch = new Button();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 139);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(380, 299);
            treeView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 102);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 2;
            label1.Text = "Список исполнителей";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(456, 108);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 3;
            label2.Text = "Список сборников";
            // 
            // treeViewCollections
            // 
            treeViewCollections.Location = new Point(449, 142);
            treeViewCollections.Name = "treeViewCollections";
            treeViewCollections.Size = new Size(339, 296);
            treeViewCollections.TabIndex = 4;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(12, 40);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(631, 27);
            textBoxSearch.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 6;
            label3.Text = "Строка поиска";
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(677, 38);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 7;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // MusicCatalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSearch);
            Controls.Add(label3);
            Controls.Add(textBoxSearch);
            Controls.Add(treeViewCollections);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(treeView1);
            Name = "MusicCatalog";
            Text = "Music Catalog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Label label1;
        private Label label2;
        private TreeView treeViewCollections;
        private TextBox textBoxSearch;
        private Label label3;
        private Button buttonSearch;
    }
}