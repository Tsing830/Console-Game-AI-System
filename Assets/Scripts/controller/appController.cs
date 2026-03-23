using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appController : MonoBehaviour
{

    public static appController Instance ;

    public bool[] isLoad;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);


        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
