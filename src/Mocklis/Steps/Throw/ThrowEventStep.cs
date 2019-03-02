// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThrowEventStep.cs">
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Throw
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    public class ThrowEventStep<THandler> : IEventStep<THandler> where THandler : Delegate
    {
        private readonly Func<THandler, Exception> _exceptionFactory;

        public ThrowEventStep(Func<THandler, Exception> exceptionFactory)
        {
            _exceptionFactory = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));
        }

        public void Add(IMockInfo mockInfo, THandler value)
        {
            throw _exceptionFactory(value);
        }

        public void Remove(IMockInfo mockInfo, THandler value)
        {
            throw _exceptionFactory(value);
        }
    }
}
