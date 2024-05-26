using BluMarble.PlayerState;
using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.RulesComponent
{
    [CreateAssetMenu(fileName = "BlueMarble_RulesComponent_IrrationalConsumer", menuName = "BluMarbleScriptableObjects/RulesComponent_IrrationalConsumer")]
    public class RulesComponent_IrrationalConsumer : RulesComponent
    {
        public override void PerformUpdate(ref GamePlayerState CurrentPlayerState, ref List<GamePlayerState> OtherPlayersStates)
        {
        }
    }
}
