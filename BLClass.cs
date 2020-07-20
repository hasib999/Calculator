using System;
using System.Collections;
using System.Text;

namespace WPFCalculator
{
    public class BLClass
    {
        Calculator calc = new Calculator();
        DBHandler db = new DBHandler();
        public BLClass()
        {
        }

        public string DoThingFromDB()
        {
            //get all operations from DB
            ArrayList listofoperations = db.getAllOperations();
            StringBuilder str = new StringBuilder();
            for(int i=0; i< listofoperations.Count; i++)
            {
                Operation op = (Operation)listofoperations[i];
                int result = this.Operate(op.num1, op.num2, op.op);
                str.Append(op.num1 + op.op + op.num2 + "=" + result + Environment.NewLine);
            }
            return str.ToString();
        }

        public int Operate(int num1, int num2, string op)
        {
            int result = 0;
            if("+".Equals(op))
            {
                result = calc.add(num1, num2);
            }
            //the rest of the checks for ops
            //yo will also have to add exception for division by 0
            return result;
        }

    }
}