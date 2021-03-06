﻿
/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 * --------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Machine.Specifications.Events;
using Events.Improvements;
using Machine.Specifications;
using Domain.Improvements;

namespace Domain.Specs.for_Improvement.when_completing_an_improvement
{
    public class and_the_improvement_has_not_been_initiated : given.an_uninitiated_improvement
    {
        static Exception exception;
        Because of = () => exception = Catch.Exception(() => improvement.Complete());

        It should_not_complete_the_improvement = () => improvement.ShouldHaveAnEmptyStream();
        It should_indicate_that_the_improvement_has_not_been_initiatied = () => exception.ShouldBeOfExactType<ImprovementNotInitiated>();
    }
}