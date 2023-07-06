using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aveva.Core.PMLNet;

namespace PMLNet_2
{
    [PMLNetCallable()]
    public class ShowMessageBox
    {
        [PMLNetCallable()]
        public bool Show { get; set; }

        [PMLNetCallable()]
        public ShowMessageBox()
        { }

        [PMLNetCallable()]
        public void Assign(ShowMessageBox that)
        { }

        public void ShowMsgBox()
        { 
            if (Show == true)
            {
                MessageBox.Show("Hiiii");
            }
        }

    }

}
