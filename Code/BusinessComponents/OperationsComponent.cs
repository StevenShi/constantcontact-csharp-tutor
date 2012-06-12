namespace BusinessComponents
{
    #region ~Used Namespaces~

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using BusinessObjects;
    using Utility;

    #endregion

    #region ~Class Implementation

    public class OperationsComponent
    {
        #region Private Members

        private static readonly XNamespace W3Ns = "http://www.w3.org/2005/Atom";
        private static readonly XNamespace ConstantContactNs = "http://ws.constantcontact.com/ns/1.0/";

        #endregion

        #region Public Methods

        /// <summary>
        /// Method used for trying to access the current user root document, if the credentials are fine then an xml response will be brought back
        /// else an exception will be thrown
        /// </summary>
        /// <param name="credentialsDetail">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        public static void Authentification(CredentialsDetails credentialsDetail,
                                            out string strRequest, out string strResponse)
        {
            var contactURI = "https://api.constantcontact.com/ws/customers/" + credentialsDetail.User + "/";

            ApiCallComponent.CallServiceGet(credentialsDetail, contactURI, out strRequest, out strResponse);
        }

        /// <summary>
        /// Gets the contact list collection for the current user
        /// </summary>
        /// <param name="credentialsDetail">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        /// <returns>The contact lists collection</returns>
        public static List<ContactListDetails> GetContactLists(CredentialsDetails credentialsDetail,
                                                               out string strRequest, out string strResponse)
        {
            var contactURI = "https://api.constantcontact.com/ws/customers/" + credentialsDetail.User + "/lists";

            var xmlResponse = ApiCallComponent.CallServiceGet(credentialsDetail, contactURI, out strRequest,
                                                              out strResponse);

            var xdoc = XDocument.Parse(xmlResponse);

            if (xdoc.Root == null)
            {
                return null;
            }

            var lists = from f in xdoc.Root.Descendants(W3Ns + "entry")
                        let element = f.Element(W3Ns + "id")
                        where element != null
                        let xElement = element
                        where
                            xElement != null &&
                            (!xElement.Value.Contains("do-not-mail") & !xElement.Value.Contains("active") &
                             !xElement.Value.Contains("removed"))
                        let xElement1 = f.Element(W3Ns + "content")
                        where xElement1 != null
                        let element1 = xElement1.Element(ConstantContactNs + "ContactList")
                        where element1 != null
                        let xElement2 = element1.Element(ConstantContactNs + "Name")
                        where xElement2 != null
                        select new
                                   {
                                       id = element.Value,
                                       name = xElement2.Value
                                   };

            return
                lists.Select(
                    list => new ContactListDetails {Id = "https" + Regex.Split(list.id, "http")[1], Name = list.name}).
                    ToList();
        }

        /// <summary>
        /// Get the contacts for a given list along with some contact details
        /// </summary>
        /// <param name="credentialsDetail">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="listId">The id of the list for witch the contacts will be brought</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        /// <returns>A list of contact detail objects</returns>
        public static List<ContactDetails> GetContacts(CredentialsDetails credentialsDetail, string listId,
                                                       out string strRequest, out string strResponse)
        {
            var contactCollection = new List<ContactDetails>();

            var xmlResponse = ApiCallComponent.CallServiceGet(credentialsDetail, listId + "/members", out strRequest,
                                                              out strResponse);

            var xdoc = XDocument.Parse(xmlResponse);

            if (xdoc.Root == null)
            {
                return null;
            }

            var contacts = from f in xdoc.Root.Descendants(W3Ns + "entry")
                           let element = f.Element(W3Ns + "id")
                           where element != null
                           select new
                                      {
                                          id = "https" + Regex.Split(element.Value, "http")[1]
                                      };

            foreach (var contact in contacts)
            {
                string req;
                string res;

                var xmlContact = ApiCallComponent.CallServiceGet(credentialsDetail, contact.id, out req, out res);

                var contactDetails = new ContactDetails();

                var xContact = XDocument.Parse(xmlContact);

                var c = (from f in xContact.Descendants(W3Ns + "content")
                         let element = f.Element(ConstantContactNs + "Contact")
                         where element != null
                         let element0 = element.Element(ConstantContactNs + "EmailAddress")
                         where element0 != null
                         let element1 = element.Element(ConstantContactNs + "FirstName")
                         where element1 != null
                         let element2 = element.Element(ConstantContactNs + "LastName")
                         where element2 != null
                         let element3 = element.Element(ConstantContactNs + "InsertTime")
                         where element3 != null
                         select new
                                    {
                                        email = element0.Value,
                                        firstName = element1.Value,
                                        lastName = element2.Value,
                                        updated = element3.Value
                                    }).ToList();

                var firstOrDefault = c.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    contactDetails.Id = contact.id;
                    contactDetails.FirstName = firstOrDefault.firstName;
                    contactDetails.LastName = firstOrDefault.lastName;
                    contactDetails.CreateDate = string.Format("{0:MMM d, yyyy}", DateTime.Parse(firstOrDefault.updated));
                    contactDetails.Email = firstOrDefault.email;
                }

                contactCollection.Add(contactDetails);
            }

            return contactCollection;
        }

        /// <summary>
        /// Method used for adding a new contact list to Constant Contact
        /// </summary>
        /// <param name="credentialsDetail">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="name">The name of the new contact list</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        /// <returns>A Contact List Detail object with the newly created contact lists</returns>
        public static ContactListDetails AddContactList(CredentialsDetails credentialsDetail, string name,
                                                        out string strRequest, out string strResponse)
        {
            var returnValue = new ContactListDetails();

            var contactURI = "https://api.constantcontact.com/ws/customers/" + credentialsDetail.User + "/lists";

            var response = ApiCallComponent.CallServicePost(credentialsDetail, contactURI, CreateList(name),
                                                            out strRequest, out strResponse);

            var xdoc = XDocument.Parse(response);

            var result = from doc in xdoc.Descendants(W3Ns + "id")
                         select doc.Value;

            var id = result.FirstOrDefault();

            if (string.IsNullOrEmpty(id))
                throw new Exception();

            returnValue.Id = "https" + Regex.Split(id, "http")[1];
            returnValue.Name = name;

            return returnValue;
        }

        /// <summary>
        /// Method used for deleting an existing contact list
        /// </summary>
        /// <param name="credentialsDetail">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="listId">The id of the list to be deleted</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        public static void DeleteContactList(CredentialsDetails credentialsDetail, string listId, out string strRequest,
                                             out string strResponse)
        {
            ApiCallComponent.CallServiceDelete(credentialsDetail, listId, out strRequest, out strResponse);
        }

        /// <summary>
        /// Method used for updating an existing contact
        /// </summary>
        /// <param name="credentialsDetails">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="contact">The contact url</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        public static void UpdateExistingContact(CredentialsDetails credentialsDetails, ContactDetails contact, out string strRequest, out string strResponse)
        {
            string req;
            string res;

            //Get the contact data
            var xmlContact = ApiCallComponent.CallServiceGet(credentialsDetails, contact.Id, out req, out res);

            //Update the contact data
            var xContact = XDocument.Parse(xmlContact);
            var contactNode = (from f in xContact.Descendants(W3Ns + "content")
                               let element = f.Element(ConstantContactNs + "Contact")
                               where element != null
                               select element).FirstOrDefault();

            if (contactNode != null)
            {
                contactNode.SetElementValue(ConstantContactNs + "FirstName", contact.FirstName);
                contactNode.SetElementValue(ConstantContactNs + "LastName", contact.LastName);
            }

            //Put the updated contact data
            ApiCallComponent.CallServicePut(credentialsDetails, contact.Id, xContact.Declaration.ToString() + xContact, out strRequest, out strResponse);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the xml for adding a new list to Constant Contact
        /// </summary>
        /// <param name="name">The new contact list name</param>
        /// <returns>The string representation of an xml for creating a new contact list</returns>
        private static string CreateList(string name)
        {
            var xmlData = new StringBuilder();
            xmlData.Append("<entry xmlns=\"http://www.w3.org/2005/Atom\">");
            xmlData.Append("<id>data:,</id>");
            xmlData.Append("<title />");
            xmlData.Append("<author />");
            xmlData.AppendFormat("<updated>{0}</updated>", DateTime.Now.ToShortDateString());
            xmlData.Append("<content type=\"application/vnd.ctct+xml\">");
            xmlData.Append("<ContactList xmlns=\"http://ws.constantcontact.com/ns/1.0/\">");
            xmlData.Append("<OptInDefault>false</OptInDefault>");
            xmlData.Append("<Name>" + name + "</Name>");
            xmlData.Append("<SortOrder>99</SortOrder>");
            xmlData.Append("</ContactList>");
            xmlData.Append("</content>");
            xmlData.Append("</entry>");
            return xmlData.ToString();
        }

        #endregion
    }

    #endregion
}
