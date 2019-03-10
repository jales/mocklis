using System;
using Mocklis.Core;

namespace Test
{
    public ref struct RefStruct
    {
        public int Test { get; set;}
    }

    public interface ITestClass
    {
        RefStruct ReturnsRefStruct();
    }

    [MocklisClass]
    public class TestClass : ITestClass
    {
    }
}