using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.RulesComponent
{
    public abstract class RulesComponent : ScriptableObject
    {
        protected RulesComponent_Global m_GlobalRules;

        public virtual void PerformInit(ref RulesComponent_Global GlobalRulesIn)
        {
            m_GlobalRules = GlobalRulesIn;
        }

        // Called once every frame
        public virtual void PerformUpdate(ref BluMarble.PlayerState.GamePlayerState CurrentPlayerState, ref List<BluMarble.PlayerState.GamePlayerState> OtherPlayersStates)
        {

        }
    }
}
