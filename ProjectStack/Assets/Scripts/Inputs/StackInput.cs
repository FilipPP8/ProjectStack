using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SDA.Input
{
    public class StackInput : MonoBehaviour
    {
        private Action onTap;

        public void OnTapAddListener(Action callback)
        {
            onTap += callback;
        }
        public void OnTap(InputAction.CallbackContext ctx)
        {
            if(ctx.action.WasPerformedThisFrame())
            {
                onTap?.Invoke();
            }
        }

        public void ClearListeners()
        {
            onTap = null;
        }

    
    }
}