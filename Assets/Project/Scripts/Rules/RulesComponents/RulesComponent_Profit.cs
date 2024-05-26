using BluMarble.PlayerState;
using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.RulesComponent
{
    [CreateAssetMenu(fileName = "BluMarble_RulesComponent_Profit", menuName = "BluMarbleScriptableObjects/RulesComponent_Profit")]
    public class RulesComponent_Profit : RulesComponent
    {
        public override void PerformUpdate(ref GamePlayerState CurrentPlayerState, ref List<BluMarble.PlayerState.GamePlayerState> OtherPlayersStates)
        {
            float TotalRevenue = CurrentPlayerState.GetValue(Parameters.ParametersVariable.Revenue);
            float TotalCost = CurrentPlayerState.GetValue(Parameters.ParametersVariable.TotalCost);
            float Profit = TotalRevenue - TotalCost;
            CurrentPlayerState.SetValue(Profit, Parameters.ParametersVariable.Profit);
        }
    }
}
