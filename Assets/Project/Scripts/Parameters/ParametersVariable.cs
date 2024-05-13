using UnityEngine;

namespace BluMarble.Parameters
{
    public enum ParametersVariable
    {
        ///////////////////////////////Globally affects everyone///////////////////////////////
        Tax = 0,
        Inflation,
        CostOfWheat,

        /////////////////////////////// Individual effects///////////////////////////////
        
        // Fiscal rules
        BreadPrice,
        CostOfWorkers,
        CostOfQualityControl,
        CostOfAd,
        CostOfNormalFlour,
        CostOfArtisanalFlour,
        CostOfLookTheOtherWay,
        CostOfDirtyWork,
        CostOfGatheringIntel,

        // Social rules
        Trust, // related to consumers
        Satisfaction, // related to workers
        Confidence, // related to investors

        ///////////////////////////////END - Add stuff before it///////////////////////////////
        MaxVal
    }

}