using BluMarble.Events;
using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.PlayerState
{
    public class  StateParameter
    {
        public float Value;

        public void SetValue(float value) 
        { 
            Value = value; 
        }
    }

    public class GamePlayerState : MonoBehaviour
    {
        public List<StateParameter> m_StateParameters;

        private BluMarble.ID.PlayerID m_PlayerID;

        public void PerformInit()
        {
            m_PlayerID = GetComponent<BluMarble.ID.PlayerID>();

            m_StateParameters = new List<StateParameter>();
            List<UnityEventFloat> ParameterEventsList = BluMarble.Events.EventsManager.Instance.m_InterfaceEvents[m_PlayerID.ID].m_EventsList;

            for (int i = 0; i < (int)BluMarble.Parameters.ParametersVariable.MaxVal; ++i)
            {
                StateParameter NewStateParameter = new StateParameter();
                ParameterEventsList[i].AddListener(NewStateParameter.SetValue);
                m_StateParameters.Add(NewStateParameter);
            }
        }

        public void SetValue(float Value, BluMarble.Parameters.ParametersVariable ParametersVariableValue)
        {
            m_StateParameters[(int)ParametersVariableValue].Value = Value;
        }

        public float GetValue(BluMarble.Parameters.ParametersVariable ParametersVariableValue)
        {
            return m_StateParameters[(int)ParametersVariableValue].Value;
        }

    }
}
