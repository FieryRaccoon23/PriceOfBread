using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.Controller
{
    public class AIController : MonoBehaviour
    {
        public void SetParameterValues(ref Dictionary<BluMarble.Parameters.ParametersVariable, float> ParameterValues)
        {
            BluMarble.Interface.GamePlayerStateInterface AIInterface = GetComponent<BluMarble.Interface.GamePlayerStateInterface>();

            foreach(var ParameterValue  in ParameterValues) 
            {
                AIInterface.SetParameterVariable(ParameterValue.Value, ParameterValue.Key);
            }
        }
    }
}
