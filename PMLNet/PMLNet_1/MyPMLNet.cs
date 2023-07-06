using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aveva.Core.PMLNet;
using System.Windows.Forms;

namespace PMLNet_1
{
    [PMLNetCallable()]
    public class MyPMLNet
    {
        [PMLNetCallable()]
        public MyPMLNet()
        {}

        [PMLNetCallable()]
        public void Assign(MyPMLNet that)
        {}

        [PMLNetCallable()]
        public void Start()
        {
            MessageBox.Show("Hii First MyPmlNet is Working");
        }
    }
}
