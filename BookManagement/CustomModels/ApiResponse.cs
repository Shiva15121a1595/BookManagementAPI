namespace BookManagement
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Api Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ExcludeFromCodeCoverage]
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the exception raised.
        /// </summary>
        /// <value>
        /// The exception raised.
        /// </value>
        public Exception ExceptionRaised { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        public T Response { get; set; }
    }
}