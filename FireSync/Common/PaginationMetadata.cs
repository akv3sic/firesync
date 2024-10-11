namespace FireSync.Common
{
    /// <summary>
    /// Represents the pagination metadata.
    /// </summary>
    public class PaginationMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationMetadata"/> class.
        /// </summary>
        /// <param name="totalItemCount">The total number of items in the paginated list.</param>
        /// <param name="pageSize">The maximum number of items to display on each page.</param>
        /// <param name="currentPage">The current page number.</param>
        public PaginationMetadata(int totalItemCount, int pageSize, int currentPage)
        {
            this.TotalItemCount = totalItemCount;
            this.PageSize = pageSize;
            this.CurrentPage = currentPage;
            this.TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }

        /// <summary>
        /// Gets or sets the total number of items in the collection.
        /// </summary>
        public int TotalItemCount { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages in the collection.
        /// </summary>
        public int TotalPageCount { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage { get; set; }
    }
}