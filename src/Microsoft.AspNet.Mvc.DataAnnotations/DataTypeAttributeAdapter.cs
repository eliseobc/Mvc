// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace Microsoft.AspNet.Mvc.ModelBinding.Validation
{
    /// <summary>
    /// A validation adapter that is used to map <see cref="DataTypeAttribute"/>'s to a single client side validation
    /// rule.
    /// </summary>
    public class DataTypeAttributeAdapter : AttributeAdapterBase<DataTypeAttribute>
    {
        public DataTypeAttributeAdapter(DataTypeAttribute attribute, string ruleName, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
            if (string.IsNullOrEmpty(ruleName))
            {
                throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, nameof(ruleName));
            }

            RuleName = ruleName;
        }

        public string RuleName { get; }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes.Add(RuleName, GetErrorMessage(context));

            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }
        }

        /// <inheritdoc/>
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            return GetErrorMessage(
                validationContext.ModelMetadata,
                validationContext.ModelMetadata.GetDisplayName(),
                Attribute.GetDataTypeName());
        }
    }
}
