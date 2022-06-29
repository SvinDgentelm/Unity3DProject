using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManaDeath : MonoBehaviour
{

    private playerResurs resource;
    

    private void Start()
    {
        resource = playerResurs.Find("water");
    }

    void Update()
    {
        if (resource.GetValue() == 0)
        {

            SceneManager.LoadScene(0);

        }
    }
}
