// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Mvc.ViewFeatures.Internal
{
    /// <summary>
    /// Creates and manages the lifetime of <see cref="ViewBufferValue[]"/> instances.
    /// </summary>
    public interface IViewBufferScope
    {
        /// <summary>
        /// Gets a <see cref="ViewBufferValue[]"/>.
        /// </summary>
        /// <returns>The <see cref="ViewBufferValue[]"/>.</returns>
        ViewBufferValue[] GetSegment();
    }
}
