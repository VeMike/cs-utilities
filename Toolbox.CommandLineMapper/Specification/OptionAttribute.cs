﻿// ===================================================================================================
// = Author      :  Mike
// = Created     :  2020-01-11 18:41
// ===================================================================================================
// = Description :
// ===================================================================================================


using System;
using System.Linq;
using Toolbox.Utils.Probing;

namespace Toolbox.CommandLineMapper.Specification
{
    /// <summary>
    ///     Defines a command line option
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class OptionAttribute : AttributeBase
    {
        #region Constructor

        /// <summary>
        ///     Creates a new instance of the class
        /// </summary>
        /// <param name="longName">
        ///     The long name of the option consisting of a
        ///     single word.
        /// </param>
        public OptionAttribute(string longName) : this(longName.First().ToString(), longName)
        {

        }

        /// <summary>
        ///     Creates a new instance of the class
        /// </summary>
        /// <param name="shortName">
        ///     The short name of the option consisting of
        ///     a single character
        /// </param>
        public OptionAttribute(char shortName) : this(shortName.ToString(), string.Empty)
        {

        }

        /// <summary>
        ///     Creates a new instance of the class
        /// </summary>
        /// <param name="shortName">
        ///     The short name of the option consisting of
        ///     a single character
        /// </param>
        /// <param name="longName">
        ///     The long name of the option consisting of a
        ///     single word.
        /// </param>
        public OptionAttribute(string shortName, string longName)
        {
            Guard.AgainstNullArgument(nameof(shortName), shortName);
            Guard.AgainstNullArgument(nameof(longName), longName);

            this.ShortName = shortName;
            this.LongName = longName;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Indicates if the option is specified with a
        ///     value or just 'standalone'.
        ///
        ///     e.g.:
        ///     - myapp.exe -file name.txt (option 'file' with value 'name.txt')
        ///     - myapp.exe -verbose ('standalone' with no additional value)
        /// 
        /// </summary>
        public bool HasValue { get; set; } = true;

        #endregion

        #region ToString

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(this.HasValue)}: {this.HasValue}";
        }

        #endregion

    }
}