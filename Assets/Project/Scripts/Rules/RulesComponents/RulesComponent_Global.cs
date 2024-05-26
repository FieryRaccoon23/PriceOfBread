using UnityEngine;

namespace BluMarble.RulesComponent
{
    public class RulesComponent_Global
    {
        // Constant values
        private const float m_StartingTaxPercentage = 0.1f;

        private float m_TaxPercentage = m_StartingTaxPercentage;

        public void PerformInit()
        {
            m_TaxPercentage = m_StartingTaxPercentage;
        }

        public void PerformUpdate()
        {

        }

        public float GetTaxPercentage() 
        {
            return m_TaxPercentage;
        }
    }
}
