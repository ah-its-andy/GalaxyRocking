using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyRocking.Expressions
{
    public class SubtractRepeatedExpression : Expression
    {
        public ConstantExpression Subtracted { get; }
        public ConstantExpression Repeated { get; }
        public uint RepeatTimes { get; }
    }
}
