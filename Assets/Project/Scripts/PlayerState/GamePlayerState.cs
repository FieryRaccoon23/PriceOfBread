using BluMarble.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.PlayerState
{
    [Serializable]
    public class StateParameter
    {
        public float m_Value = 0.0f;
        public Parameters.ParametersVariable m_Variable;
    }

    public class GamePlayerState : MonoBehaviour
    {
        [SerializeField]
        private List<StateParameter> m_StateParameters;

        public void PerformInit()
        {
            m_StateParameters = new List<StateParameter>();

            for (int i = 0; i < (int)BluMarble.Parameters.ParametersVariable.MaxVal; ++i)
            {
                StateParameter NewStateParameter = new StateParameter();
                NewStateParameter.m_Value = 0.0f;
                NewStateParameter.m_Variable = (Parameters.ParametersVariable)i;
                m_StateParameters.Add(NewStateParameter);
            }
        }

        public void SetValue(float Value, BluMarble.Parameters.ParametersVariable ParametersVariableValue)
        {
            m_StateParameters[(int)ParametersVariableValue].m_Value = Value;
        }

        public float GetValue(BluMarble.Parameters.ParametersVariable ParametersVariableValue)
        {
            return m_StateParameters[(int)ParametersVariableValue].m_Value;
        }

        public void AddValue(float Value, BluMarble.Parameters.ParametersVariable ParametersVariableValue)
        {
            float CurrentVal = GetValue(ParametersVariableValue);
            float NewVal = CurrentVal + Value;
            SetValue(NewVal, ParametersVariableValue);
        }
    }
}
