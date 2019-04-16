namespace ionautics
{
    partial class Controller
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.globalPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddAggButton = new System.Windows.Forms.Button();
            this.activeTabs = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.runToggle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.globalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.globalPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1291, 727);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 200);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1291, 827);
            this.tabControl1.TabIndex = 1;
            // 
            // globalPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.globalPanel, 3);
            this.globalPanel.Controls.Add(this.pictureBox1);
            this.globalPanel.Controls.Add(this.AddAggButton);
            this.globalPanel.Controls.Add(this.activeTabs);
            this.globalPanel.Controls.Add(this.button2);
            this.globalPanel.Controls.Add(this.saveButton);
            this.globalPanel.Controls.Add(this.runToggle);
            this.globalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.globalPanel.Location = new System.Drawing.Point(3, 2);
            this.globalPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.globalPanel.Name = "globalPanel";
            this.globalPanel.Size = new System.Drawing.Size(1285, 196);
            this.globalPanel.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ionautics.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(21, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AddAggButton
            // 
            this.AddAggButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddAggButton.Location = new System.Drawing.Point(1083, 134);
            this.AddAggButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddAggButton.Name = "AddAggButton";
            this.AddAggButton.Size = new System.Drawing.Size(181, 45);
            this.AddAggButton.TabIndex = 3;
            this.AddAggButton.Text = "add";
            this.AddAggButton.UseVisualStyleBackColor = true;
            this.AddAggButton.Click += new System.EventHandler(this.AddAggButton_Click);
            // 
            // activeTabs
            // 
            this.activeTabs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.activeTabs.Location = new System.Drawing.Point(355, 103);
            this.activeTabs.Name = "activeTabs";
            this.activeTabs.Size = new System.Drawing.Size(579, 45);
            this.activeTabs.TabIndex = 1;
            this.activeTabs.Text = "label2";
            this.activeTabs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1083, 72);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "load recipe";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(1083, 19);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(181, 45);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "save recipe";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // runToggle
            // 
            this.runToggle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.runToggle.Location = new System.Drawing.Point(584, 36);
            this.runToggle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.runToggle.Name = "runToggle";
            this.runToggle.Size = new System.Drawing.Size(120, 50);
            this.runToggle.TabIndex = 0;
            this.runToggle.Text = "start";
            this.runToggle.UseVisualStyleBackColor = true;
            this.runToggle.Click += new System.EventHandler(this.runToggle_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1291, 727);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1307, 766);
            this.Name = "Controller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hipster Controller";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.globalPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddAggButton;
        private System.Windows.Forms.Button runToggle;
        private System.Windows.Forms.Label activeTabs;
        private System.Windows.Forms.Panel globalPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

