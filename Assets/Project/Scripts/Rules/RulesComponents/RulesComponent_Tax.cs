using BluMarble.PlayerState;
using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.RulesComponent
{
    [CreateAssetMenu(fileName = "BluMarble_RulesComponent_Tax", menuName = "BluMarbleScriptableObjects/RulesComponent_Tax")]
    public class RulesComponent_Tax : RulesComponent
    {
        public override void PerformUpdate(ref GamePlayerState CurrentPlayerState, ref List<BluMarble.PlayerState.GamePlayerState> OtherPlayersStates)
        {
            float CurrentRevenue = CurrentPlayerState.GetValue(Parameters.ParametersVariable.Revenue);
            float TaxDeduction = m_GlobalRules.GetTaxPercentage() * CurrentRevenue;
            CurrentPlayerState.SetValue(TaxDeduction, Parameters.ParametersVariable.TotalCost);
        }
    }
}
