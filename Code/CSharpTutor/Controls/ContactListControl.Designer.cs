namespace CSharpTutor.Controls
{
    partial class ContactListControl
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
            this.BtnLoadList = new System.Windows.Forms.Button();
            this.LstLists = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddList = new System.Windows.Forms.Button();
            this.BtnRemoveList = new System.Windows.Forms.Button();
            this.BtnShowContactInList = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // BtnLoadList
            // 
            this.BtnLoadList.Location = new System.Drawing.Point(23, 19);
            this.BtnLoadList.Name = "BtnLoadList";
            this.BtnLoadList.Size = new System.Drawing.Size(115, 23);
            this.BtnLoadList.TabIndex = 0;
            this.BtnLoadList.Text = "Load Existing Lists";
            this.BtnLoadList.UseVisualStyleBackColor = true;
            this.BtnLoadList.Click += new System.EventHandler(this.BtnLoadListClick);
            // 
            // LstLists
            // 
            this.LstLists.FormattingEnabled = true;
            this.LstLists.Location = new System.Drawing.Point(223, 39);
            this.LstLists.Name = "LstLists";
            this.LstLists.Size = new System.Drawing.Size(166, 121);
            this.LstLists.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available email lists:";
            // 
            // BtnAddList
            // 
            this.BtnAddList.Enabled = false;
            this.BtnAddList.Location = new System.Drawing.Point(23, 55);
            this.BtnAddList.Name = "BtnAddList";
            this.BtnAddList.Size = new System.Drawing.Size(115, 23);
            this.BtnAddList.TabIndex = 3;
            this.BtnAddList.Text = "Add new list";
            this.BtnAddList.UseVisualStyleBackColor = true;
            this.BtnAddList.Click += new System.EventHandler(this.BtnAddListClick);
            // 
            // BtnRemoveList
            // 
            this.BtnRemoveList.Enabled = false;
            this.BtnRemoveList.Location = new System.Drawing.Point(23, 91);
            this.BtnRemoveList.Name = "BtnRemoveList";
            this.BtnRemoveList.Size = new System.Drawing.Size(115, 23);
            this.BtnRemoveList.TabIndex = 4;
            this.BtnRemoveList.Text = "Remove selected list";
            this.BtnRemoveList.UseVisualStyleBackColor = true;
            this.BtnRemoveList.Click += new System.EventHandler(this.BtnRemoveListClick);
            // 
            // BtnShowContactInList
            // 
            this.BtnShowContactInList.Enabled = false;
            this.BtnShowContactInList.Location = new System.Drawing.Point(23, 127);
            this.BtnShowContactInList.Name = "BtnShowContactInList";
            this.BtnShowContactInList.Size = new System.Drawing.Size(115, 23);
            this.BtnShowContactInList.TabIndex = 5;
            this.BtnShowContactInList.Text = "Show contacts in list";
            this.BtnShowContactInList.UseVisualStyleBackColor = true;
            this.BtnShowContactInList.Click += new System.EventHandler(this.BtnShowContactInListClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(23, 42);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(181, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Retrieving the Contact List Collection";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(23, 78);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(74, 13);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Creating a List";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(23, 114);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(74, 13);
            this.linkLabel3.TabIndex = 8;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Deleting a List";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel3LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(23, 150);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(96, 13);
            this.linkLabel4.TabIndex = 9;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Listing All Contacts";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel4LinkClicked);
            // 
            // ContactListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.BtnShowContactInList);
            this.Controls.Add(this.BtnRemoveList);
            this.Controls.Add(this.BtnAddList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstLists);
            this.Controls.Add(this.BtnLoadList);
            this.Name = "ContactListControl";
            this.Size = new System.Drawing.Size(424, 208);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadList;
        private System.Windows.Forms.ListBox LstLists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAddList;
        private System.Windows.Forms.Button BtnRemoveList;
        private System.Windows.Forms.Button BtnShowContactInList;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
    }
}
