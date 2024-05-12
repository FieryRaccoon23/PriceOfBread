using System.Collections.Generic;
using UnityEngine;

namespace BluMarble.PlayerState
{
    public class PlayerStateManager : BluMarble.Singleton.Singleton<PlayerStateManager>
    {
        private List<PlayerState.GamePlayerState> m_GamePlayersStates;

        public override void PerformInit()
        {
            // Get states for players
            m_GamePlayersStates = new List<PlayerState.GamePlayerState>();
            List<GameObject> GamePlayerObjectsWithTag = BluMarble.Singleton.GameSettings.Instance.GamePlayerObjects();
            foreach (GameObject Obj in GamePlayerObjectsWithTag)
            {
                PlayerState.GamePlayerState CurrentPlayerState = Obj.GetComponent<PlayerState.GamePlayerState>();
                CurrentPlayerState.PerformInit();
                m_GamePlayersStates.Add(CurrentPlayerState);
            }
        }
    }
}
