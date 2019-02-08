using System;
using Mocklis.Core;

namespace Test
{
    public interface ITestClass
    {
        int GetAndSet { get; set; }
        int SetOnly { set; }
        int GetOnly { get; }
    }

    [MocklisClass]
    public class TestClass : ITestClass
    {
        public TestClass()
        {
            GetAndSet = new PropertyMock<int>(this, "TestClass", "ITestClass", "GetAndSet", "GetAndSet");
            SetOnly = new PropertyMock<int>(this, "TestClass", "ITestClass", "SetOnly", "SetOnly");
            GetOnly = new PropertyMock<int>(this, "TestClass", "ITestClass", "GetOnly", "GetOnly");
        }

        public PropertyMock<int> GetAndSet { get; }
        int ITestClass.GetAndSet { get => GetAndSet.Value; set => GetAndSet.Value = value; }
        public PropertyMock<int> SetOnly { get; }
        int ITestClass.SetOnly { set => SetOnly.Value = value; }
        public PropertyMock<int> GetOnly { get; }

        int ITestClass.GetOnly => GetOnly.Value;
    }
}