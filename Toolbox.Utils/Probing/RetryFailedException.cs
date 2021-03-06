﻿using System;

namespace Toolbox.Utils.Probing
{
    /// <summary>
    ///     The <see cref="Exception"/>, that is thrown, whenever
    ///     the <see cref="Retry"/>-Mechanism has finished retrying,
    ///     but the operation sill was not successful
    /// </summary>
    public class RetryFailedException : Exception
    {
        #region Constructor
        /// <summary>
        ///     The constructor
        /// </summary>
        /// <param name="message">
        ///     The error message of the exception
        /// </param>
        /// <param name="attempts">
        ///     The number of attempts made before
        ///     the retry mechanism stopped and failed
        /// </param>
        public RetryFailedException(string message, int attempts) : base(message)
        {
            this.Attempts = attempts;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The attempts that were made before the operation
        ///     was considered failed.
        /// </summary>
        public int Attempts { get; } 

        #endregion
    }
}
