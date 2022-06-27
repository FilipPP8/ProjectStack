using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StopData
{
    public Cube stoppedCube;
    public Cube fallingCube;
    public StopResult result;

    public StopData(Cube stoppedCube, Cube fallingCube, StopResult result)
    {
        this.stoppedCube = stoppedCube;
        this.fallingCube = fallingCube;
        this.result = result;
    }
}
