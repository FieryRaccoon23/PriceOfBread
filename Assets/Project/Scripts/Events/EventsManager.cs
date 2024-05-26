using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BluMarble.Events
{
    [System.Serializable]
    public class UnityEventFloat : UnityEvent<float>
    {
    }

    //public class InterfaceEvents
    //{
    //    public List<UnityEventFloat> m_EventsList;

    //    public void Init()
    //    {
    //        m_EventsList = new List<UnityEventFloat>();

    //        for(int i = 0; i < (int)BluMarble.Parameters.ParametersVariable.MaxVal; ++i)
    //        {
    //            UnityEventFloat NewFloatEvent = new UnityEventFloat();
    //            m_EventsList.Add(NewFloatEvent);
    //        }
    //    }

    //    public void UnbindAll()
    //    {
    //        for (int i = 0; i < (int)BluMarble.Parameters.ParametersVariable.MaxVal; ++i)
    //        {
    //            m_EventsList[i].RemoveAllListeners();
    //        }
    //    }
    //}

    public class EventsManager : BluMarble.Singleton.Singleton<EventsManager>
    {
        // Loading
        public UnityEvent m_LoadingStarted;
        public UnityEvent m_LoadingEnded;

        public override void PerformInit()
        {
        }

        public override void PerformFinish()
        {
            m_LoadingStarted.RemoveAllListeners();
            m_LoadingEnded.RemoveAllListeners();

        }
    }
}
