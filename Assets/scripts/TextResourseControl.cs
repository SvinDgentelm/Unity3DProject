using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextResourseControl : MonoBehaviour
{
    public Text text;
    public string resourseName;

    private void ChangeText(float resourseValue)
    {

        text.text = ((int)resourseValue).ToString();

    }

    private void Start()
    {

        var resourse = playerResurs.Find(resourseName);
        ChangeText(resourse.GetValue());
        resourse.ValueChangeEvent += ChangeText;

    }
}
