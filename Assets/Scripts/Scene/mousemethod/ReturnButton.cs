using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour
{
    public void ClickReturn()
    {
        foreach (GameObject video in videoController.Instance.VideoPrefabQueueNotOnLook)
        {
                if(video!=null && video.transform.GetChild(8).GetComponent<Text>().text == "0")
                Destroy(video);

        }
        //for(int i = 0; i < 6; i++)
        //{
        //    videoController.Instance.content.transform.GetChild(i).gameObject.SetActive(true);
        //}



        videoController.Instance.selectVideoPage.SetActive(false);

    }
}
