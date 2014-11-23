using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the image section of the TMDb configuration.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#configuration
    /// </remarks>
    public class TmdbImageConfiguration : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the base URL of all images.
        /// </summary>
        /// <value>The base URL of all images.</value>
        [JsonProperty( PropertyName = "base_url" )]
        public String BaseUrl { get; set; }

        /// <summary>
        ///     Gets or sets the https base URL of all images.
        /// </summary>
        /// <value>The https base URL of all images.</value>
        [JsonProperty( PropertyName = "secure_base_url" )]
        public String SecureBaseUrl { get; set; }

        /// <summary>
        ///     Gets or sets a list of all poster sizes.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013) the smallest size is at the begin and the biggest size is at the end of the list.
        /// </remarks>
        /// <value>A list of all poster sizes.</value>
        [JsonProperty( PropertyName = "poster_sizes" )]
        public List<String> PosterSizes { get; set; }

        /// <summary>
        ///     Gets or sets a list of all backdrop sizes.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013) the smallest size is at the begin and the biggest size is at the end of the list.
        /// </remarks>
        /// <value>A list of all backdrop sizes.</value>
        [JsonProperty( PropertyName = "backdrop_sizes" )]
        public List<String> BackdropSizes { get; set; }

        /// <summary>
        ///     Gets or sets a list of all profile image sizes.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013) the smallest size is at the begin and the biggest size is at the end of the list.
        /// </remarks>
        /// <value>A list of all profile image sizes.</value>
        [JsonProperty( PropertyName = "profile_sizes" )]
        public List<String> ProfileSizes { get; set; }

        /// <summary>
        ///     Gets or sets a list of all logo sizes.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013) the smallest size is at the begin and the biggest size is at the end of the list.
        /// </remarks>
        /// <value>A list of all logo sizes.</value>
        [JsonProperty( PropertyName = "logo_sizes" )]
        public List<String> LogoSizes { get; set; }
    }
}