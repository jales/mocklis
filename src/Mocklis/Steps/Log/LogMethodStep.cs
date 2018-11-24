// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogMethodStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Log
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    public sealed class LogMethodStep<TParam, TResult> : MedialMethodStep<TParam, TResult>
    {
        private readonly ILogContext _logContext;
        private readonly bool _hasParameters;
        private readonly bool _hasResult;

        public LogMethodStep(ILogContext logContext)
        {
            _logContext = logContext ?? throw new ArgumentNullException(nameof(logContext));
            _hasParameters = typeof(TParam) != typeof(ValueTuple);
            _hasResult = typeof(TResult) != typeof(ValueTuple);
        }

        public override TResult Call(MemberMock memberMock, TParam param)
        {
            if (_hasParameters)
            {
                _logContext.LogBeforeMethodCallWithParameters(memberMock, param);
            }
            else
            {
                _logContext.LogBeforeMethodCallWithoutParameters(memberMock);
            }

            TResult result;

            try
            {
                result = base.Call(memberMock, param);
            }
            catch (Exception exception)
            {
                _logContext.LogMethodCallException(memberMock, exception);
                throw;
            }

            if (_hasResult)
            {
                _logContext.LogAfterMethodCallWithResult(memberMock, result);
            }
            else
            {
                _logContext.LogAfterMethodCallWithoutResult(memberMock);
            }

            return result;
        }
    }
}
