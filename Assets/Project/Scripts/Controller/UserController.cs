using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace BluMarble.Controller
{
    public class UserController : MonoBehaviour
    {
        public TMP_InputField First;
        public TMP_InputField Second;
        public TMP_InputField Third;

        public void SetStateValues()
        {
            int firstVal;
            int.TryParse(First.text, out firstVal);

            int secondVal;
            int.TryParse(Second.text, out secondVal);

            int thirdVal;
            int.TryParse(Third.text, out thirdVal);

            //BluMarble.Interface.GamePlayerStateInterface UserInterface = GetComponent<BluMarble.Interface.GamePlayerStateInterface>();
            //UserInterface.SetParameterVariable((float)firstVal, BluMarble.Parameters.ParametersVariable.BreadPrice);
            //UserInterface.SetParameterVariable((float)secondVal, BluMarble.Parameters.ParametersVariable.CostOfNormalFlour);
            //UserInterface.SetParameterVariable((float)thirdVal, BluMarble.Parameters.ParametersVariable.CostOfLookTheOtherWay);
        }
    }
}
