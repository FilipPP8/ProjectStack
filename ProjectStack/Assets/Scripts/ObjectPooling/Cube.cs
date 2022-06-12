using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPoolable
{
    public void PrepareForActivate(Vector3 position)
    {
        transform.SetParent(null);
        transform.position = position;
        this.gameObject.SetActive(true);
        transform.localScale = new Vector3(1.5f, 0.2f, 1.5f);
    }

    public void PrepareForDeactivate(Transform parent)
    {
        this.gameObject.SetActive(false);
        this.transform.SetParent(parent);
    }



}
