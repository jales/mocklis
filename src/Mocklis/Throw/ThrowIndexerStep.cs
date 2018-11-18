// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThrowIndexerStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Throw
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    public class ThrowIndexerStep<TKey, TValue> : IIndexerStep<TKey, TValue>
    {
        private readonly Func<TKey, Exception> _exceptionFactory;

        public ThrowIndexerStep(Func<TKey, Exception> exceptionFactory)
        {
            _exceptionFactory = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));
        }

        public TValue Get(object instance, MemberMock memberMock, TKey key)
        {
            throw _exceptionFactory(key);
        }

        public void Set(object instance, MemberMock memberMock, TKey key, TValue value)
        {
            throw _exceptionFactory(key);
        }
    }
}
