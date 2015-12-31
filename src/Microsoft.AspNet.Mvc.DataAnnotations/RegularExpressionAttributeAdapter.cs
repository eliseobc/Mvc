// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace Microsoft.AspNet.Mvc.ModelBinding.Validation
{
    public class RegularExpressionAttributeAdapter : AttributeAdapterBase<RegularExpressionAttribute>
    {
        public RegularExpressionAttributeAdapter(RegularExpressionAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes.Add("data-val-regex", GetErrorMessage(context));
            context.Attributes.Add("data-val-regex-pattern", Attribute.Pattern);

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
                Attribute.Pattern);
        }
    }
}
