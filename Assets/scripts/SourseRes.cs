using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourseRes : MonoBehaviour
{
    public string resoursName;
    public float value;


    public void CollectResours(bool destroyObject)
    {
        playerResurs.Find(resoursName).ChangeValue(value);
        if (destroyObject)
        {

            Destroy(gameObject);

        }


    }

}
