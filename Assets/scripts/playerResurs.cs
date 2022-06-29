using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerResurs : MonoBehaviour
{
    public static playerResurs Find(string name)
    {
        foreach (var resourse in FindObjectsOfType<playerResurs>())
        {

            if (resourse.Name == name)
            {

                return resourse;
            }

        }
        return null;
    }


    [SerializeField] private float value = 0;
    [SerializeField] private string Name = "Money";
   

    public float GetValue() => value;

    public void ChangeValue(float change)
    {

        if (value <= 0)
        {

            value = 0;

        }

        value += change;
        if (ValueChangeEvent != null)
        {

            ValueChangeEvent(value);

        }

    }

    public event Action <float> ValueChangeEvent;



}
