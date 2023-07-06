using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aveva.Core.PMLNet;

namespace PMLNet_2
{
    [PMLNetCallable()]
    public class MyPMLNet
    {
        [PMLNetCallable()]
        public string VarString { get; set; }

        [PMLNetCallable()]
        public MyPMLNet()
        { }

        [PMLNetCallable()]
        public void Assign(MyPMLNet that)
        { }

        // Only double type is responding to Real Type in PML
        [PMLNetCallable()]
        public double DoubleSum( double p , double q )
        {   
            return ( p + q );
        }

        // Method Overloading
        // Transfer Array from PML to C#. Array of PML will be converted into Hashtable 
        [PMLNetCallable()]
        public double DoubleSum(Hashtable items)
        {   
            double Sum = 0;
            foreach (DictionaryEntry entity in items)
            {
                Sum += (double)entity.Value;
            }
            return (Sum);
        }

        // It's returning Array in PML
        [PMLNetCallable()]
        public Hashtable IndexHashtable(Hashtable items)
        {   
            Hashtable indexHashtable = new Hashtable();
            int index = 1;
            foreach (DictionaryEntry entity in items)
            {
                indexHashtable[index] = (double)entity.Key;
                index += 1;
            }
            return (indexHashtable);
        }

        // It's possible to directly change the variable from the memory location of variable
        [PMLNetCallable()]
        public void ReplaceHashtable(ref Hashtable items)
        {   
            Hashtable indexHashtable = new Hashtable();
            int index = 1;
            foreach (DictionaryEntry entity in items)
            {
                indexHashtable[index] = (double)entity.Key;
                index += 1;
            }
            items = indexHashtable;
        }

        // Pass the String from PML to C#
        [PMLNetCallable()]
        public string MyString(string text)
        {
            return text;
        }

        // Pass the Bool from PML to C#
        [PMLNetCallable()]
        public bool MyBool(bool value)
        {
            return value;
        }

        // Pass the C# object from PML to C#
        [PMLNetCallable()]
        public void ShowMsgBox(ShowMessageBox messageBox)
        {
            messageBox.ShowMsgBox();
        }

    }
}
