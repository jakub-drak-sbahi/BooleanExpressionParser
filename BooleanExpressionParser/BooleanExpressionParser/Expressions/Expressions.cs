using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5B
{
    class ConstantExpression : IBooleanExpression
    {
        private bool value;
        public ConstantExpression(bool v)
        {
            value = v;
        }
        public bool Evaluate(BooleanContext context)
        {
            return value;
        }

        public override string ToString()
        {
            if (value)
                return "TRUE";
            return "FALSE";
        }
    }

  

    class VarExpression : IBooleanExpression
    {
        private string value;
        public VarExpression(string v)
        {
            value = v;
        }
        public bool Evaluate(BooleanContext context)
        {
            return context.GetVariable(value);
        }

        public override string ToString()
        {
            return value;
        }
    }

    class NotExpression : IBooleanExpression
    {
        private IBooleanExpression firstExpression;
        public NotExpression(IBooleanExpression e)
        {
            firstExpression = e;
        }
        public bool Evaluate(BooleanContext context)
        {
            return !firstExpression.Evaluate(context);
        }
        public override string ToString()
        {
            return $"!{firstExpression}";
        }
    }

    class AndExpression : IBooleanExpression
    {
        private IBooleanExpression firstExpression;
        private IBooleanExpression secondExpression;
        public AndExpression(IBooleanExpression a, IBooleanExpression b)
        {
            firstExpression = a;
            secondExpression = b;
        }
        public bool Evaluate(BooleanContext context)
        {
            return firstExpression.Evaluate(context) && secondExpression.Evaluate(context);
        }
        public override string ToString()
        {
            return $"({firstExpression} AND {secondExpression})";
        }
    }

    class OrExpression : IBooleanExpression
    {
        private IBooleanExpression firstExpression;
        private IBooleanExpression secondExpression;
        public OrExpression(IBooleanExpression a, IBooleanExpression b)
        {
            firstExpression = a;
            secondExpression = b;
        }
        public bool Evaluate(BooleanContext context)
        {
            return firstExpression.Evaluate(context) || secondExpression.Evaluate(context);
        }
        public override string ToString()
        {
            return $"({firstExpression} OR {secondExpression})";
        }

    }

}
