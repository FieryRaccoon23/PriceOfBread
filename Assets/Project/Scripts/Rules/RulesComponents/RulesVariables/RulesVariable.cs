using UnityEngine;

namespace BluMarble.RulesVariable
{
    public enum RuleVariables
    {
        ///////////////////////////////Globally affects everyone///////////////////////////////
        Tax = 0,
        Inflation,
        CostOfWheat,

        /////////////////////////////// Individual effects///////////////////////////////
        
        // Fiscal rules
        WorkersPay,
        QualityControl,

        // Social Rules
        Trust, // related to consumers
        Satisfaction, // related to workers

        ///////////////////////////////END - Add stuff before it///////////////////////////////
        MaxVal
    }

}
