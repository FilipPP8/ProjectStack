using UnityEngine;


public enum StopResult
{
    GameOver,
    Point,
    ComboPoint,
}


public class MovementSystem
{


    private Cube _cubeCurrentlyInMovement;
    private Cube _lastCube;
    private CubePool _cubePool;

    private Line _currentlyActiveLine;
    private Line zAxis = new Line(new Vector3(0f, -2.4f, 2.2f), new Vector3(0f, -2.4f, -2.2f));
    private Line xAxis = new Line(new Vector3(2.2f, -2.4f, 0f), new Vector3(-2.2f, -2.4f, 0f));

    private int counter = 0;

    private float _currentTime;
    private float _startTime;
    private float _duration = 2f;

    public MovementSystem(Cube lastCube)
    {
        _lastCube = lastCube;
        counter = Random.Range(0, 151);
        _lastCube.SetColor((counter / 150f) % 1f, 0.5f);
    }

    public StopData StopCube()
    {
        var current = _cubeCurrentlyInMovement;
        _cubeCurrentlyInMovement = null;

        var isXAxis = (counter - 1) % 2 == 0;

        var distance = 0f;
        var limit = 0f;
        var direction = 0f;
        if(isXAxis)
        {
            distance = current.transform.position.x - _lastCube.transform.position.x;
            direction = Mathf.Sign(distance);
            distance = Mathf.Abs(distance);
            limit = _lastCube.transform.localScale.x;
        }
        else
        {
            distance = current.transform.position.z - _lastCube.transform.position.z;
            direction = Mathf.Sign(distance);
            distance = Mathf.Abs(distance);
            limit = _lastCube.transform.localScale.z;
        }

        var result = StopResult.GameOver;

        if (distance >= 0f && distance <= 0.1f)
        {
            result = StopResult.ComboPoint;
            current.transform.position = new Vector3(_lastCube.transform.position.x,
                current.transform.position.y, _lastCube.transform.position.z);
        }
        else if (distance > 0.1f && distance <= limit)
        {
            result = StopResult.Point;
        }

        Cube fallingCube;

        if(isXAxis)
        {
            fallingCube = CutItemOnX(current, distance, direction);
        }
        else
        {
            fallingCube = CutItemOnZ(current, distance, direction);
        }

        var data = new StopData(current, fallingCube, result);

        _lastCube = current;

        return data;

    }



    public void GenerateNewItem(CubePool cubePool)
    {
        _cubePool = cubePool;
        _currentlyActiveLine = counter++ % 2 == 0 ? xAxis : zAxis;
        _cubeCurrentlyInMovement = _cubePool.GetFromPool(_currentlyActiveLine.startPoint);

        _cubeCurrentlyInMovement.SetColor((counter / 150f) % 1f);

        _cubeCurrentlyInMovement.transform.localScale = new Vector3(_lastCube.transform.localScale.x, 
            _cubeCurrentlyInMovement.transform.localScale.y, _lastCube.transform.localScale.z);

        _startTime = Time.time;
    }

    public void UpdateMovement()
    {
        if(_cubeCurrentlyInMovement == null)
        {
            return;
        }

        _currentTime = (Time.time - _startTime) / _duration;

        _cubeCurrentlyInMovement.transform.position = _currentlyActiveLine.GetPositionOnTheLine(_currentTime);

        if (_currentTime >= 1f)
        {
            _startTime = Time.time;
            _currentlyActiveLine.ReverseMovement(); 
        }

    }


    private Cube CutItemOnX(Cube cube, float distance, float direction)
    {
        var newXScale = _lastCube.transform.localScale.x - distance;
        var newXPosition = _lastCube.transform.position.x + (distance / 2f) * direction;

        var fallingXCubeScale = cube.transform.localScale.x - newXScale;

        cube.transform.position = new Vector3(newXPosition, cube.transform.position.y, cube.transform.position.z);
        cube.transform.localScale = new Vector3(newXScale, cube.transform.localScale.y, cube.transform.localScale.z);

        var cubeEdge = cube.transform.position.x + (newXScale / 2f) * direction;
        var fallingXCubePosition = cubeEdge + (fallingXCubeScale / 2f) * direction;

        var fallingCube = _cubePool.GetFromPool(new Vector3(fallingXCubePosition, cube.transform.position.y, cube.transform.position.z));
        fallingCube.transform.localScale = new Vector3(fallingXCubeScale, cube.transform.localScale.y, cube.transform.localScale.z);
        fallingCube.SetColor(cube.GetColor());
        fallingCube.EnableGravity();

        zAxis.EditXValue(newXPosition);

        return fallingCube;
    }

    private Cube CutItemOnZ(Cube cube, float distance, float direction)
    {
        var newZScale = _lastCube.transform.localScale.z - distance;
        var newZPosition = _lastCube.transform.position.z + (distance / 2f) * direction;

        var fallingZCubeScale = cube.transform.localScale.z - newZScale;

        cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, newZPosition);
        cube.transform.localScale = new Vector3(cube.transform.localScale.x, cube.transform.localScale.y, newZScale);

        var cubeEdge = cube.transform.position.z + (newZScale / 2f) * direction;
        var fallingZCubePosition = cubeEdge + (fallingZCubeScale / 2f) * direction;

        var fallingCube = _cubePool.GetFromPool(new Vector3(cube.transform.position.x, cube.transform.position.y, fallingZCubePosition));
        fallingCube.transform.localScale = new Vector3(cube.transform.localScale.x, cube.transform.localScale.y, fallingZCubeScale);
        fallingCube.SetColor(cube.GetColor());
        fallingCube.EnableGravity();

        xAxis.EditZValue(newZPosition);

        return fallingCube;
    }



}
