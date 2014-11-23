using System;
using System.Collections.Generic;

namespace NTmdb
{
    /// <summary>
    ///     Class containing a bunch of filter for the TMDb's discover method.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
    /// </remarks>
    public class DisoveryFilter
    {
        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether adult movies should get include or not.
        /// </summary>
        /// <remarks>
        ///     include_adult			Toggle the inclusion of adult titles. Expected value is a Boolean, true or false
        /// </remarks>
        /// <value>A value indicating whether adult movies should get include or not.</value>
        public Boolean? IncludeAdult { get; set; }

        /// <summary>
        ///     Gets or sets the year filter of the release date.
        /// </summary>
        /// <remarks>
        ///     year					Filter the ChangedEntries release dates to matches that include this value. Expected value is a year.
        /// </remarks>
        /// <value>The year filter of the release date.</value>
        public Int32? Year { get; set; }

        /// <summary>
        ///     Gets or sets the minimum vote count filter.
        /// </summary>
        /// <remarks>
        ///     vote_count.gte			Only include movies that are equal to, or have a vote count higher than this value. Expected value is an integer.
        /// </remarks>
        /// <value>The minimum vote count filter.</value>
        public Int32? MinimumVoteCount { get; set; }

        /// <summary>
        ///     Gets or sets the minimum vote average filter.
        /// </summary>
        /// <remarks>
        ///     vote_average.gte		Only include movies that are equal to, or have a higher average rating than this value.
        /// </remarks>
        /// <value>The minimum vote average filter.</value>
        public Double? MinimumAverageVotet { get; set; }

        /// <summary>
        ///     Gets or sets the primary release year filter.
        /// </summary>
        /// <remarks>
        ///     primary_release_year	Filter the ChangedEntries so that only the primary release date year has this value. Expected value is a year.
        /// </remarks>
        /// <value>The  primary release year filter.</value>
        public Int32? PrimaryReleaseYear { get; set; }

        /// <summary>
        ///     Gets or sets the minimum release date filter.
        /// </summary>
        /// <remarks>
        ///     release_date.gte		The minimum release to include. Expected format is YYYY-MM-DD.
        /// </remarks>
        /// <value>The minimum release date filter.</value>
        public DateTime? MinimumReleaseDate { get; set; }

        /// <summary>
        ///     Gets or sets the maximum release date filter.
        /// </summary>
        /// <remarks>
        ///     release_date.lte		The maximum release to include. Expected format is YYYY-MM-DD.
        /// </remarks>
        /// <value>The maximum release date filter.</value>
        public DateTime? MaximumReleaseDate { get; set; }

        /// <summary>
        ///     Gets or sets the maximum certification filter.
        /// </summary>
        /// <remarks>
        ///     certification.lte		Only include movies with this certification and lower. Expected value is a valid certification for the specificed 'certification_country'.
        /// </remarks>
        /// <value>The maximum certification filter.</value>
        public String MaximumCertification { get; set; }

        /// <summary>
        ///     Gets or sets the certification country filter.
        /// </summary>
        /// <remarks>
        ///     certification_country	Only include movies with certifications for a specific country. When this value is specified, 'certification.lte' is required. A ISO 3166-1 is expected.
        /// </remarks>
        /// <value>The certification country filter.</value>
        public String CertificationCountry { get; set; }

        /// <summary>
        ///     Gets the companies filter.
        /// </summary>
        /// <remarks>
        ///     with_companies			Filter movies to include a specific company. Expected value is an integer (the id of a company). They can be comma separated to indicate an 'AND' query.
        /// </remarks>
        /// <value>he companies filter.</value>
        public List<Int32> Companies { get; set; }

        /// <summary>
        ///     Gets or sets the sort by filter.
        /// </summary>
        /// <remarks>
        ///     sort_by					Available options are vote_average.desc, vote_average.asc, release_date.desc, release_date.asc, popularity.desc, popularity.asc
        /// </remarks>
        /// <value>The sort by filter.</value>
        public TmdbDiscoverySortBy SortBy { get; set; }

        /// <summary>
        ///     Gets or sets the genre filter.
        /// </summary>
        /// <remarks>
        ///     with_genres				Only include movies with the specified genres. Expected value is an integer (the id of a genre).
        ///     Multiple values can be specified.
        ///     Comma separated indicates an 'AND' query, while a pipe (|) separated value indicates an 'OR'.
        /// </remarks>
        /// <value>The genre filter.</value>
        public GenreFilter GenreFilter { get; set; }

        #endregion Properties

        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="DisoveryFilter" /> class.
        /// </summary>
        public DisoveryFilter()
        {
            Companies = new List<Int32>();
            SortBy = TmdbDiscoverySortBy.None;
            GenreFilter = new GenreFilter();
        }

        #endregion Ctor
    }
}