using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkContinue : MonoBehaviour
{


    public GameObject continueB;


    void Awake()
    {
        if(GameDataManger.Instance.continueButten)
        {
            continueB.SetActive(true);
        }
    }


}
