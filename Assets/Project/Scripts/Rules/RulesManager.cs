using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BluMarble.Rules
{

    public class RulesManager : BluMarble.Singleton.Singleton<RulesManager>
    {
        [SerializeField]
        private List<RulesComponent.RulesComponent> m_RulesComponents = new List<RulesComponent.RulesComponent>();

        private List<PlayerState.GamePlayerState> m_GamePlayersStates;
       

        public override void PerformInit()
        {
            // Get states for players
            m_GamePlayersStates = new List<PlayerState.GamePlayerState>();
            List<GameObject> GamePlayerObjectsWithTag = BluMarble.Singleton.GameSettings.Instance.GamePlayerObjects();
            foreach (GameObject Obj in GamePlayerObjectsWithTag)
            {
                PlayerState.GamePlayerState CurrentPlayerState = Obj.GetComponent<PlayerState.GamePlayerState>();
                m_GamePlayersStates.Add(CurrentPlayerState);
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

    }
}
