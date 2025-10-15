using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aveva.Core.PMLNet;

namespace PMLNet_5
{
    [PMLNetCallable()]
    public class MyPMLNet
    {
        [PMLNetCallable()]
        public MyPMLNet()
        { }

        [PMLNetCallable()]
        public void Assign(MyPMLNet that)
        { }

        [PMLNetCallable()]
        public void TestHashTableFromObject()
        {
            var PmlObject = PMLNetAny.createInstance("PMLOBJECT", new object[] { }, 0, true);

            object pmlArrayObject = new Hashtable();
            PmlObject.invokeMethod("getArray", new object[] { "myArrayPrinting" }, 1, ref pmlArrayObject, true, true);

            var scopeElements = new Hashtable();
            scopeElements.Add(1, "/TEST-ISO-OPS");

            object pmlNullObject = new object();
            PmlObject.invokeMethod("setArray", new object[] { scopeElements }, 1, ref pmlNullObject, true, true);
        }
    }
}
