using System;
using System.CodeDom.Compiler;
using Mocklis.Core;

namespace Test
{
    public ref struct RefStruct
    {
        public int Test { get; set;}
    }

    public interface ITestClass
    {
        void RefStructIn(in RefStruct parameter);
        void RefStructOut(out RefStruct parameter);
        void RefStructRef(ref RefStruct parameter);
    }

    [MocklisClass, GeneratedCode("Mocklis", "[VERSION]")]
    public class TestClass : ITestClass
    {
        // The contents of this class were created by the Mocklis code-generator.
        // Any changes you make will be overwritten if the contents are re-generated.

        protected virtual void RefStructIn(in RefStruct parameter)
        {
            throw new MockMissingException(MockType.VirtualMethod, "TestClass", "ITestClass", "RefStructIn", "RefStructIn");
        }

        void ITestClass.RefStructIn(in RefStruct parameter) => RefStructIn(parameter);

        protected virtual void RefStructOut(out RefStruct parameter)
        {
            throw new MockMissingException(MockType.VirtualMethod, "TestClass", "ITestClass", "RefStructOut", "RefStructOut");
        }

        void ITestClass.RefStructOut(out RefStruct parameter) => RefStructOut(out parameter);

        protected virtual void RefStructRef(ref RefStruct parameter)
        {
            throw new MockMissingException(MockType.VirtualMethod, "TestClass", "ITestClass", "RefStructRef", "RefStructRef");
        }

        void ITestClass.RefStructRef(ref RefStruct parameter) => RefStructRef(ref parameter);
    }
}
