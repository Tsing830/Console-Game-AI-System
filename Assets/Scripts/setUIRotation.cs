using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUIRotation : MonoBehaviour
{

    public GameObject PlayerPos;
    public GameObject PhonePos;


    

    void Update()
    {
        Vector2 PlayerSPos=Camera.main.WorldToScreenPoint(PlayerPos.transform.position);
        Vector2 PhoneSPos=Camera.main.WorldToScreenPoint(PhonePos.transform.position);


        if(PlayerSPos.x > PhoneSPos.x)
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            
        }
    }
}
