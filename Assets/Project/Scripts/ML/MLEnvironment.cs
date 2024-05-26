using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace BluMarble.ML
{
    public class MLEnvironment : MonoBehaviour
    {
        private List<PlayerState.GamePlayerState> m_GamePlayersStates;

        public void PerformStart()
        {
            // Get states for players
            m_GamePlayersStates = new List<PlayerState.GamePlayerState>();
            List<GameObject> GamePlayerObjectsWithTag = BluMarble.Singleton.GameSettings.Instance.GamePlayerObjects();
            foreach (GameObject Obj in GamePlayerObjectsWithTag)
            {
                PlayerState.GamePlayerState CurrentPlayerState = Obj.GetComponent<PlayerState.GamePlayerState>();
                ID.PlayerID CurrentPlayerID = Obj.GetComponent<ID.PlayerID>();

                if(CurrentPlayerID.IsBeingTrained)
                {
                    continue;
                }

                m_GamePlayersStates.Add(CurrentPlayerState);
            }

        }

        public void PerformUpdate()
        {

        }

        public void PerformEnd()
        {

        }

        private void SetPriceOfBread(ref PlayerState.GamePlayerState CurrentPlayerState)
        {

        }
    }
}
