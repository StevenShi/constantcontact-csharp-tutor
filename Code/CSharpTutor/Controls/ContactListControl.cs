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

    public partial class ContactListControl : UserControl
    {
        public delegate void EventHandler(Object sender, EventArgs e);

        public event EventHandler DoShowContactsInList;


        #region Private Members

        private IList<ContactListDetails> _contactList = new List<ContactListDetails>();

        #endregion

        #region Constructor

        public ContactListControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public FrmMain FrmMain { get; set; }

        public CredentialsDetails CredentialsDetails { get; set; }

        #endregion

        #region Button Action

        /// <summary>
        /// get and display all the contact list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BtnLoadListClick(object sender, EventArgs e)
        {
            
            //clean up the response and request areas
            FrmMain.RequestString = string.Empty;
            FrmMain.ResponseString = string.Empty;

            _contactList.Clear();

            try
            {
                string strRequest;
                string strResponse;

                Cursor.Current = Cursors.WaitCursor;

                _contactList = OperationsComponent.GetContactLists(CredentialsDetails, out strRequest, out strResponse);

                Cursor.Current = Cursors.Default;

                FrmMain.RequestString = strRequest;
                FrmMain.ResponseString = strResponse;

                SetListBox();

                //activate the delete button if the list count is greater than 0
                //this will always be true since we can't delete the default list
                if (_contactList.Count > 0)
                {
                    BtnRemoveList.Enabled = true;
                }
                BtnAddList.Enabled = true;
                BtnShowContactInList.Enabled = true;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// remove the selected contact list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveListClick(object sender, EventArgs e)
        {
            try
            {
                if (LstLists.SelectedItem != null)
                {
                    //clean up the response and request areas
                    FrmMain.RequestString = string.Empty;
                    FrmMain.ResponseString = string.Empty;

                    string strRequest;
                    string strResponse;

                    var selectedList = (ContactListDetails) LstLists.SelectedItem;

                    Cursor.Current = Cursors.WaitCursor;

                    OperationsComponent.DeleteContactList(CredentialsDetails, selectedList.Id, out strRequest,
                                                          out strResponse);

                    Cursor.Current = Cursors.Default;

                    _contactList.Remove(selectedList);
                    SetListBox();

                    if (_contactList.Count == 0)
                        BtnRemoveList.Enabled = false;

                    FrmMain.RequestString = strRequest;
                    FrmMain.ResponseString = strResponse;
                }
                else
                {
                    MessageBox.Show(Resources.SelectListMessage, Resources.MessageBoxTitle, MessageBoxButtons.OK,
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
        /// will show a new form where the user can enter a new list name to be added
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BtnAddListClick(object sender, EventArgs e)
        {
            try
            {
                //clean up the response and request areas
                FrmMain.RequestString = string.Empty;
                FrmMain.ResponseString = string.Empty;

                string strRequest = string.Empty;
                string strResponse = string.Empty;

                var nList = new FrmAddList();
                var dlg = nList.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var newlyAddedList = OperationsComponent.AddContactList(CredentialsDetails, nList.ListName,
                                                                            out strRequest, out strResponse);

                    Cursor.Current = Cursors.Default;

                    _contactList.Add(newlyAddedList);
                    SetListBox();

                    LstLists.SetSelected(LstLists.FindString(newlyAddedList.Name), true);
                }

                FrmMain.RequestString = strRequest;
                FrmMain.ResponseString = strResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// will load a new control on to the main window that will handle contact API calls
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BtnShowContactInListClick(object sender, EventArgs e)
        {
            try
            {
                if (LstLists.SelectedItem != null)
                {
                    //set the current selected list to be used in a future action
                    FrmMain.CurrentSelectedList = (ContactListDetails) LstLists.SelectedItem;
                    if (DoShowContactsInList != null)
                    {
                        DoShowContactsInList(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show(Resources.SelectListMessage, Resources.MessageBoxTitle, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// refresh the contact lists list data source
        /// </summary>
        private void SetListBox()
        {
            LstLists.DataSource = null;
            LstLists.DataSource = _contactList;
            LstLists.DisplayMember = "Name";
            LstLists.ValueMember = "Id";
        }

        #endregion

        #region Documentation Links

        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Utility.DocumentationBrowseUtility.Start(ConfigurationManager.AppSettings["listCollections"]);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Utility.DocumentationBrowseUtility.Start(ConfigurationManager.AppSettings["addList"]);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel3LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Utility.DocumentationBrowseUtility.Start(ConfigurationManager.AppSettings["removeList"]);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel4LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Utility.DocumentationBrowseUtility.Start(ConfigurationManager.AppSettings["listContacts"]);
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
