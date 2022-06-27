using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoweringSystem : MonoBehaviour
{
    [SerializeField] private List<Cube> _gameplayItems;

    public Cube InitCube => _gameplayItems[0];
   
    public void AddItem(Cube item)
    {
        _gameplayItems.Add(item);
    }
    
    public void LowerCubes()
    {
        var downVector = Vector3.down;

        foreach(var item in _gameplayItems)
        {
            item.transform.position += downVector * 0.2f;
        }
    }
}
