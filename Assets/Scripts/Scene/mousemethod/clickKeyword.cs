using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickKeyword : MonoBehaviour
{


    public void ClickMethod()
    {
        chatController.Instance.Page5.SetActive(true);

        for (int i = 0; i < 4; i++)
        {
            
            chatController.Instance.KeywordNewsQueue[i] = chatController.Instance.creatNews(3,i);
            Debug.Log(chatController.Instance.KeywordNewsQueue[i]);
            chatController.Instance.KeywordNewsQueue[i].number = i;
            chatController.Instance.KeywordNewsQueue[i].Type = 1;
            
            chatController.Instance.KWNewsPrefabQueue[i] = chatController.Instance.creatNewsPrefab(chatController.Instance.KeywordNewsQueue[i]);//实例化
            chatController.Instance.KWNewsPrefabQueue[i].transform.position = chatController.Instance.newSlots[i].position;//放入对应位置
           
        }

    }   



}
