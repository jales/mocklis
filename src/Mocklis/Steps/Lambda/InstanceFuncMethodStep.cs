// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceFuncMethodStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Lambda
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    public class InstanceFuncMethodStep<TParam, TResult> : IMethodStep<TParam, TResult>
    {
        private readonly Func<object, TParam, TResult> _func;

        public InstanceFuncMethodStep(Func<object, TParam, TResult> func)
        {
            _func = func;
        }

        public TResult Call(MemberMock memberMock, TParam param)
        {
            return _func(memberMock.MockInstance, param);
        }
    }

    public class InstanceFuncMethodStep<TResult> : IMethodStep<ValueTuple, TResult>
    {
        private readonly Func<object, TResult> _func;

        public InstanceFuncMethodStep(Func<object, TResult> func)
        {
            _func = func;
        }

        public TResult Call(MemberMock memberMock, ValueTuple param)
        {
            return _func(memberMock.MockInstance);
        }
    }
}
