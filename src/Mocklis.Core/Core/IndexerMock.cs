// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndexerMock.cs">
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core
{
    #region Using Directives

    using System;
    using Mocklis.Steps.Missing;

    #endregion

    /// <summary>
    ///     Class that represents a mock of an indexer of a given type. This class cannot be inherited.
    ///     Inherits from the <see cref="Mocklis.Core.MemberMock" /> class.
    ///     Implements the <see cref="Mocklis.Core.ICanHaveNextIndexerStep{TKey, TValue}" /> interface.
    /// </summary>
    /// <typeparam name="TKey">The type of the indexer key.</typeparam>
    /// <typeparam name="TValue">The type of the indexer value.</typeparam>
    /// <seealso cref="Mocklis.Core.MemberMock" />
    /// <seealso cref="Mocklis.Core.ICanHaveNextIndexerStep{TKey, TValue}" />
    public sealed class IndexerMock<TKey, TValue> : MemberMock, ICanHaveNextIndexerStep<TKey, TValue>
    {
        private IIndexerStep<TKey, TValue> _nextStep = MissingIndexerStep<TKey, TValue>.Instance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="IndexerMock{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="mockInstance">The instance of the mocklis class through with the mocked member is accessed.</param>
        /// <param name="mocklisClassName">The name of the mocklis class.</param>
        /// <param name="interfaceName">The name of the interface on which the mocked member is defined.</param>
        /// <param name="memberName">The name of the mocked member.</param>
        /// <param name="memberMockName">The name of the property or method used to provide the mocked member with behaviour.</param>
        public IndexerMock(object mockInstance, string mocklisClassName, string interfaceName, string memberName, string memberMockName)
            : base(mockInstance, mocklisClassName, interfaceName, memberName, memberMockName)
        {
        }

        /// <summary>
        ///     Replaces the current 'next' step with a new step.
        /// </summary>
        /// <typeparam name="TStep">The actual type of the new step.</typeparam>
        /// <param name="step">The new step.</param>
        /// <returns>The new step, so that we can add further steps in a fluent fashion.</returns>
        TStep ICanHaveNextIndexerStep<TKey, TValue>.SetNextStep<TStep>(TStep step)
        {
            if (step == null)
            {
                throw new ArgumentNullException(nameof(step));
            }

            _nextStep = step;
            return step;
        }

        /// <summary>
        ///     Gets or sets the <typeparamref name="TValue" /> with the specified key on the mocked indexer.
        /// </summary>
        /// <param name="key">The indexer key used.</param>
        /// <returns>The value being read or written.</returns>
        public TValue this[TKey key]
        {
            get => _nextStep.Get(this, key);
            set => _nextStep.Set(this, key, value);
        }
    }
}
