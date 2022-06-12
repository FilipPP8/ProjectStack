using UnityEngine;

public class MovementSystem
{
    private Cube _cubeCurrentlyInMovement;
    private Vector3 _spawn;
    private Vector3 _destination;
    private Vector3 _currentDestination;
    private float _speed = 2f;

    public void GenerateNewItem(CubePool cubePool)
    {
         _spawn = new Vector3(0f, -2.4f, 2.2f);
         _destination = new Vector3(0f, -2.4f, -2.2f);
        _currentDestination = _destination;
        _cubeCurrentlyInMovement = cubePool.GetFromPool(_spawn);

    }

    public void UpdateMovement()
    {
        var step = _speed * Time.deltaTime;
     
        _cubeCurrentlyInMovement.transform.position = Vector3.MoveTowards(_cubeCurrentlyInMovement.transform.position, _currentDestination, step);

        if(_cubeCurrentlyInMovement.transform.position == _destination && _currentDestination != _spawn)
        {
            _currentDestination = _spawn;
        }
        else if(_cubeCurrentlyInMovement.transform.position == _spawn && _currentDestination != _destination)
        {
            _currentDestination = _destination;
        }


    }




}
