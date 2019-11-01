using System;

namespace LAB5B
{
    class SyntaxErrorException : Exception
    {
        public SyntaxErrorException() : base("SYNTAX_ERROR")
        {

        }
    }
}
