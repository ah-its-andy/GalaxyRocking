using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyRocking.Language
{
    public interface IScriptEngine<T>
        where T : class
    {
        T Interpret(string script);
    }
}
