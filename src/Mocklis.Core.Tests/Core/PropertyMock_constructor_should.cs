// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyMock_constructor_should.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Core.Tests.Core
{
    #region Using Directives

    using System;
    using Xunit;

    #endregion

    public class PropertyMock_constructor_should
    {
        [Fact]
        public void require_mockInstance()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new PropertyMock<int>(null, "MocklisClassName", "InterfaceName", "MemberName", "MemberMockName"));
            Assert.Equal("mockInstance", exception.ParamName);
        }

        [Fact]
        public void require_mocklisClassName()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new PropertyMock<int>(new object(), null, "InterfaceName", "MemberName", "MemberMockName"));
            Assert.Equal("mocklisClassName", exception.ParamName);
        }

        [Fact]
        public void require_interfaceName()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new PropertyMock<int>(new object(), "MocklisClassName", null, "MemberName", "MemberMockName"));
            Assert.Equal("interfaceName", exception.ParamName);
        }

        [Fact]
        public void require_memberName()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new PropertyMock<int>(new object(), "MocklisClassName", "InterfaceName", null, "MemberMockName"));
            Assert.Equal("memberName", exception.ParamName);
        }

        [Fact]
        public void require_memberMockName()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new PropertyMock<int>(new object(), "MocklisClassName", "InterfaceName", "MemberName", null));
            Assert.Equal("memberMockName", exception.ParamName);
        }

        [Fact]
        public void set_IMockInfo_properties()
        {
            var mockInstance = new object();
            var mockInfo = (IMockInfo)new PropertyMock<int>(mockInstance, "MocklisClassName", "InterfaceName", "MemberName", "MemberMockName");
            Assert.Equal(mockInstance, mockInfo.MockInstance);
            Assert.Equal("MocklisClassName", mockInfo.MocklisClassName);
            Assert.Equal("InterfaceName", mockInfo.InterfaceName);
            Assert.Equal("MemberName", mockInfo.MemberName);
            Assert.Equal("MemberMockName", mockInfo.MemberMockName);
        }
    }
}
