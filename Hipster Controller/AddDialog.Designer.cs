namespace ionautics
{
    partial class AddDialog
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
            this.components = new System.ComponentModel.Container();
            this.OkButton = new System.Windows.Forms.Button();
            this.portNameBox = new System.Windows.Forms.ComboBox();
            this.TabName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioSync = new System.Windows.Forms.RadioButton();
            this.radioHipster = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addressNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bpsBox = new System.Windows.Forms.ComboBox();
            this.addDialogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addDialogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(570, 504);
            this.OkButton.Margin = new System.Windows.Forms.Padding(20);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(120, 46);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // portNameBox
            // 
            this.portNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portNameBox.FormattingEnabled = true;
            this.portNameBox.Location = new System.Drawing.Point(241, 159);
            this.portNameBox.Name = "portNameBox";
            this.portNameBox.Size = new System.Drawing.Size(350, 39);
            this.portNameBox.Sorted = true;
            this.portNameBox.TabIndex = 2;
            // 
            // TabName
            // 
            this.TabName.Location = new System.Drawing.Point(241, 89);
            this.TabName.MaxLength = 200;
            this.TabName.Name = "TabName";
            this.TabName.Size = new System.Drawing.Size(350, 38);
            this.TabName.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OkButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 570);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 473);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(349, 94);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.radioSync);
            this.panel1.Controls.Add(this.radioHipster);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.addressNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bpsBox);
            this.panel1.Controls.Add(this.TabName);
            this.panel1.Controls.Add(this.portNameBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 464);
            this.panel1.TabIndex = 2;
            // 
            // radioSync
            // 
            this.radioSync.AutoSize = true;
            this.radioSync.Location = new System.Drawing.Point(241, 411);
            this.radioSync.Name = "radioSync";
            this.radioSync.Size = new System.Drawing.Size(115, 36);
            this.radioSync.TabIndex = 11;
            this.radioSync.Text = "Sync";
            this.radioSync.UseVisualStyleBackColor = true;
            this.radioSync.CheckedChanged += new System.EventHandler(this.radioSync_CheckedChanged);
            // 
            // radioHipster
            // 
            this.radioHipster.AutoSize = true;
            this.radioHipster.Checked = true;
            this.radioHipster.Location = new System.Drawing.Point(241, 369);
            this.radioHipster.Name = "radioHipster";
            this.radioHipster.Size = new System.Drawing.Size(142, 36);
            this.radioHipster.TabIndex = 10;
            this.radioHipster.TabStop = true;
            this.radioHipster.Text = "Hipster";
            this.radioHipster.UseVisualStyleBackColor = true;
            this.radioHipster.CheckedChanged += new System.EventHandler(this.radioHipster_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Address";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // addressNumber
            // 
            this.addressNumber.Location = new System.Drawing.Point(241, 301);
            this.addressNumber.MaxLength = 200;
            this.addressNumber.Name = "addressNumber";
            this.addressNumber.Size = new System.Drawing.Size(350, 38);
            this.addressNumber.TabIndex = 7;
            this.addressNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addressNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Baud Rate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tab name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bpsBox
            // 
            this.bpsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bpsBox.FormattingEnabled = true;
            this.bpsBox.Items.AddRange(new object[] {
            "38 400",
            "115 200"});
            this.bpsBox.Location = new System.Drawing.Point(241, 230);
            this.bpsBox.Name = "bpsBox";
            this.bpsBox.Size = new System.Drawing.Size(350, 39);
            this.bpsBox.TabIndex = 3;
            // 
            // addDialogBindingSource
            // 
            this.addDialogBindingSource.DataSource = typeof(ionautics.AddDialog);
            // 
            // AddDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 570);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "AddDialog";
            this.Text = "Add Tab";
            this.Load += new System.EventHandler(this.AddDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addDialogBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ComboBox portNameBox;
        private System.Windows.Forms.TextBox TabName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox bpsBox;
        private System.Windows.Forms.BindingSource addDialogBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addressNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioSync;
        private System.Windows.Forms.RadioButton radioHipster;
    }
}