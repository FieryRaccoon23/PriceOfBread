//#define ML_TRAINING

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace BluMarble.Core
{
    public class MainLoop : BluMarble.Singleton.Singleton<MainLoop>
    {
        private Dictionary<GameState, Action> m_ActionList;
        private GameState m_CurrentGameState = GameState.None;

        public GameState CurrentGameState
        { 
            get 
            { 
                return m_CurrentGameState; 
            }
        }

        private void Awake()
        {
            // Load game
            m_CurrentGameState = GameState.Loading;
            BluMarble.Events.EventsManager.Instance.m_LoadingStarted.Invoke();
            StartLoading();
            BluMarble.Events.EventsManager.Instance.m_LoadingEnded.Invoke();

            // Cache game actions
            m_ActionList = new Dictionary<GameState, Action>();
            m_ActionList.Add(GameState.Loading, DoNothing);
            m_ActionList.Add(GameState.Start, StartGame);
            m_ActionList.Add(GameState.Running, UpdateGame);
            m_ActionList.Add(GameState.End, EndGame);
            m_ActionList.Add(GameState.Finished, FinishGame);

        }

        private void StartLoading()
        {
            // Validate all singletons
#if UNITY_EDITOR
            if (BluMarble.Rules.RulesManager.Instance == null)
            {
                Assert.IsTrue(false, "RulesManager not found!");
                return;
            }
            if (BluMarble.Events.EventsManager.Instance == null)
            {
                Assert.IsTrue(false, "EventsManager not found!");
                return;
            }
            if (BluMarble.PlayerState.PlayerStateManager.Instance == null)
            {
                Assert.IsTrue(false, "PlayerStateManager not found!");
                return;
            }
            if (BluMarble.Interface.PlayerInterfaceManager.Instance == null)
            {
                Assert.IsTrue(false, "PlayerInterfaceManager not found!");
                return;
            }
#if ML_TRAINING
            if (BluMarble.ML.MLManager.Instance == null)
            {
                Assert.IsTrue(false, "MLManager not found!");
                return;
            }
#endif

#endif
            // Init all singletons
            BluMarble.Events.EventsManager.Instance.PerformInit();
            BluMarble.PlayerState.PlayerStateManager.Instance.PerformInit();
            BluMarble.Interface.PlayerInterfaceManager.Instance.PerformInit();
            BluMarble.Rules.RulesManager.Instance.PerformInit();

#if ML_TRAINING
            BluMarble.Rules.RulesManager.Instance.PerformInit();
#endif

            m_CurrentGameState = GameState.Start;
        }

        private void Update()
        {
            m_ActionList[m_CurrentGameState].Invoke();
        }

        private void StartGame()
        {

#if ML_TRAINING
            BluMarble.Rules.RulesManager.Instance.PerformStart();
#endif

            m_CurrentGameState = GameState.Running;
        }

        private void UpdateGame()
        {
            BluMarble.Rules.RulesManager.Instance.PerformUpdate();

#if ML_TRAINING
            BluMarble.Rules.RulesManager.Instance.PerformUpdate();
#endif
        }

        private void EndGame()
        {
#if ML_TRAINING
            BluMarble.Rules.RulesManager.Instance.PerformEnd();
#endif
        }

        private void FinishGame()
        {
#if ML_TRAINING
            BluMarble.Rules.RulesManager.Instance.PerformFinish();
#endif

            BluMarble.Events.EventsManager.Instance.PerformFinish();
        }

        private void DoNothing()
        {
        }
    }
}
