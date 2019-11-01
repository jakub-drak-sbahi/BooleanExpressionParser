using System;
using System.Diagnostics;

namespace LAB5B
{
    class Program
    {

        static void Main(string[] args)
        {
            var context = new BooleanContext();
            var parser = new PrefixBooleanParser();

            SimpleTest(context, parser);
            ExceptionTest(context, parser);
            VariableTest(context, parser);

            Console.WriteLine("All test cases passed");
            Console.ReadKey();
        }

        static void SimpleTest(BooleanContext context, PrefixBooleanParser parser)
        {
            Console.WriteLine("Test Cases for Simple Boolean Expression");

            foreach (var test_prefix_expression in ExampleBooleanExpressions.TestExpression)
            {
                var expression = parser.Parse(test_prefix_expression.Item1);

                var actual_value = EvaluateAndPrint(expression, context);
                var expected_value = test_prefix_expression.Item2;

                Debug.Assert(actual_value == expected_value);
            }
        }

        static void ExceptionTest(BooleanContext context, PrefixBooleanParser parser)
        {
            Console.WriteLine("Test Cases for Invalid Prefix format");
            foreach (var test_prefix_expression in ExampleBooleanExpressions.TestExceptionExpression)
            {
                bool exception_thrown = false;
                try
                {
                    var expression = parser.Parse(test_prefix_expression);
                }
                catch (SyntaxErrorException)
                {
                    exception_thrown = true;
                    Console.WriteLine("Correctly detected invalid format: {0}", test_prefix_expression);
                }

                Debug.Assert(exception_thrown);
            }

        }

        static void VariableTest(BooleanContext context, PrefixBooleanParser parser)
        {
            Console.WriteLine("Test Cases for Variable Boolean Expression");

            VariableTest1(context, parser);
            VariableTest2(context, parser);
            VariableTest3(context, parser);
            VariableTest4(context, parser);
            VariableTest5(context, parser);
            VariableTest6(context, parser);
        }

        static void VariableTest1(BooleanContext context, PrefixBooleanParser parser)
        {
            var e1 = parser.Parse("X");
            context.SetVariable("X", true);

            var expected_value = true;
            var actual_value = EvaluateAndPrint(e1, context);

            Debug.Assert(actual_value == expected_value);
        }

        static void VariableTest2(BooleanContext context, PrefixBooleanParser parser)
        {
            var e1 = parser.Parse("X");
            context.SetVariable("X", false);

            var expected_value = false;
            var actual_value = EvaluateAndPrint(e1, context);

            Debug.Assert(actual_value == expected_value);
        }

        static void VariableTest3(BooleanContext context, PrefixBooleanParser parser)
        {
            var e1 = parser.Parse("AND OR X 0 NOT 0");
            context.SetVariable("X", false);

            var expected_value = false;
            var actual_value = EvaluateAndPrint(e1, context);

            Debug.Assert(actual_value == expected_value);
        }

        static void VariableTest4(BooleanContext context, PrefixBooleanParser parser)
        {
            var e1 = parser.Parse("AND OR X 0 NOT 0");
            context.SetVariable("X", true);

            var expected_value = true;
            var actual_value = EvaluateAndPrint(e1, context);

            Debug.Assert(actual_value == expected_value);
        }

        static void VariableTest5(BooleanContext context, PrefixBooleanParser parser)
        {
            var e1 = parser.Parse("AND OR AND X Y NOT Z W");
            context.SetVariable("X", true);
            context.SetVariable("Y", true);
            context.SetVariable("Z", true);
            context.SetVariable("W", true);

            var expected_value = true;
            var actual_value = EvaluateAndPrint(e1, context);

            Debug.Assert(actual_value == expected_value);
        }

        static void VariableTest6(BooleanContext context, PrefixBooleanParser parser)
        {
            var e1 = parser.Parse("AND OR AND X Y NOT Z W");
            context.SetVariable("X", true);
            context.SetVariable("Y", true);
            context.SetVariable("Z", true);
            context.SetVariable("W", false);

            var expected_value = false;
            var actual_value = EvaluateAndPrint(e1, context);

            Debug.Assert(actual_value == expected_value);
        }

        static bool EvaluateAndPrint(IBooleanExpression expression, BooleanContext context)
        {
            Console.WriteLine("Expression: {0}", expression.ToString());

            var value = expression.Evaluate(context);

            if (value)
                Console.WriteLine("Evaluated: true");
            else
                Console.WriteLine("Evaluated: false");

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");

            return value;
        }
    }
}