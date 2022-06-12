using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.Input;

namespace SDA.Loop
{
    public class GameState : IBaseState
    {
        private MovementSystem _movementSystem;
        private StackInput _stackInput;
        private CubePool _cubePool;
        public GameState(MovementSystem movementSystem, StackInput stackInput, CubePool cubePool)
        {
            _movementSystem = movementSystem;
            _stackInput = stackInput;
            _cubePool = cubePool;
        }

        void IBaseState.InitState()
        {
            _movementSystem.GenerateNewItem(_cubePool);
            _stackInput.OnTapAddListener(OnTap);
        }

        void IBaseState.UpdateState()
        {
            _movementSystem.UpdateMovement();
        }

        void IBaseState.DisposeState()
        {
            _stackInput.ClearListeners();
        }

        private void OnTap()
        {
            _movementSystem.GenerateNewItem(_cubePool);
        }
    }
}