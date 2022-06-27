using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SDA.UI;
using SDA.Input;

namespace SDA.Loop
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private GameView _gameView;
        [SerializeField] private StackInput _stackInput;
        [SerializeField] private CubePool _cubePool;
        [SerializeField] private LoweringSystem _loweringSystem;

        private MovementSystem _movementSystem;
        private PointSystem _pointSystem;


        private MainMenuState _mainMenuState;
        private GameState _gameState;

        private Action _transitionToGameState; // tworzymy pust�, bezargumentow� delegat�, bo argumenty znajduj� si� w GameControllerze, a chcemy wywo�ywa� w State

        private IBaseState _currentlyActiveState;

        private void Start()
        {
            _transitionToGameState += () => ChangeState(_gameState); // sztuczne stworzenie pustej bezparametrowej metody, kt�ra wywo�uje parametrow�

            _movementSystem = new MovementSystem(_loweringSystem.InitCube);
            _pointSystem = new PointSystem();

            _mainMenuState = new MainMenuState(_transitionToGameState, _mainMenuView);
            _gameState = new GameState(_movementSystem, _stackInput, _cubePool, _loweringSystem, _pointSystem, _gameView);

            _currentlyActiveState = _mainMenuState;
            
            ChangeState(_gameState);
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
