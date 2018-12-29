// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventStepWithNext.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core
{
    #region Using Directives

    using System;
    using Mocklis.Steps.Missing;

    #endregion

    public class EventStepWithNext<THandler> : IEventStep<THandler>, ICanHaveNextEventStep<THandler> where THandler : Delegate
    {
        protected IEventStep<THandler> NextStep { get; private set; } = MissingEventStep<THandler>.Instance;

        TStep ICanHaveNextEventStep<THandler>.SetNextStep<TStep>(TStep step)
        {
            if (step == null)
            {
                throw new ArgumentNullException(nameof(step));
            }

            NextStep = step;
            return step;
        }

        public virtual void Add(IMockInfo mockInfo, THandler value)
        {
            NextStep.Add(mockInfo, value);
        }

        public virtual void Remove(IMockInfo mockInfo, THandler value)
        {
            NextStep.Remove(mockInfo, value);
        }
    }
}