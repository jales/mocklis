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
        RefStruct RefStructProperty { get; set; }
        RefStruct ReadOnlyProperty { get; }
        RefStruct WriteOnlyProperty { set; }
        ref RefStruct RefReadOnlyProperty { get; }
    }

    [MocklisClass, GeneratedCode("Mocklis", "[VERSION]")]
    public class TestClass : ITestClass
    {
        // The contents of this class were created by the Mocklis code-generator.
        // Any changes you make will be overwritten if the contents are re-generated.

        protected virtual RefStruct RefStructProperty()
        {
            throw new MockMissingException(MockType.VirtualPropertyGet, "TestClass", "ITestClass", "RefStructProperty", "RefStructProperty");
        }

        protected virtual void RefStructProperty(RefStruct value)
        {
            throw new MockMissingException(MockType.VirtualPropertySet, "TestClass", "ITestClass", "RefStructProperty", "RefStructProperty");
        }

        RefStruct ITestClass.RefStructProperty { get => RefStructProperty(); set => RefStructProperty(value); }

        protected virtual RefStruct ReadOnlyProperty()
        {
            throw new MockMissingException(MockType.VirtualPropertyGet, "TestClass", "ITestClass", "ReadOnlyProperty", "ReadOnlyProperty");
        }

        RefStruct ITestClass.ReadOnlyProperty => ReadOnlyProperty();

        protected virtual void WriteOnlyProperty(RefStruct value)
        {
            throw new MockMissingException(MockType.VirtualPropertySet, "TestClass", "ITestClass", "WriteOnlyProperty", "WriteOnlyProperty");
        }

        RefStruct ITestClass.WriteOnlyProperty { set => WriteOnlyProperty(value); }

        protected virtual ref RefStruct RefReadOnlyProperty()
        {
            throw new MockMissingException(MockType.VirtualPropertyGet, "TestClass", "ITestClass", "RefReadOnlyProperty", "RefReadOnlyProperty");
        }

        ref RefStruct ITestClass.RefReadOnlyProperty => ref RefReadOnlyProperty();
    }
}
