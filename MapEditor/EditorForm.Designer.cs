
namespace MapEditor
{
    partial class EditorForm
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
            this.MapPanel = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.CategoryLb = new System.Windows.Forms.Label();
            this.EraseCheck = new System.Windows.Forms.CheckBox();
            this.ReplaceCheck = new System.Windows.Forms.CheckBox();
            this.FillBtn = new System.Windows.Forms.Button();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapPanel
            // 
            this.MapPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(173)))), ((int)(((byte)(145)))));
            this.MapPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MapPanel.Location = new System.Drawing.Point(9, 90);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(512, 512);
            this.MapPanel.TabIndex = 0;
            this.MapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPanel_MouseMove);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(144)))), ((int)(((byte)(138)))));
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBtn.Location = new System.Drawing.Point(404, 57);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(115, 27);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(173)))), ((int)(((byte)(145)))));
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearBtn.Location = new System.Drawing.Point(245, 58);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(72, 24);
            this.ClearBtn.TabIndex = 1;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // CategoryBox
            // 
            this.CategoryBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CategoryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Items.AddRange(new object[] {
            "Grass",
            "Dirt",
            "Rock",
            "Tree",
            "Sand",
            "Water"});
            this.CategoryBox.Location = new System.Drawing.Point(9, 27);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(228, 24);
            this.CategoryBox.TabIndex = 2;
            // 
            // CategoryLb
            // 
            this.CategoryLb.AutoSize = true;
            this.CategoryLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryLb.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CategoryLb.Location = new System.Drawing.Point(6, 8);
            this.CategoryLb.Name = "CategoryLb";
            this.CategoryLb.Size = new System.Drawing.Size(71, 16);
            this.CategoryLb.TabIndex = 3;
            this.CategoryLb.Text = "Category";
            // 
            // EraseCheck
            // 
            this.EraseCheck.AutoSize = true;
            this.EraseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EraseCheck.Location = new System.Drawing.Point(12, 64);
            this.EraseCheck.Name = "EraseCheck";
            this.EraseCheck.Size = new System.Drawing.Size(63, 20);
            this.EraseCheck.TabIndex = 4;
            this.EraseCheck.Text = "Erase";
            this.EraseCheck.UseVisualStyleBackColor = true;
            this.EraseCheck.CheckedChanged += new System.EventHandler(this.EraseCheck_CheckedChanged);
            this.EraseCheck.Click += new System.EventHandler(this.EraseCheck_Click);
            // 
            // ReplaceCheck
            // 
            this.ReplaceCheck.AutoSize = true;
            this.ReplaceCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReplaceCheck.Location = new System.Drawing.Point(158, 64);
            this.ReplaceCheck.Name = "ReplaceCheck";
            this.ReplaceCheck.Size = new System.Drawing.Size(79, 20);
            this.ReplaceCheck.TabIndex = 5;
            this.ReplaceCheck.Text = "Replace";
            this.ReplaceCheck.UseVisualStyleBackColor = true;
            this.ReplaceCheck.CheckedChanged += new System.EventHandler(this.ReplaceCheck_CheckedChanged);
            this.ReplaceCheck.Click += new System.EventHandler(this.ReplaceCheck_Click);
            // 
            // FillBtn
            // 
            this.FillBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(173)))), ((int)(((byte)(145)))));
            this.FillBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FillBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FillBtn.Location = new System.Drawing.Point(245, 28);
            this.FillBtn.Name = "FillBtn";
            this.FillBtn.Size = new System.Drawing.Size(72, 24);
            this.FillBtn.TabIndex = 6;
            this.FillBtn.Text = "Fill";
            this.FillBtn.UseVisualStyleBackColor = false;
            this.FillBtn.Click += new System.EventHandler(this.FillBtn_Click);
            // 
            // OpenBtn
            // 
            this.OpenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(144)))), ((int)(((byte)(138)))));
            this.OpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenBtn.Location = new System.Drawing.Point(404, 24);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(115, 27);
            this.OpenBtn.TabIndex = 7;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = false;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(151)))), ((int)(((byte)(136)))));
            this.ClientSize = new System.Drawing.Size(531, 611);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.FillBtn);
            this.Controls.Add(this.ReplaceCheck);
            this.Controls.Add(this.EraseCheck);
            this.Controls.Add(this.CategoryLb);
            this.Controls.Add(this.CategoryBox);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.MapPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.Label CategoryLb;
        private System.Windows.Forms.CheckBox EraseCheck;
        private System.Windows.Forms.CheckBox ReplaceCheck;
        private System.Windows.Forms.Button FillBtn;
        private System.Windows.Forms.Button OpenBtn;
    }
}

