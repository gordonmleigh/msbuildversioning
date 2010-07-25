namespace SampleInc.AwesomeApp
{
    partial class AboutDialog
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buildLabel = new System.Windows.Forms.Label();
            this.buildValueLabel = new System.Windows.Forms.Label();
            this.dateValueLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.versionValueLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(86, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Awesome App";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(198, 105);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79F));
            this.tableLayoutPanel.Controls.Add(this.buildLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.buildValueLabel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.dateValueLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.dateLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.versionValueLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.versionLabel, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(15, 36);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(258, 58);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // buildLabel
            // 
            this.buildLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildLabel.Location = new System.Drawing.Point(3, 38);
            this.buildLabel.Name = "buildLabel";
            this.buildLabel.Size = new System.Drawing.Size(48, 20);
            this.buildLabel.TabIndex = 5;
            this.buildLabel.Text = "Build:";
            this.buildLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buildValueLabel
            // 
            this.buildValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildValueLabel.Location = new System.Drawing.Point(57, 38);
            this.buildValueLabel.Name = "buildValueLabel";
            this.buildValueLabel.Size = new System.Drawing.Size(198, 20);
            this.buildValueLabel.TabIndex = 4;
            this.buildValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateValueLabel
            // 
            this.dateValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateValueLabel.Location = new System.Drawing.Point(57, 19);
            this.dateValueLabel.Name = "dateValueLabel";
            this.dateValueLabel.Size = new System.Drawing.Size(198, 19);
            this.dateValueLabel.TabIndex = 3;
            this.dateValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateLabel
            // 
            this.dateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateLabel.Location = new System.Drawing.Point(3, 19);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(48, 19);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Date:";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // versionValueLabel
            // 
            this.versionValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionValueLabel.Location = new System.Drawing.Point(57, 0);
            this.versionValueLabel.Name = "versionValueLabel";
            this.versionValueLabel.Size = new System.Drawing.Size(198, 19);
            this.versionValueLabel.TabIndex = 1;
            this.versionValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // versionLabel
            // 
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLabel.Location = new System.Drawing.Point(3, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(48, 19);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version:";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(285, 140);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label buildLabel;
        private System.Windows.Forms.Label buildValueLabel;
        private System.Windows.Forms.Label dateValueLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label versionValueLabel;
    }
}