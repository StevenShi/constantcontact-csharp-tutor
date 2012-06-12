namespace CSharpTutor.Controls
{
    partial class ContactControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnDone = new System.Windows.Forms.Button();
            this.dgwContacts = new System.Windows.Forms.DataGridView();
            this.LblList = new System.Windows.Forms.Label();
            this.BtnModify = new System.Windows.Forms.Button();
            this.updateContactInformationLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDone
            // 
            this.BtnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDone.Location = new System.Drawing.Point(693, 199);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(99, 23);
            this.BtnDone.TabIndex = 5;
            this.BtnDone.Text = "Go Back";
            this.BtnDone.UseVisualStyleBackColor = true;
            this.BtnDone.Click += new System.EventHandler(this.BtnDoneClick);
            // 
            // dgwContacts
            // 
            this.dgwContacts.AllowUserToAddRows = false;
            this.dgwContacts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgwContacts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgwContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContacts.Location = new System.Drawing.Point(0, 20);
            this.dgwContacts.Name = "dgwContacts";
            this.dgwContacts.ReadOnly = true;
            this.dgwContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwContacts.Size = new System.Drawing.Size(802, 173);
            this.dgwContacts.TabIndex = 6;
            // 
            // LblList
            // 
            this.LblList.AutoSize = true;
            this.LblList.Location = new System.Drawing.Point(3, 4);
            this.LblList.Name = "LblList";
            this.LblList.Size = new System.Drawing.Size(14, 13);
            this.LblList.TabIndex = 7;
            this.LblList.Text = "X";
            // 
            // BtnModify
            // 
            this.BtnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnModify.Location = new System.Drawing.Point(6, 199);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(135, 23);
            this.BtnModify.TabIndex = 8;
            this.BtnModify.Text = "Update selected contact";
            this.BtnModify.UseVisualStyleBackColor = true;
            this.BtnModify.Click += new System.EventHandler(this.BtnModifyClick);
            // 
            // updateContactInformationLink
            // 
            this.updateContactInformationLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateContactInformationLink.AutoSize = true;
            this.updateContactInformationLink.Location = new System.Drawing.Point(147, 204);
            this.updateContactInformationLink.Name = "updateContactInformationLink";
            this.updateContactInformationLink.Size = new System.Drawing.Size(145, 13);
            this.updateContactInformationLink.TabIndex = 9;
            this.updateContactInformationLink.TabStop = true;
            this.updateContactInformationLink.Text = "Updating Contact Information";
            this.updateContactInformationLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UpdateContactInformationLink);
            // 
            // ContactControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updateContactInformationLink);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.LblList);
            this.Controls.Add(this.dgwContacts);
            this.Controls.Add(this.BtnDone);
            this.Name = "ContactControl";
            this.Size = new System.Drawing.Size(804, 230);
            this.Load += new System.EventHandler(this.ContactControlLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgwContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDone;
        private System.Windows.Forms.DataGridView dgwContacts;
        private System.Windows.Forms.Label LblList;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.LinkLabel updateContactInformationLink;

    }
}
