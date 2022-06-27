using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem
{
    private int _points;
    public int Points => _points;
    private int _comboPoints;

    private Action onComboCompleted;

    private void AddPoint()
    {
        _points += 1;
        Debug.Log("Current Points: " + _points);
    }

    public void ProcessStopResult(StopResult result)
    {
        switch(result)
        {
            case StopResult.Point:
                ClearComboPoints();
                AddPoint();
                break;
            case StopResult.ComboPoint:
                AddPoint();
                AddComboPoint();
                break;
        }
    }

    private void AddComboPoint()
    {
        _comboPoints += 1;
        Debug.Log("Combo Points: " + _comboPoints);
        
        if (_comboPoints != 5)
        {
            return;
        }

        onComboCompleted?.Invoke();
        ClearComboPoints();
    }

    private void ClearComboPoints()
    {
        _comboPoints = 0;
    }

}  
