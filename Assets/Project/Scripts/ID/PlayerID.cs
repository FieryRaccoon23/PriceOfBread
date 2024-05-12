using UnityEngine;

namespace BluMarble.ID
{
    public class PlayerID : MonoBehaviour
    {
        [SerializeField]
        private bool m_IsUser = false;

        private static int m_GeneratedPlayerID = 1;

        private int m_ID = -1;
        public int ID
        {
            get
            {
                if (m_ID == -1)
                {
                    if (m_IsUser)
                    {
                        m_ID = 0;
                    }
                    else
                    {
                        m_ID = m_GeneratedPlayerID;
                        ++m_GeneratedPlayerID;
                    }
                }

                return m_ID;
            }
        }
    }
}
