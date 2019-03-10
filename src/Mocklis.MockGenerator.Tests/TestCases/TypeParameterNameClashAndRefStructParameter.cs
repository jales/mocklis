using System;
using Mocklis.Core;

namespace Test
{
    public ref struct RefStruct
    {
        int Test { get; set;}
    }

    public interface ITestClass<TOuter>
    {
        void Test<T>(RefStruct refStruct, TOuter outer, T parameter);
        void TestWithConstraint<T>(RefStruct refStruct, TOuter outer, T parameter) where T : TOuter;
    }

    [MocklisClass]
    public class TestClass<T> : ITestClass<T>
    {
    }
}