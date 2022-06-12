using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : Pool<Cube>
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _poolSize;


    private void Awake()
    {
    }

    private void Start()
    {
        InitializePool(_cubePrefab, _poolSize);
   
    }




  
}
