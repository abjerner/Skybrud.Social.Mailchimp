using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mailchimp.Models.Authentication {

    /// <summary>
    /// Class representing the response body of a call to get metadata about the authenticated Mailchimp user.
    /// </summary>
    public class MailchimpMetadata : MailchimpObject {

        #region Properties

        /// <summary>
        /// Gets the data center of the user/account.
        /// </summary>
        public string DataCenter { get; private set; }

        /// <summary>
        /// Gets the role of the user.
        /// </summary>
        public string Role { get; private set; }

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        public string AccountName { get; private set; }

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public MailchimpMetadataLogin Login { get; private set; }

        /// <summary>
        /// Gets the login URL of the account.
        /// </summary>
        public string LoginUrl { get; private set; }

        /// <summary>
        /// Gets the API endpoint of the user or account.
        /// </summary>
        public string ApiEndpoint { get; private set; }

        #endregion

        #region Constructors

        private MailchimpMetadata(JObject obj) : base(obj) {
            DataCenter = obj.GetString("dc");
            AccountName = obj.GetString("accountname");
            Role = obj.GetString("role");
            UserId = obj.GetInt64("user_id");
            Login = obj.GetObject("login", MailchimpMetadataLogin.Parse);
            LoginUrl = obj.GetString("login_url");
            ApiEndpoint = obj.GetString("api_endpoint");
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>MailchimpMetadata</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        public static MailchimpMetadata Parse(JObject obj) {
            return obj == null ? null : new MailchimpMetadata(obj);
        }

    }

}