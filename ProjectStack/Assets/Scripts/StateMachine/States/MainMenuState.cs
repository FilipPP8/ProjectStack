using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace SDA.Loop
{
    public class MainMenuState : IBaseState
    {
        private Action _transitionToGameState;
        public MainMenuState(Action transitionToGameState)
        {
            _transitionToGameState = transitionToGameState;
        }
        public void InitState()
        {
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
        }
    }
}
