/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace Policies.Notifications.Teams
{
    #pragma warning disable 1591
    public class Facts : Section
    {
        public string title;
        public IEnumerable<Fact> facts;
    }
}