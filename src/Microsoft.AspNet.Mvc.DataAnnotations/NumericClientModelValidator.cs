// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc.DataAnnotations;

namespace Microsoft.AspNet.Mvc.ModelBinding.Validation
{
    /// <summary>
    /// An implementation of <see cref="IClientModelValidator"/> that provides the rule for validating
    /// numeric types.
    /// </summary>
    public class NumericClientModelValidator : IClientModelValidator
    {
        /// <inheritdoc />
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes.Add("data-val-number", GetErrorMessage(context.ModelMetadata));

            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }
        }

        private string GetErrorMessage(ModelMetadata modelMetadata)
        {
            if (modelMetadata == null)
            {
                throw new ArgumentNullException(nameof(modelMetadata));
            }

            return Resources.FormatNumericClientModelValidator_FieldMustBeNumber(modelMetadata.GetDisplayName());
        }
    }
}
