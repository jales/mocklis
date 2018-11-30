// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceFuncPropertyStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Lambda
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    public class InstanceFuncPropertyStep<TValue> : MedialPropertyStep<TValue>
    {
        private readonly Func<object, TValue> _func;

        public InstanceFuncPropertyStep(Func<object, TValue> func)
        {
            _func = func;
        }

        public override TValue Get(IMockInfo mockInfo)
        {
            return _func(mockInfo.MockInstance);
        }
    }
}
