namespace Bus_Stop_Guide
{
    partial class mainfrm
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
            this.selectRoutelbl = new System.Windows.Forms.Label();
            this.showTimesbtn = new System.Windows.Forms.Button();
            this.busRoutecmb = new System.Windows.Forms.ComboBox();
            this.resulttxt = new System.Windows.Forms.TextBox();
            this.directionlbl = new System.Windows.Forms.Label();
            this.directioncmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stopcmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // selectRoutelbl
            // 
            this.selectRoutelbl.AutoSize = true;
            this.selectRoutelbl.Location = new System.Drawing.Point(48, 9);
            this.selectRoutelbl.Name = "selectRoutelbl";
            this.selectRoutelbl.Size = new System.Drawing.Size(90, 13);
            this.selectRoutelbl.TabIndex = 0;
            this.selectRoutelbl.Text = "Select Bus Route";
            // 
            // showTimesbtn
            // 
            this.showTimesbtn.Enabled = false;
            this.showTimesbtn.Location = new System.Drawing.Point(51, 182);
            this.showTimesbtn.Name = "showTimesbtn";
            this.showTimesbtn.Size = new System.Drawing.Size(75, 23);
            this.showTimesbtn.TabIndex = 6;
            this.showTimesbtn.Text = "Show Times";
            this.showTimesbtn.UseVisualStyleBackColor = true;
            this.showTimesbtn.Click += new System.EventHandler(this.showTimesbtn_Click);
            // 
            // busRoutecmb
            // 
            this.busRoutecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busRoutecmb.DropDownWidth = 10;
            this.busRoutecmb.FormattingEnabled = true;
            this.busRoutecmb.Location = new System.Drawing.Point(12, 25);
            this.busRoutecmb.Name = "busRoutecmb";
            this.busRoutecmb.Size = new System.Drawing.Size(162, 21);
            this.busRoutecmb.TabIndex = 1;
            this.busRoutecmb.SelectionChangeCommitted += new System.EventHandler(this.busRoutecmb_SelectionChangeCommitted);
            // 
            // resulttxt
            // 
            this.resulttxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resulttxt.Location = new System.Drawing.Point(193, 12);
            this.resulttxt.Multiline = true;
            this.resulttxt.Name = "resulttxt";
            this.resulttxt.Size = new System.Drawing.Size(364, 34);
            this.resulttxt.TabIndex = 7;
            // 
            // directionlbl
            // 
            this.directionlbl.AutoSize = true;
            this.directionlbl.Location = new System.Drawing.Point(48, 67);
            this.directionlbl.Name = "directionlbl";
            this.directionlbl.Size = new System.Drawing.Size(82, 13);
            this.directionlbl.TabIndex = 2;
            this.directionlbl.Text = "Select Direction";
            // 
            // directioncmb
            // 
            this.directioncmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directioncmb.Enabled = false;
            this.directioncmb.FormattingEnabled = true;
            this.directioncmb.Location = new System.Drawing.Point(12, 83);
            this.directioncmb.Name = "directioncmb";
            this.directioncmb.Size = new System.Drawing.Size(162, 21);
            this.directioncmb.TabIndex = 3;
            this.directioncmb.SelectionChangeCommitted += new System.EventHandler(this.directioncmb_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Stop";
            // 
            // stopcmb
            // 
            this.stopcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopcmb.DropDownWidth = 350;
            this.stopcmb.Enabled = false;
            this.stopcmb.FormattingEnabled = true;
            this.stopcmb.Location = new System.Drawing.Point(13, 139);
            this.stopcmb.Name = "stopcmb";
            this.stopcmb.Size = new System.Drawing.Size(161, 21);
            this.stopcmb.TabIndex = 5;
            this.stopcmb.SelectionChangeCommitted += new System.EventHandler(this.stopcmb_SelectionChangeCommitted);
            // 
            // mainfrm
            // 
            this.AcceptButton = this.showTimesbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 217);
            this.Controls.Add(this.stopcmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.directioncmb);
            this.Controls.Add(this.directionlbl);
            this.Controls.Add(this.resulttxt);
            this.Controls.Add(this.busRoutecmb);
            this.Controls.Add(this.showTimesbtn);
            this.Controls.Add(this.selectRoutelbl);
            this.Name = "mainfrm";
            this.Text = "Bus Stop Guide";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectRoutelbl;
        private System.Windows.Forms.Button showTimesbtn;
        private System.Windows.Forms.ComboBox busRoutecmb;
        private System.Windows.Forms.TextBox resulttxt;
        private System.Windows.Forms.Label directionlbl;
        private System.Windows.Forms.ComboBox directioncmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox stopcmb;
    }
}

