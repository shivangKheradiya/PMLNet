using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aveva.Core.PMLNet;

namespace PMLNet_3
{
    [PMLNetCallable()]
    public class MyPMLNet
    {
        [PMLNetCallable()]
        public string MyProperty { get; set; }

        [PMLNetCallable()]
        public MyPMLNet()
        { }

        // Constructor overloading
        [PMLNetCallable()]
        public MyPMLNet(string myProperty)
        {
            this.MyProperty = myProperty;
        }

        // When we are assigning class to another instance of class will assign all properties to new class
        [PMLNetCallable()]
        public void Assign(MyPMLNet that)
        {
            this.MyProperty = that.MyProperty;
        }

        public override string ToString()
        {
            return ("override MyPMLNet");
        }
    }
}
