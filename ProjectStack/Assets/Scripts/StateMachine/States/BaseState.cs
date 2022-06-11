using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SDA.Loop
{
    public interface IBaseState
    {
        void InitState();
        void UpdateState();
        void DisposeState();
    }
}
