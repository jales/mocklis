// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockMethodStep.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core.Tests.Mocks
{
    [MocklisClass]
    public class MockMethodStep<TParam, TResult> : IMethodStep<TParam, TResult>
    {
        public MockMethodStep()
        {
            Call = new FuncMethodMock<(IMockInfo mockInfo, TParam param), TResult>(this, "MockMethodStep", "IMethodStep", "Call", "Call",
                Strictness.Lenient);
        }

        public FuncMethodMock<(IMockInfo mockInfo, TParam param), TResult> Call { get; }

        TResult IMethodStep<TParam, TResult>.Call(IMockInfo mockInfo, TParam param) => Call.Call((mockInfo, param));
    }
}
