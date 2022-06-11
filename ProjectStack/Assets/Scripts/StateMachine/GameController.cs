using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SDA.UI;


namespace SDA.Loop
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private MainMenuView _mainMenuView;


        private MainMenuState _mainMenuState;
        private GameState _gameState;

        private Action _transitionToGameState; // tworzymy pust�, bezargumentow� delegat�, bo argumenty znajduj� si� w GameControllerze, a chcemy wywo�ywa� w State

        private IBaseState _currentlyActiveState;

        private void Start()
        {
            _transitionToGameState += () => ChangeState(_gameState); // sztuczne stworzenie pustej bezparametrowej metody, kt�ra wywo�uje parametrow�

            _mainMenuState = new MainMenuState(_transitionToGameState, _mainMenuView);
            _gameState = new GameState();

            ChangeState(_mainMenuState);
        }

        private void Update()
        {
            _currentlyActiveState?.UpdateState();
        }

        private void OnDestroy()
        {
            
        }

        private void ChangeState(IBaseState newState)
        {
            _currentlyActiveState?.DisposeState();
            _currentlyActiveState = newState;
            _currentlyActiveState?.InitState();
        }


    }
}
