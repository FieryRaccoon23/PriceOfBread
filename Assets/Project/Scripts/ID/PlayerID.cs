using UnityEngine;

namespace BluMarble.ID
{
    public class PlayerID : MonoBehaviour
    {
        [SerializeField]
        private bool m_IsUser = false;

        [SerializeField]
        private bool m_IsBeingTrained = false;

        private static int m_GeneratedPlayerID = 0;

        private int m_ID = -1;
        public int ID
        {
            get
            {
                if (m_ID == -1)
                {
                    m_ID = m_GeneratedPlayerID;
                    ++m_GeneratedPlayerID;
                }

                return m_ID;
            }
        }

        public bool IsUser
        { 
            get 
            { 
                return m_IsUser; 
            } 
        }

        public bool IsBeingTrained
        {
            get
            {
                return m_IsBeingTrained;
            }
        }
    }
}
