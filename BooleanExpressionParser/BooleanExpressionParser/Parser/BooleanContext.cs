using System;
using System.Collections.Generic;

namespace LAB5B
{
    class BooleanContext
    {
        private Dictionary<string, bool> vars = new Dictionary<string, bool>();

        public bool GetVariable(string name)
        {
            try
            {
                return vars[name];
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void SetVariable(string name, bool value)
        {
            vars[name] = value;

            Console.WriteLine("Variable '{0}' set to {1}", name, value);
        }
    }
}
