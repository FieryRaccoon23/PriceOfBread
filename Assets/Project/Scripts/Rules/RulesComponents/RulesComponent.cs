using UnityEngine;

namespace BluMarble.RulesComponent
{
    public abstract class RulesComponent : ScriptableObject
    {
        public virtual void PerformInit()
        {

        }

        // Called once every frame
        public virtual void PerformUpdate(ref BluMarble.PlayerState.GamePlayerState CurrentPlayerState)
        {

        }
    }
}
