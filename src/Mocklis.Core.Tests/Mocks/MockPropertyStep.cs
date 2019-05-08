// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockPropertyStep.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core.Tests.Mocks
{
    [MocklisClass]
    public class MockPropertyStep<TValue> : IPropertyStep<TValue>
    {
        public MockPropertyStep()
        {
            Get = new FuncMethodMock<IMockInfo, TValue>(this, "MockPropertyStep", "IPropertyStep", "Get", "Get", Strictness.Lenient);
            Set = new ActionMethodMock<(IMockInfo mockInfo, TValue value)>(this, "MockPropertyStep", "IPropertyStep", "Set", "Set",
                Strictness.Lenient);
        }

        public FuncMethodMock<IMockInfo, TValue> Get { get; }

        TValue IPropertyStep<TValue>.Get(IMockInfo mockInfo) => Get.Call(mockInfo);

        public ActionMethodMock<(IMockInfo mockInfo, TValue value)> Set { get; }

        void IPropertyStep<TValue>.Set(IMockInfo mockInfo, TValue value) => Set.Call((mockInfo, value));
    }
}
