// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceIfIndexerStep_should.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Tests.Steps.Conditional
{
    #region Using Directives

    using Mocklis.Steps.Stored;
    using Mocklis.Tests.Interfaces;
    using Mocklis.Tests.Mocks;
    using Mocklis.Verification;
    using Xunit;

    #endregion

    public class InstanceIfIndexerStep_should
    {
        public MockMembers MockMembers { get; } = new MockMembers();
        public IIndexers Sut => MockMembers;
        public IProperties Props => MockMembers;

        [Fact]
        public void check_get_conditions()
        {
            MockMembers.BoolProperty.Stored();
            StoredAsDictionaryIndexerStep<int, string> indexerStore = null;
            MockMembers.Item.InstanceIf((inst, i) => ((IProperties)inst).BoolProperty, null, s => s.StoredAsDictionary(out indexerStore)).Dummy();

            indexerStore[1] = "one";
            indexerStore[3] = "three";

            var v1 = Sut[1];
            Props.BoolProperty = true;
            var v3 = Sut[3];

            Assert.Null(v1);
            Assert.Equal("three", v3);
        }

        [Fact]
        public void check_set_conditions()
        {
            MockMembers.BoolProperty.Stored();
            StoredAsDictionaryIndexerStep<int, string> indexerStore = null;
            MockMembers.Item.InstanceIf(null, (inst, i, v) => ((IProperties)inst).BoolProperty, s => s.StoredAsDictionary(out indexerStore)).Dummy();

            Sut[1] = "one";
            Props.BoolProperty = true;
            Sut[3] = "three";

            Assert.Null(indexerStore[1]);
            Assert.Equal("three", indexerStore[3]);
        }

        [Fact]
        public void use_ElseBranch_if_asked()
        {
            var vg = new VerificationGroup();
            MockMembers.Item
                .InstanceIf((inst, i) => true, (inst, i, v) => true, s => s.ExpectedUsage(vg, "IfBranch", 1, 1).Join(s.ElseBranch))
                .ExpectedUsage(vg, "ElseBranch", 1, 1).Dummy();

            Sut[1] = "one";
            var _ = Sut[1];

            vg.Assert();
        }
    }
}