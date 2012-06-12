namespace CSharpTutor.Controls
{
    #region ~Used Namespaces~

    using System;
    using System.Windows.Forms;
    using Properties;
    using System.Configuration;

    #endregion

    #region ~Class Implementation~

    public partial class Login : UserControl
    {
        public delegate void EventHandler(Object sender, EventArgs e);

        public event EventHandler DoLogin;

        #region Constructor

        public Login()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Cleans up the form
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void LoginLoad(object sender, EventArgs e)
        {
            TxtPass.Text = string.Empty;
            TxtUser.Text = string.Empty;
        }

        /// <summary>
        /// Try login with the given credentials
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BtnLoginClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUser.Text.Trim()) && !string.IsNullOrEmpty(TxtPass.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtKey.Text.Trim()))
            {
                if (DoLogin != null)
                {
                    DoLogin(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show(Resources.LoginNoCredentials, Resources.MessageBoxTitle, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Start IE with the API documentation link
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void LnkHelpLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Utility.DocumentationBrowseUtility.Start(ConfigurationManager.AppSettings["basicAuthentication"]);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Start IE with the API documentation link
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Utility.DocumentationBrowseUtility.Start(ConfigurationManager.AppSettings["getAPIKey"]);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the username string
        /// </summary>
        public string UseName
        {
            get { return TxtUser.Text.Trim(); }
        }

        /// <summary>
        /// Gets the password string
        /// </summary>
        public string Password
        {
            get { return TxtPass.Text.Trim(); }
        }

        /// <summary>
        /// Gets the key string
        /// </summary>
        public string Key
        {
            get { return TxtKey.Text.Trim(); }
        }

        #endregion
    }

    #endregion
}
