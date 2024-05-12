using UnityEngine;

namespace BluMarble.ML
{
    public class MLAgentProperties
    {
        public enum EmotionalRules
        {
            Greed = 0, // cut corners and torture workers
            Risk, // jump to high rewards much quicker
            Empathy, // Understand workers and consumers and looking out for the little people
            Aggression, // Deal with competition
            TippingOver, // How much before you change your emotional rules
        }
    }
}
