using System;
using System.Globalization;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb authentication token.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#authentication
    /// </remarks>
    public class TmdbAuthenticationToken : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the expire data of the authentication token.
        /// </summary>
        /// <value>The  expire data of the authentication token.</value>
        [JsonProperty( PropertyName = "expires_at" )]
        public String ExpiresAtString { get; set; }

        /// <summary>
        ///     Gets or sets the authentication token.
        /// </summary>
        /// <value>The authentication token.</value>
        [JsonProperty( PropertyName = "request_token" )]
        public String Token { get; set; }

        /// <summary>
        ///     Gets or sets whether the token was created successfully.
        /// </summary>
        /// <value>A value indicating whether the token was created successfully.</value>
        [JsonProperty( PropertyName = "success" )]
        public Boolean Success { get; set; }

        /// <summary>
        ///     Gets the expire date of the guest session.
        /// </summary>
        /// <param name="dateTimePattern">The pattern to use for parsing the TMDb's DateTime format.</param>
        /// <returns>The expire date of the guest session, or null if method was not able to pars the TMDb's DateTime format.</returns>
        public DateTime? GetExpireDate( String dateTimePattern )
        {
            try
            {
                return DateTime.ParseExact( ExpiresAtString, dateTimePattern, CultureInfo.InvariantCulture );
            }
            catch ( FormatException )
            {
                return null;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the guest session is expired or not.
        /// </summary>
        /// <param name="dateTimePattern">The pattern to use for parsing the TMDb's DateTime format.</param>
        /// <returns>
        ///     A value of true if the guest session is expired, a value of false if not or null if the <see cref="GetExpireDate" /> method returns null.
        /// </returns>
        public Boolean? GetIsExpired( String dateTimePattern )
        {
            var expireDate = GetExpireDate( dateTimePattern );
            if ( expireDate == null )
                return null;
            return DateTime.UtcNow >= expireDate;
        }
    }
}