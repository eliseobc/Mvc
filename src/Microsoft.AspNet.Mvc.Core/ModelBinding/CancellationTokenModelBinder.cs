// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Mvc.ModelBinding
{
    /// <summary>
    /// <see cref="IModelBinder"/> implementation to bind models of type <see cref="CancellationToken"/>.
    /// </summary>
    public class CancellationTokenModelBinder : IModelBinder
    {
        /// <inheritdoc />
        public Task BindModelAsync(IModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            Debug.Assert(bindingContext.Result == null);

            if (bindingContext.ModelType == typeof(CancellationToken))
            {
                var model = bindingContext.OperationBindingContext.HttpContext.RequestAborted;
                bindingContext.Result = ModelBindingResult.Success(bindingContext.ModelName, model);
            }

            return Internal.TaskCache.CompletedTask;
        }
    }
}
