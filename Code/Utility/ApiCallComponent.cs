namespace Utility
{
    #region ~Used Namespaces~

    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using BusinessObjects;

    #endregion

    #region ~Class Implementation~

    public static class ApiCallComponent
    {
        #region Public Methods

        /// <summary>
        /// Method used for making an http GET call
        /// </summary>
        /// <param name="credentialsDetails">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="contactURI">The URL for the call</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        /// <returns>The string representation of the response</returns>
        public static string CallServiceGet(CredentialsDetails credentialsDetails, string contactURI,
                                            out string strRequest, out string strResponse)
        {
            var loginCredentials = new CredentialCache
                                       {
                                           {
                                               new Uri("https://api.constantcontact.com/ws/customers/" +
                                                       credentialsDetails.User),
                                               "Basic",
                                               new NetworkCredential(
                                               credentialsDetails.Key + "%" + credentialsDetails.User,
                                               credentialsDetails.Password)
                                               }
                                       };

            var request = WebRequest.Create(contactURI);

            request.Credentials = loginCredentials;

            var response = (HttpWebResponse) request.GetResponse();

            var reader = new StreamReader(response.GetResponseStream());

            var xmlResponse = reader.ReadToEnd();
            reader.Close();
            response.Close();

            strRequest = PrintRequestString(request, credentialsDetails, string.Empty);
            strResponse = xmlResponse;

            return xmlResponse;

        }

        /// <summary>
        /// Method used for making an http DELETE call
        /// </summary>
        /// <param name="credentialsDetails">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="contactURI">The URL for the call</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        /// <returns>The string representation of the response</returns>
        public static string CallServiceDelete(CredentialsDetails credentialsDetails, string contactURI,
                                               out string strRequest, out string strResponse)
        {
            var loginCredentials = new CredentialCache
                                       {
                                           {
                                               new Uri("https://api.constantcontact.com/ws/customers/" +
                                                       credentialsDetails.User),
                                               "Basic",
                                               new NetworkCredential(
                                               credentialsDetails.Key + "%" + credentialsDetails.User,
                                               credentialsDetails.Password)
                                               }
                                       };

            var request = (HttpWebRequest) WebRequest.Create(contactURI);
            request.Credentials = loginCredentials;
            request.Method = "DELETE";

            var response = (HttpWebResponse) request.GetResponse();

            var reader = new StreamReader(response.GetResponseStream());

            var xmlResponse = reader.ReadToEnd();
            reader.Close();
            response.Close();

            strRequest = PrintRequestString(request, credentialsDetails, string.Empty);
            strResponse = xmlResponse;

            return xmlResponse;
        }

        /// <summary>
        /// Method used for making an http POST call
        /// </summary>
        /// <param name="credentialsDetails">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="contactURI">The URL for the call</param>
        /// <param name="data">The post data string representation</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        /// <returns>The string representation of the response</returns>
        public static string CallServicePost(CredentialsDetails credentialsDetails, string contactURI,
                                             string data, out string strRequest, out string strResponse)
        {
            var loginCredentials = new CredentialCache
                                       {
                                           {
                                               new Uri("https://api.constantcontact.com/ws/customers/" +
                                                       credentialsDetails.User),
                                               "Basic",
                                               new NetworkCredential(
                                               credentialsDetails.Key + "%" + credentialsDetails.User,
                                               credentialsDetails.Password)
                                               }
                                       };

            var request = (HttpWebRequest) WebRequest.Create(contactURI);
            request.Method = "POST";
            request.ContentType = "application/atom+xml";
            request.Credentials = loginCredentials;
            var xmlData = data;
            var byteArray = Encoding.UTF8.GetBytes(xmlData);


            request.ContentLength = byteArray.Length;
            var xmlResponse = string.Empty;
            var streamRequest = request.GetRequestStream();
            streamRequest.Write(byteArray, 0, byteArray.Length);
            streamRequest.Close();
            var response = (HttpWebResponse) request.GetResponse();

            var reader = new StreamReader(response.GetResponseStream());

            xmlResponse += reader.ReadToEnd();
            reader.Close();
            response.Close();

            strRequest = PrintRequestString(request, credentialsDetails, data);
            strResponse = xmlResponse;

            return xmlResponse;
        }

        /// <summary>
        /// Method used for making an http PUT call
        /// </summary>
        /// <param name="credentialsDetails">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="contactURI">The URL for the call</param>
        /// <param name="data">The put data string representation</param>
        /// <param name="strRequest">The request string representation</param>
        /// <param name="strResponse">The response string representation</param>
        /// <returns>The string representation of the response</returns>
        public static string CallServicePut(CredentialsDetails credentialsDetails, string contactURI,
                                            string data, out string strRequest, out string strResponse)
        {
            var loginCredentials = new CredentialCache
                                       {
                                           {
                                               new Uri("https://api.constantcontact.com/ws/customers/" +
                                                       credentialsDetails.User),
                                               "Basic",
                                               new NetworkCredential(
                                               credentialsDetails.Key + "%" + credentialsDetails.User,
                                               credentialsDetails.Password)
                                               }
                                       };

            var request = (HttpWebRequest)WebRequest.Create(contactURI);
            request.Method = "PUT";
            request.ContentType = "application/atom+xml";
            request.Credentials = loginCredentials;
            var xmlData = data;
            var byteArray = Encoding.UTF8.GetBytes(xmlData);


            request.ContentLength = byteArray.Length;
            var xmlResponse = string.Empty;
            var streamRequest = request.GetRequestStream();
            streamRequest.Write(byteArray, 0, byteArray.Length);
            streamRequest.Close();
            var response = (HttpWebResponse)request.GetResponse();

            var reader = new StreamReader(response.GetResponseStream());

            xmlResponse += reader.ReadToEnd();
            reader.Close();
            response.Close();

            strRequest = PrintRequestString(request, credentialsDetails, data);
            strResponse = xmlResponse;

            return xmlResponse;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the display string for the current http request
        /// </summary>
        /// <param name="request">The WebRequest object</param>
        /// <param name="credentialsDetails">An object that encapsulates the Constant Contact credentials</param>
        /// <param name="postData">The post data string representation</param>
        /// <returns>A string representation of the request for displaying</returns>
        private static string PrintRequestString(WebRequest request, CredentialsDetails credentialsDetails,
                                                 string postData)
        {
            var returnValue = string.Format("URL: {0}", request.RequestUri);
            returnValue = string.Format("{0}{1}Method: {2}", returnValue, Environment.NewLine, request.Method);
            returnValue = string.Format("{0}{1}{2}", returnValue, Environment.NewLine,
                                        request.Headers.ToString().TrimEnd(new[] {'\n', '\r'}));
            if (!string.IsNullOrEmpty(postData))
            {
                returnValue = string.Format("{0}{1}Request Body: {2}", returnValue, Environment.NewLine, postData);
            }
            returnValue = string.Format("{0}{1}PreAuthenticate: {2}", returnValue, Environment.NewLine,
                                        request.PreAuthenticate);
            returnValue = string.Format("{0}{1}Username: {2}%{3}", returnValue, Environment.NewLine,
                                        credentialsDetails.Key, credentialsDetails.User);

            var fuscatedPassword = credentialsDetails.Password;
            for (var i = 0; i < fuscatedPassword.Length; i++)
            {
                fuscatedPassword = fuscatedPassword.Replace(fuscatedPassword.Substring(i, 1), "*");
            }

            returnValue = string.Format("{0}{1}Password: {2}", returnValue, Environment.NewLine, fuscatedPassword);

            return returnValue;
        }

        #endregion
    }

    #endregion
}
