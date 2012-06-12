namespace BusinessObjects
{

    #region ~Class Implementation~

    /// <summary>
    /// Object used for encapsulating the details of a contact
    /// </summary>
    public class ContactDetails
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreateDate { get; set; }
        public string Email { get; set; }
    }

    #endregion
}
