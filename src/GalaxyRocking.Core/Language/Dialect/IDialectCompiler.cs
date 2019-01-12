using System;

namespace GalaxyRocking.Language.Dialect
{
    public interface IDialectCompiler
    {
        Delegate Compile(string script);
    }
}