// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.Extensions.Localization;

namespace Microsoft.AspNet.Mvc.ModelBinding.Validation
{
    public class StringLengthAttributeAdapter : AttributeAdapterBase<StringLengthAttribute>
    {
        private readonly string _max;
        private readonly string _min;

        public StringLengthAttributeAdapter(StringLengthAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
            _max = Attribute.MaximumLength.ToString(CultureInfo.InvariantCulture);
            _min = Attribute.MinimumLength.ToString(CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes.Add("data-val-length", GetErrorMessage(context));
            context.Attributes.Add("data-val-length-max", _max);
            context.Attributes.Add("data-val-length-min", _min);

            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }
        }

        /// <inheritdoc />
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            return GetErrorMessage(
                validationContext.ModelMetadata,
                validationContext.ModelMetadata.GetDisplayName(),
                Attribute.MinimumLength,
                Attribute.MaximumLength);
        }
    }
}
