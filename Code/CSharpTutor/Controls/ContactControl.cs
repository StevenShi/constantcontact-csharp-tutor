namespace CSharpTutor.Controls
{
    #region ~Used Namespaces~

    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Windows.Forms;
    using BusinessObjects;
    using BusinessComponents;
    using Properties;

    #endregion

    #region ~Class Implementation~

    public partial class ContactControl : UserControl
    {
        public delegate void EventHandler(Object sender, EventArgs e);

        public event EventHandler DoBack;

        #region Private Members

        private IList<ContactDetails> _contacts = new List<ContactDetails>();

        #endregion

        #region Constructor

        public ContactControl()
        {
            InitializeComponent();
        }

        public ContactControl(FrmMain frmMain, CredentialsDetails credentialsDetails)
        {
            FrmMain = frmMain;
            CredentialsDetails = credentialsDetails;
            InitializeComponent();
        }

        #endregion

        #region Properties

        public FrmMain FrmMain { get; set; }

        public CredentialsDetails CredentialsDetails { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Return to main menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BtnDoneClick(object sender, EventArgs e)
        {
            if (DoBack != null)
            {
                DoBack(this, new EventArgs());
            }
        }

        /// <summary>
        /// On Load
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ContactControlLoad(object sender, EventArgs e)
        {
            //clean up the response and request areas
            FrmMain.RequestString = string.Empty;
            FrmMain.ResponseString = string.Empty;


            _contacts.Clear();

            try
            {
                //get list members
                string strRequest;
                string strResponse;

                Cursor.Current = Cursors.WaitCursor;

                _contacts = OperationsComponent.GetContacts(CredentialsDetails, FrmMain.CurrentSelectedList.Id,
                                                            out strRequest, out strResponse);

                Cursor.Current = Cursors.Default;

                FrmMain.RequestString = strRequest;
                FrmMain.ResponseString = strResponse;

                //set up grid view data source
                LblList.Text = string.Format("Contact list {0} members:", FrmMain.CurrentSelectedList.Name);
                dgwContacts.DataSource = _contacts;

                //disable the update contact button if there aren't any contacts
                if (_contacts.Count == 0)
                    BtnModify.Enabled = false;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// modify the selected contact information
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BtnModifyClick(object sender, EventArgs e)
        {
            FrmMain.RequestString = string.Empty;
            FrmMain.ResponseString = string.Empty;

            try
            {
                if (dgwContacts.SelectedRows.Count == 1)
                {
                    var contact = (ContactDetails) dgwContacts.SelectedRows[0].DataBoundItem;


                    var frmUpdateContact = new FrmUpdateContact(contact);
                    var dlg = frmUpdateContact.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        string strRequest;
                        string strResponse;
                        OperationsComponent.UpdateExistingContact(CredentialsDetails, contact, out strRequest,
                                                                  out strResponse);

                        Cursor.Current = Cursors.Default;

                        FrmMain.RequestString = strRequest;
                        FrmMain.ResponseString = strResponse;

                        //update grid view displayed information
                        dgwContacts.DataSource = null;
                        dgwContacts.DataSource = _contacts;
                    }
                }
                else
                {
                    MessageBox.Show(Resources.SelectContactMessage, Resources.MessageBoxTitle, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// start IE with the API documentation link
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void UpdateContactInformationLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Utility.DocumentationBrowseUtility.Start(ConfigurationManager.AppSettings["updateContact"]);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }

    #endregion
}
