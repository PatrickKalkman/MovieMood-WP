using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Base class for a TMDb image object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
    /// </remarks>
    public class TmdbImageBase : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the width of the image.
        /// </summary>
        /// <value>The width of the image.</value>
        [JsonProperty( PropertyName = "width" )]
        public Int32 Width { get; set; }

        /// <summary>
        ///     Gets or sets the height of the image.
        /// </summary>
        /// <value>The height of the image.</value>
        [JsonProperty( PropertyName = "height" )]
        public Int32 Height { get; set; }

        /// <summary>
        ///     Gets or sets the path to the image.
        /// </summary>
        /// <value>The path to the image.</value>
        [JsonProperty( PropertyName = "file_path" )]
        public String FilePath { get; set; }

        /// <summary>
        ///     Gets or sets the ISO 639-1 language code of the image.
        /// </summary>
        /// <value>The ISO 639-1 language code of the image.</value>
        [JsonProperty( PropertyName = "iso_639_1" )]
        public String Iso639_1 { get; set; }

        /// <summary>
        ///     Gets or sets the aspect ratio of the image.
        /// </summary>
        /// <value>The aspect ratio of the image.</value>
        [JsonProperty( PropertyName = "aspect_ratio" )]
        public Double AspectRatio { get; set; }
    }
}