using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    void PrepareForActivate(Vector3 position);
    void PrepareForDeactivate(Transform parent);


}
