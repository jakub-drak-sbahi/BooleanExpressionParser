using System;
using System.Collections.Generic;

namespace LAB5B
{
    static class ExampleBooleanExpressions
    {
        public static Tuple<string, bool>[] TestExpression =
        {
            new Tuple<string, bool>("1", true),
            new Tuple<string, bool>("0", false),

            new Tuple<string, bool>("AND 1 0", false),
            new Tuple<string, bool>("AND 1 1", true),

            new Tuple<string, bool>("OR 1 1", true),
            new Tuple<string, bool>("OR 1 0", true),
            new Tuple<string, bool>("OR 0 0", false),

            new Tuple<string, bool>("NOT 0", true),
            new Tuple<string, bool>("NOT 1", false),

            new Tuple<string, bool>("OR AND 1 0 1", true),
            new Tuple<string, bool>("OR AND 1 0 0", false),
            new Tuple<string, bool>("OR AND 1 0 NOT 0", true),
            new Tuple<string, bool>("AND OR AND 1 0 NOT 0 1", true),

        };

        public static List<string> TestExceptionExpression = new List<string>
        {
            "AND",
            "1 AND",
            "OR",
            "AND 1",
            "OR 1",
            "1 2",
            "1     2"
        };
       
    }
}
