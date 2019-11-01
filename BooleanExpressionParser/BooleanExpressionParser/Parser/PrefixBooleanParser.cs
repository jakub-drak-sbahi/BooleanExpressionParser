using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB5B
{
    class PrefixBooleanParser
    {
        private string[] exp_str;
        int ind = -1;
        public IBooleanExpression Parse(string prefix_expression)
        {
            exp_str = prefix_expression.Split(new char[] { ' ' });
            ind = -1;
            IBooleanExpression ret = MyParse();

            if (ind < exp_str.Length - 1)
                throw new SyntaxErrorException();
            return ret;
        }

        //

        public IBooleanExpression MyParse()
        {

            ind++;
            if (ind == exp_str.Length)
                throw new SyntaxErrorException();
            string str = exp_str[ind];

            switch (str)
            {
                case "0":
                    return new ConstantExpression(false);
                case "1":
                    return new ConstantExpression(true);
                case "NOT":
                    IBooleanExpression exp = MyParse();
                    return new NotExpression(exp);
                case "AND":
                    IBooleanExpression exp1 = MyParse();
                    IBooleanExpression exp2 = MyParse();
                    return new AndExpression(exp1, exp2);
                case "OR":
                    IBooleanExpression exp3 = MyParse();
                    IBooleanExpression exp4 = MyParse();
                    return new OrExpression(exp3, exp4);
                default:
                    return new VarExpression(str);
            }

        }




    }
}
