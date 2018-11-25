// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnlySetIfChangedIndexerStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Conditional
{
    #region Using Directives

    using System.Collections.Generic;
    using Mocklis.Core;

    #endregion

    public class OnlySetIfChangedIndexerStep<TKey, TValue> : MedialIndexerStep<TKey, TValue>
    {
        private IEqualityComparer<TValue> Comparer { get; }

        public OnlySetIfChangedIndexerStep(IEqualityComparer<TValue> comparer = null)
        {
            Comparer = comparer ?? EqualityComparer<TValue>.Default;
        }

        public override void Set(IMockInfo mockInfo, TKey key, TValue value)
        {
            if (!Comparer.Equals(NextStep.Get(mockInfo, key), value))
            {
                base.Set(mockInfo, key, value);
            }
        }
    }
}
