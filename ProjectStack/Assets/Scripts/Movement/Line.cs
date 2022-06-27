using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Line
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    private bool _isMovementReversed;

    public Line(Vector3 startPoint, Vector3 endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        _isMovementReversed = false;

    }

    public Vector3 GetPositionOnTheLine(float percent)
    {
        return _isMovementReversed
        ? Vector3.Lerp(endPoint, startPoint, percent)
        : Vector3.Lerp(startPoint, endPoint, percent);
    }

    public void ReverseMovement()
    {
        _isMovementReversed = !_isMovementReversed;
    }

    public void EditXValue(float newX)
    {
        startPoint.x = newX;
        endPoint.x = newX;
    }

    public void EditZValue(float newZ)
    {
        startPoint.z = newZ;
        endPoint.z = newZ;
    }

}
