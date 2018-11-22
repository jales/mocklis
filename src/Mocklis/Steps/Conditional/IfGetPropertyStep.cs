// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IfGetPropertyStep.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Steps.Conditional
{
    #region Using Directives

    using System;
    using Mocklis.Core;

    #endregion

    public class IfGetPropertyStep<TValue> : IfPropertyStepBase<TValue>
    {
        public IfGetPropertyStep(Action<IfBranchCaller> branch) : base(branch)
        {
        }

        public override TValue Get(object instance, MemberMock memberMock)
        {
            return IfBranch.Get(instance, memberMock);
        }
    }
}