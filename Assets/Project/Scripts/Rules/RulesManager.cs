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

        private BluMarble.RulesComponent.RulesComponent_Global m_GlobalRules;

        private bool m_ShouldUpdate = false;

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

            // Init global rules
            m_GlobalRules = new RulesComponent.RulesComponent_Global();
            m_GlobalRules.PerformInit();

            // Init rules
            foreach (var CurrentRulesComp in m_RulesComponents)
            {
                CurrentRulesComp.PerformInit(ref m_GlobalRules);
            }

            m_ShouldUpdate = false;
        }

        public override void PerformUpdate()
        {
            if(!m_ShouldUpdate)
            {
                return;
            }    

            m_GlobalRules.PerformUpdate();

            List<BluMarble.PlayerState.GamePlayerState> OtherGamePlayersStates = new List<PlayerState.GamePlayerState>();

            for (int i = 0; i < m_GamePlayersStates.Count; ++i) 
            {
                // Current player
                PlayerState.GamePlayerState CurrentGamePlayerState = m_GamePlayersStates[i];

                // Other players
                OtherGamePlayersStates.Clear();
                for (int j = 0; j < m_GamePlayersStates.Count; ++j)
                {
                    if(i == j)
                    {
                        continue;
                    }

                    OtherGamePlayersStates.Add(m_GamePlayersStates[j]);
                }

                foreach (var CurrentRulesComp in m_RulesComponents)
                {
                    CurrentRulesComp.PerformUpdate(ref CurrentGamePlayerState, ref OtherGamePlayersStates);
                }
            }
        }

    }
}
