using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SDA.UI;


namespace SDA.Loop
{
    public class MainMenuState : IBaseState
    {
        private Action _transitionToGameState;
        private MainMenuView _mainMenuView;
        public MainMenuState(Action transitionToGameState, MainMenuView mainMenuView )
        {
            _transitionToGameState = transitionToGameState;
            _mainMenuView = mainMenuView;
        }
        public void InitState()
        {
            _mainMenuView.ShowView();
        }

        public void UpdateState()
        {
            Debug.Log("Dupa");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _transitionToGameState.Invoke();
            }
        }

        public void DisposeState()
        {
            _mainMenuView.HideView();
        }
    }
}
