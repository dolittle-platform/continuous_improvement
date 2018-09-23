/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Infrastructure.Orchestrations
{
    /// <summary>
    /// Represents a step in a <see cref="ScoreOf{T}"/>
    /// </summary>
    public class Step
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Step"/>
        /// </summary>
        /// <param name="type"><see cref="Type"/> of <see cref="IPerformer{T}"/></param>
        /// <param name="configuration">Configuration object instance, if any - can be null</param>
        public Step(Type type, object configuration = null)
        {
            Type = type;
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> of <see cref="IPerformer{T}"/>
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Gets the configuration - if any
        /// </summary>
        public object Configuration { get; }
    }
}