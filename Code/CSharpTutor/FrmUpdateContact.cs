namespace CSharpTutor
{
    #region ~Used Namespaces~

    using System;
    using System.Windows.Forms;
    using BusinessObjects;

    #endregion

    #region ~Class Implementation~

    public partial class FrmUpdateContact : Form
    {
        #region Constructor

        public FrmUpdateContact()
        {
            InitializeComponent();
        }

        public FrmUpdateContact(ContactDetails contact)
        {
            InitializeComponent();
            Contact = contact;
            TxtFirstName.Text = Contact.FirstName;
            TxtLastName.Text = Contact.LastName;
        }

        #endregion

        #region Properties

        public ContactDetails Contact { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// updates the Contact information with the entered first/last name
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BtnUpdateClick(object sender, EventArgs e)
        {
            Contact.FirstName = TxtFirstName.Text.Trim();
            Contact.LastName = TxtLastName.Text.Trim();
        }

        #endregion
    }

    #endregion
}
