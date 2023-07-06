using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aveva.Core.PMLNet;

namespace PMLNet_4
{
    [PMLNetCallable()]
    public class MyPMLNet
    {
        public event PMLNetDelegate.PMLNetEventHandler MyPmlNetEvent;

        [PMLNetCallable()]
        public MyPMLNet()
        { }

        [PMLNetCallable()]
        public void Assign(MyPMLNet that)
        { }

        [PMLNetCallable()]
        public void TriggerEvent()
        {
            ArrayList args = new ArrayList();
            args.Add("My Arg 1");
            args.Add("My Arg 2");
            if (MyPmlNetEvent != null)
            {
                MyPmlNetEvent(args);
            }
        }

        [PMLNetCallable()]
        public void ThrowNormalException()
        {
            throw new Exception();
        }

        [PMLNetCallable()]
        public void ThrowPMLNetException()
        {
            throw new PMLNetException( 1000 , 100 , "My Exception" );
        }
    }
}
