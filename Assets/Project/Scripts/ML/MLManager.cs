using UnityEngine;

namespace BluMarble.ML
{
    public class MLManager : BluMarble.Singleton.Singleton<MLManager>
    {
        private MLEnvironment m_MLEnvironment;

        private const int m_UpdatePeriod = 14;
        private int m_CurrentUpdateTime = 0;

        public override void PerformInit()
        {
            m_MLEnvironment = GetComponent<MLEnvironment>();
        }

        public override void PerformStart()
        {
            m_MLEnvironment.PerformStart();
        }

        public override void PerformUpdate()
        {
            if (m_CurrentUpdateTime >= m_UpdatePeriod)
            {
                m_MLEnvironment.PerformUpdate();
                m_CurrentUpdateTime = -1;
            }

            ++m_CurrentUpdateTime;
        }

        public override void PerformEnd()
        {
            m_MLEnvironment.PerformEnd();
        }

        public override void PerformFinish()
        {
        }
    }
}
