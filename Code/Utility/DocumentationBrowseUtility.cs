namespace Utility
{

    #region ~Class Implementation~

    public static class DocumentationBrowseUtility
    {
        /// <summary>
        /// Starts the browser at the specified URL
        /// </summary>
        /// <param name="webAddress">The Constant Contact API URL</param>
        public static void Start(string webAddress)
        {
            System.Diagnostics.Process.Start(webAddress);
        }
    }

    #endregion
}
