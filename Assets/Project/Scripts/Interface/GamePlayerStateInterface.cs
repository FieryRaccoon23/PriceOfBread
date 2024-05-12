using UnityEngine;

namespace BluMarble.Interface
{
    public class GamePlayerStateInterface : MonoBehaviour
    {
        private BluMarble.ID.PlayerID m_PlayerID;

        public void PerformInit()
        {
            m_PlayerID = GetComponent<BluMarble.ID.PlayerID>();
        }

        public void SetParameterVariable(float Value, BluMarble.Parameters.ParametersVariable ParametersVariableValue)
        {
            BluMarble.Events.EventsManager.Instance.SetParameterFloatValue(m_PlayerID.ID, Value, ParametersVariableValue);
        }

        public void SetParameterVariable(float Value, int IndexValue)
        {
            BluMarble.Parameters.ParametersVariable ParametersVariableValue = (BluMarble.Parameters.ParametersVariable)IndexValue;
            SetParameterVariable(Value,ParametersVariableValue);
        }
    }
}
