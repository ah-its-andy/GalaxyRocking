using System;

namespace GalaxyRocking.NatureLanguage
{
    public interface IThinker
    {
        bool CanThink(Sentence sentence);
        Delegate Think(Sentence sentence);
    }
}
