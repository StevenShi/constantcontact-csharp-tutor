namespace CSharpTutor
{
    #region ~Used Namespaces~

    using System.Windows.Forms;
    using BusinessObjects;
    using BusinessComponents;
    using Controls;
    using Properties;
    using System;

    #endregion

    #region ~Class Implementation~

    /// <summary>
    /// The main UI form container that will display the Constant Contact operations
    /// </summary>
    public partial class FrmMain : Form
    {
        #region Private Members

        private CredentialsDetails _credentialsDetails;
        private Login _login;
        private ContactListControl _contactListControl;
        private ContactControl _contactControl;

        #endregion

        #region Constructor

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Main Form Events

        /// <summary>
        /// Initialize the quick start tool
        /// This will show the operations panel and the request response panel
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void GetStartedToolStripMenuItemClick(object sender, EventArgs e)
        {
            splitContainer.Visible = true;
            restartToolStripMenuItem.Enabled = true;
            getStartedToolStripMenuItem.Enabled = false;


            //show the login control
            _login = new Login {Dock = DockStyle.Fill, Parent = splitContainer.Panel1};
            _login.DoLogin += LoginDoLogin;
        }

        /// <summary>
        /// Reset all the data and give the user the opportunity to start over the guide
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void RestartToolStripMenuItemClick(object sender, EventArgs e)
        {
            splitContainer.Visible = false;
            restartToolStripMenuItem.Enabled = false;
            getStartedToolStripMenuItem.Enabled = true;
            richTextBoxRequest.Text = string.Empty;
            richTextBoxResponse.Text = string.Empty;

            //clean up the loging control
            if (_login != null)
            {
                _login.DoLogin -= LoginDoLogin;
                _login.Parent = null;
                _login = null;
            }

            //clean up the contact list control
            if (_contactListControl != null)
            {
                _contactListControl.DoShowContactsInList -= ContactListControlDoShowContactsInList;
                _contactListControl.Parent = null;
                _contactListControl = null;
            }

            //clean up the contact list control
            if (_contactControl != null)
            {
                _contactControl.DoBack -= ContactControlDoBack;
                _contactControl.Parent = null;
                _contactControl = null;
            }
        }


        #endregion

        #region Authentication Event

        /// <summary>
        /// event triggered when the user tries to login 
        /// </summary>
        /// <param name="sender">the authentication control</param>
        /// <param name="e">e</param>
        private void LoginDoLogin(object sender, EventArgs e)
        {
            //do login action
            var user = ((Login) sender).UseName;
            var pass = ((Login) sender).Password;
            var key = ((Login) sender).Key;

            _credentialsDetails = new CredentialsDetails {Key = key, Password = pass, User = user};

            try
            {
                string strRequest;
                string strResponse;

                Cursor.Current = Cursors.WaitCursor;

                OperationsComponent.Authentification(_credentialsDetails, out strRequest, out strResponse);

                Cursor.Current = Cursors.Default;

                //print the request string
                richTextBoxRequest.Text = strRequest;

                //print the response string
                richTextBoxResponse.Text = strResponse;

                //clean up the loging control
                if (_login == null) return;
                _login.DoLogin -= LoginDoLogin;
                _login.Parent = null;
                _login = null;

                //show the contact list control
                _contactListControl = new ContactListControl
                                          {
                                              Dock = DockStyle.Fill,
                                              Parent = splitContainer.Panel1,
                                              FrmMain = this,
                                              CredentialsDetails = _credentialsDetails
                                          };
                _contactListControl.DoShowContactsInList += (ContactListControlDoShowContactsInList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Controls Events

        /// <summary>
        /// event triggered when the user tries to view contacts in a contact list 
        /// </summary>
        /// <param name="sender">the contact list control</param>
        /// <param name="e">e</param>
        private void ContactListControlDoShowContactsInList(object sender, EventArgs e)
        {
            if (_contactListControl == null) return;
            _contactListControl.DoShowContactsInList -= ContactListControlDoShowContactsInList;
            _contactListControl.Parent = null;
            _contactListControl = null;

            //show the contact API calls control
            _contactControl = new ContactControl(this, _credentialsDetails)
                                  {Dock = DockStyle.Fill, Parent = splitContainer.Panel1};
            _contactControl.DoBack += (ContactControlDoBack);
        }

        /// <summary>
        /// event triggered when the user wants to go back to the list API calls
        /// </summary>
        /// <param name="sender">the contact control</param>
        /// <param name="e">e</param>
        private void ContactControlDoBack(object sender, EventArgs e)
        {
            if (_contactControl == null) return;
            _contactControl.DoBack -= ContactControlDoBack;
            _contactControl.Parent = null;
            _contactControl = null;

            //show the contact list control
            _contactListControl = new ContactListControl
                                      {
                                          Dock = DockStyle.Fill,
                                          Parent = splitContainer.Panel1,
                                          FrmMain = this,
                                          CredentialsDetails = _credentialsDetails
                                      };
            _contactListControl.DoShowContactsInList += (ContactListControlDoShowContactsInList);
        }

        #endregion

        #region Properties

        /// <summary>
        /// get/set Request String
        /// </summary>
        public string RequestString
        {
            get { return richTextBoxRequest.Text; }
            set { richTextBoxRequest.Text = value; }
        }

        /// <summary>
        /// get/set response string
        /// </summary>
        public string ResponseString
        {
            get { return richTextBoxResponse.Text; }
            set { richTextBoxResponse.Text = value; }
        }

        /// <summary>
        /// get/set the current selected list from the email contact lists
        /// </summary>
        public ContactListDetails CurrentSelectedList { get; set; }

        #endregion

    }

    #endregion
}
