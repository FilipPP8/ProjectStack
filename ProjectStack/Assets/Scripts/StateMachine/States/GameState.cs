using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Loop
{
    public class GameState : IBaseState
    {
   

        void IBaseState.InitState()
        {
        }

        void IBaseState.UpdateState()
        {
            Debug.Log("GONG");
        }

        void IBaseState.DisposeState()
        {
        }
    }
}