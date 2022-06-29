using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDrain : MonoBehaviour
{

    public string resourceName;
    public float drainPerSecond = 0.3f;
    private playerResurs resource;


    void Start()
    {
        resource = playerResurs.Find(resourceName);
    }

    
    void Update()
    {
        resource.ChangeValue(-drainPerSecond * Time.deltaTime);
    }
}
