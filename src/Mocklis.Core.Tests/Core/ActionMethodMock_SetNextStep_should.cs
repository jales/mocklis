// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionMethodMock_SetNextStep_should.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core.Tests.Core
{
    #region Using Directives

    using System;
    using Mocklis.Core.Tests.Mocks;
    using Xunit;

    #endregion

    public class ActionMethodMock_SetNextStep_should
    {
        private readonly ActionMethodMock _parameterLessActionMock;
        private readonly ActionMethodMock<int> _actionMock;

        public ActionMethodMock_SetNextStep_should()
        {
            _parameterLessActionMock = new ActionMethodMock(new object(), "ClassName", "InterfaceName", "MemberName", "MockName");
            _actionMock = new ActionMethodMock<int>(new object(), "ClassName", "InterfaceName", "MemberName", "MockName");
        }

        [Fact]
        public void require_step()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                _actionMock.SetNextStep((IMethodStep<int, ValueTuple>)null));
            Assert.Equal("step", exception.ParamName);
        }

        [Fact]
        public void return_new_step()
        {
            var newStep = new MockMethodStep<int, ValueTuple>();
            var returnedStep = _actionMock.SetNextStep(newStep);
            Assert.Same(newStep, returnedStep);
        }

        [Fact(DisplayName = "set step used by call (parameterless)")]
        public void set_step_used_by_call_X28parameterlessX29()
        {
            bool called = false;
            var newStep = new MockMethodStep<ValueTuple, ValueTuple>();

            newStep.Call.Action(_ => { called = true; });
            _parameterLessActionMock.SetNextStep(newStep);
            _parameterLessActionMock.Call();
            Assert.True(called);
        }

        [Fact]
        public void set_step_used_by_call()
        {
            bool called = false;
            var newStep = new MockMethodStep<int, ValueTuple>();
            newStep.Call.Action(_ => called = true);
            _actionMock.SetNextStep(newStep);
            _actionMock.Call(5);
            Assert.True(called);
        }
    }
}