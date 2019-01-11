using System;

namespace GalaxyRocking
{
    public class ArgumentTypeDismatchException : ArgumentException
    {
        public ArgumentTypeDismatchException(string argumentName) : base($"Type of argument {argumentName} has been dismatched.")
        {
        }
    }
}
