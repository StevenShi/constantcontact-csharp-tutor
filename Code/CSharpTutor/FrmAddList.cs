namespace CSharpTutor
{
    #region ~Used Namespaces~

    using System.Windows.Forms;

    #endregion

    #region ~Class Implementation~

    public partial class FrmAddList : Form
    {
        #region Constructor

        public FrmAddList()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the entered list name
        /// </summary>
        public string ListName
        {
            get { return txtList.Text.Trim(); }
        }

        #endregion
    }

    #endregion
}
