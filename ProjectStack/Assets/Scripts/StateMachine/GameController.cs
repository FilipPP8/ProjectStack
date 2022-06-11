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

        private Action _transitionToGameState; // tworzymy pust¹, bezargumentow¹ delegatê, bo argumenty znajduj¹ siê w GameControllerze, a chcemy wywo³ywaæ w State

        private IBaseState _currentlyActiveState;

        private void Start()
        {
            _transitionToGameState += () => ChangeState(_gameState); // sztuczne stworzenie pustej bezparametrowej metody, która wywo³uje parametrow¹

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
