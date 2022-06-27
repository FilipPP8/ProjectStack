using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.Input;
using SDA.UI;

namespace SDA.Loop
{
    public class GameState : IBaseState
    {
        private MovementSystem _movementSystem;
        private StackInput _stackInput;
        private CubePool _cubePool;
        private LoweringSystem _loweringSystem;
        private PointSystem _pointSystem;
        private GameView _gameView;
        public GameState(MovementSystem movementSystem, StackInput stackInput, CubePool cubePool, 
            LoweringSystem loweringSystem, PointSystem pointSystem, GameView gameView)
        {
            _movementSystem = movementSystem;
            _stackInput = stackInput;
            _cubePool = cubePool;
            _loweringSystem = loweringSystem;
            _pointSystem = pointSystem;
            _gameView = gameView;
        }

        void IBaseState.InitState()
        {
            _movementSystem.GenerateNewItem(_cubePool);
            _stackInput.OnTapAddListener(OnTap);
            _gameView.ShowView();
        }

        void IBaseState.UpdateState()
        {
            _movementSystem.UpdateMovement();
        }

        void IBaseState.DisposeState()
        {
            _stackInput.ClearListeners();
            _gameView.HideView();
        }

        private void OnTap()
        {
            var data = _movementSystem.StopCube();

            if(data.result == StopResult.GameOver)
            {
                //call game over code
                return;
            }
            _pointSystem.ProcessStopResult(data.result);
            _gameView.UpdateScore(_pointSystem.Points);
            _loweringSystem.AddItem(data.stoppedCube);
            _loweringSystem.LowerCubes();
            _movementSystem.GenerateNewItem(_cubePool);
        }
    }
}