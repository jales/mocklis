// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MedialEventStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core
{
    #region Using Directives

    using System;
    using Mocklis.Steps.Missing;

    #endregion

    public class MedialEventStep<THandler> : IEventStep<THandler>, IEventStepCaller<THandler> where THandler : Delegate
    {
        protected IEventStep<THandler> NextStep { get; private set; } = MissingEventStep<THandler>.Instance;

        public TStep SetNextStep<TStep>(TStep step) where TStep : IEventStep<THandler>
        {
            if (step == null)
            {
                throw new ArgumentNullException(nameof(step));
            }

            NextStep = step;
            return step;
        }

        public virtual void Add(MemberMock memberMock, THandler value)
        {
            NextStep.Add(memberMock, value);
        }

        public virtual void Remove(MemberMock memberMock, THandler value)
        {
            NextStep.Remove(memberMock, value);
        }
    }
}
