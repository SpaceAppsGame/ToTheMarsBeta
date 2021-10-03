using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealthStat
{
    static private float maxValue = 100000;
    static private float minValue = 0;
    static private float dangerValue = 66000;
    private float Value;
    private bool isInjured; 

    public HealthStat()
    {
        Value = maxValue;
        isInjured = false;
    }

    public bool Modifier(float value)
    {
        Value += value;
        if (Value > maxValue)
        {
            Value = maxValue;
        }
        //else if (Value > dangerValue)
        //{
        //    isInjured = false;
        //}
        else if(Value <= dangerValue)
        {
            isInjured = true;
        }
        else if (Value < minValue)
        {
            Value = minValue;
            return false; // RIP
        }
        return true;
    }

    public bool IsInjured()
    {
        return isInjured;
    }

    public float GetPercent()
    {
        return Value/maxValue;
    }
}