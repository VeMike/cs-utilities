﻿// ===================================================================================================
// = Author      :  Mike
// = Created     :  2020-01-11 23:53
// ===================================================================================================
// = Description :
// ===================================================================================================

using System;
using System.Reflection;
using Toolbox.CommandLineMapper.Specification;

namespace Toolbox.CommandLineMapper.Core.Wrappers
{
    /// <summary>
    ///     An implementation of <see cref="IAssignableProperty{TAttribute}"/> that
    ///     assigns properties of type <see cref="short"/>
    /// </summary>
    internal class ShortAssignableProperty<TAttribute> : AssignablePropertyBase<TAttribute> where TAttribute : AttributeBase
    {
        /// <inheritdoc />
        public ShortAssignableProperty(object owner,
                                       PropertyInfo property,
                                       TAttribute attribute) : base(owner, 
                                                                    property, 
                                                                    attribute)
        {
        }

        /// <inheritdoc />
        /// <exception cref="InvalidCastException">
        ///     Thrown  if the <see cref="value"/> can not be cast to <see cref="short"/>
        /// </exception>
        protected override object Convert(string value)
        {
            if (string.IsNullOrEmpty(value))
                return default(short);
            
            if (short.TryParse(value, out var shortValue))
            {
                return shortValue;
            }

            throw new InvalidCastException($"Can not cast '{value}' to 'short'");
        }
    }
}