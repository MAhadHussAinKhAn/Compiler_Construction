using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakWord
{ 
    class Node
    {
        public string ClassPart;
        public string ValuePart;
        public int LineNo;
        public Node NextValueAdd;

        public Node(string a)           
        {
   
            ValuePart = a;
        }

        public Node(string a, string b)        /*constructor Overload*/
        {
            ClassPart = a;
            ValuePart = b;
        }

        public Node(string a,string b,int c)  //constructor Overload
        {
            ClassPart = a;
            ValuePart = b;
            LineNo = c;
           
         
        }

        public string GetValuePart()
        {
            return ValuePart;
        }
        public String GetClassPart()
        {
            return ClassPart;
        }
        public int GetLineNo()
        {
            return LineNo;
        }
        public Node GetNextValAdd()
        {
            return NextValueAdd;
        }
        public Node Increment()
        {
            return NextValueAdd;
        }

        public string DispalyToken()
        {
            string t = "  (  " +ClassPart+ "  |  " + ValuePart +"  |  " + LineNo+ "  )  ";
            return t;
        }

        public string DisplayLink()
        {   
            string v= ValuePart;
            return v;
        }
     
    }
}
