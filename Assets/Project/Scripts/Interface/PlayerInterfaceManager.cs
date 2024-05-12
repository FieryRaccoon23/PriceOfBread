using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace BluMarble.Interface
{
    public class PlayerInterfaceManager : BluMarble.Singleton.Singleton<PlayerInterfaceManager>
    {
        private List<Interface.GamePlayerStateInterface> m_GamePlayersInterfacess;

        public override void PerformInit()
        {
            // Get states interfaces for players
            m_GamePlayersInterfacess = new List<Interface.GamePlayerStateInterface>();
            List<GameObject> GamePlayerObjectsWithTag = BluMarble.Singleton.GameSettings.Instance.GamePlayerObjects();
            foreach (GameObject Obj in GamePlayerObjectsWithTag)
            {
                Interface.GamePlayerStateInterface CurrentPlayerStateInterface = Obj.GetComponent<Interface.GamePlayerStateInterface>();
                CurrentPlayerStateInterface.PerformInit();
                m_GamePlayersInterfacess.Add(CurrentPlayerStateInterface);
            }
        }
    }
}
