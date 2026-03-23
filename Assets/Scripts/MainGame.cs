using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{

    public static MainGame Instance = null ;
    public bool isUseUI;

    void Awake()
    {
        if(Instance == null) 
         Instance = this;
        else
        Destroy(this);

    }

    void Update()
    {
        if(isUseUI)
        {
            return;
        }
        else
        {
            //小人房间开始动
        }
    }




    
}
