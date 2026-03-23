using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickpeople : MonoBehaviour
{
    public int peopleName;
    
    public void ClickMethod()
    {        
        chatController.Instance.Page1.SetActive(false);

        if (peopleName == 1)
        {
            chatController.Instance.Page4.SetActive(true);
        }
        else if(peopleName == 2)
        {
            chatController.Instance.Page6.SetActive(true);

        }
        else
        {
            chatController.Instance.Page7.SetActive(true);

        }

    }



}
