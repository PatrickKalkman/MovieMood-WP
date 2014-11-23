using System;
using System.Collections.Generic;

namespace NTmdb
{
    /// <summary>
    ///     Class representing a genre filter for the TMDb's discover method.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
    /// </remarks>
    public class GenreFilter
    {
        #region Properties

        /// <summary>
        ///     Gets a list of genre IDs.
        /// </summary>
        /// <value>A list of genre IDs.</value>
        public List<Int32> Genres { get; set; }

        /// <summary>
        ///     Gets or sets the filter used to aggregate the genre IDs.
        /// </summary>
        /// <remarks>
        ///     Default is Or.
        /// </remarks>
        /// <value>The filter used to aggregate the genre IDs.</value>
        public TmdbFilterOperator Operator { get; set; }

        #endregion Properties

        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="GenreFilter" /> class.
        /// </summary>
        public GenreFilter()
        {
            Genres = new List<int>();
            Operator = TmdbFilterOperator.Or;
        }

        #endregion Ctor
    }
}