using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BluMarble.Rules
{
    [Serializable]
    public class RuleSettings
    {
        public RulesVariable.RuleVariables m_RuleVariable;
        public float m_InitValue = 0.0f;
    }

    public class RulesManager : BluMarble.Singleton.Singleton<RulesManager>
    {
        [SerializeField]
        private List<RuleSettings> m_RulesSettings = new List<RuleSettings>();

        [SerializeField]
        private List<RulesComponent.RulesComponent> m_RulesComponents = new List<RulesComponent.RulesComponent>();

        private Dictionary<RulesVariable.RuleVariables, float> m_RulesDictionary;
        private List<PlayerState.GamePlayerState> m_GamePlayersStates;
        private const string m_GamePlayerTag = "GamePlayer";

        public override void PerformInit()
        {
            // Get states for players
            m_GamePlayersStates = new List<PlayerState.GamePlayerState>();
            GameObject[] GamePlayerObjectsWithTag = GameObject.FindGameObjectsWithTag(m_GamePlayerTag);
            foreach (GameObject Obj in GamePlayerObjectsWithTag)
            {
                PlayerState.GamePlayerState CurrentPlayerState = Obj.GetComponent<PlayerState.GamePlayerState>();
                m_GamePlayersStates.Add(CurrentPlayerState);
            }

            // Save rules in dictionary
            m_RulesDictionary = new Dictionary<RulesVariable.RuleVariables, float>();
            for (int i = 0; i < (int)RulesVariable.RuleVariables.MaxVal; ++i)
            {
                float InitValue = 0.0f;
                RulesVariable.RuleVariables CurrentRuleVariable = (RulesVariable.RuleVariables)i;
                foreach (var RuleSettingsValue in m_RulesSettings)
                {
                    if(RuleSettingsValue.m_RuleVariable == CurrentRuleVariable)
                    {
                        InitValue = RuleSettingsValue.m_InitValue;
                        break;
                    }
                }

                m_RulesDictionary.Add(CurrentRuleVariable, InitValue);
            }

            // Init rules
            foreach (var CurrentRulesComp in m_RulesComponents)
            {
                CurrentRulesComp.PerformInit();
            }
        }

        public override void PerformUpdate()
        {
            for(int i = 0; i < m_GamePlayersStates.Count; ++i) 
            {
                PlayerState.GamePlayerState CurrentGamePlayerState = m_GamePlayersStates[i];

                foreach (var CurrentRulesComp in m_RulesComponents)
                {
                    CurrentRulesComp.PerformUpdate(ref CurrentGamePlayerState);
                }
            }
        }

        public void SetValue(RulesVariable.RuleVariables RuleVariableValue, float ValueToSet)
        {
            m_RulesDictionary[RuleVariableValue] = ValueToSet;
        }

        public float GetValue(RulesVariable.RuleVariables RuleVariableValue)
        {
            return m_RulesDictionary[RuleVariableValue];
        }
    }
}
