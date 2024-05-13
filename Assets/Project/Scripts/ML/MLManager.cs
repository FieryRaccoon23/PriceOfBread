using UnityEngine;

namespace BluMarble.ML
{
    public class MLManager : BluMarble.Singleton.Singleton<MLManager>
    {
        private MLEnvironment m_MLEnvironment;
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
            m_MLEnvironment.PerformUpdate();
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
