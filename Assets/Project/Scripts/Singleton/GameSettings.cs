using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

namespace BluMarble.Singleton
{
    public class GameSettings : Singleton<GameSettings>
    {
        public const int m_NumOfPlayers = 4;
        public const int m_NumOfAIPlayers = 3;
        public const string m_GamePlayerTag = "GamePlayer";

        private List<GameObject> m_GamePlayersObjects;
        public List<GameObject> GamePlayerObjects()
        {
            if(m_GamePlayersObjects == null)
            {
                m_GamePlayersObjects = new List<GameObject>();
                m_GamePlayersObjects = GameObject.FindGameObjectsWithTag(BluMarble.Singleton.GameSettings.m_GamePlayerTag).ToList();
            }

            return m_GamePlayersObjects;
        }
    }
}
