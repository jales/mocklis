// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceFuncIndexerStep.cs">
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Lambda
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    /// <summary>
    ///     Class that represents a 'Func' indexer step, where the function can also depend on the current mock instance.
    ///     Inherits from the <see cref="IndexerStepWithNext{TKey,TValue}" /> class.
    /// </summary>
    /// <typeparam name="TKey">The type of the indexer key.</typeparam>
    /// <typeparam name="TValue">The type of the indexer value.</typeparam>
    /// <seealso cref="IndexerStepWithNext{TKey, TValue}" />
    public class InstanceFuncIndexerStep<TKey, TValue> : IndexerStepWithNext<TKey, TValue>
    {
        private readonly Func<object, TKey, TValue> _func;

        /// <summary>
        ///     Initializes a new instance of the <see cref="InstanceFuncIndexerStep{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="func">A function used to create a value when the indexer is read from.</param>
        public InstanceFuncIndexerStep(Func<object, TKey, TValue> func)
        {
            _func = func;
        }

        /// <summary>
        ///     Called when a value is read from the indexer.
        ///     This implementation evaluates the function with the mock instance and indexer key as parameters and returns the
        ///     result.
        /// </summary>
        /// <param name="mockInfo">Information about the mock through which the value is read.</param>
        /// <param name="key">The indexer key used.</param>
        /// <returns>The value being read.</returns>
        public override TValue Get(IMockInfo mockInfo, TKey key)
        {
            return _func(mockInfo.MockInstance, key);
        }
    }
}
