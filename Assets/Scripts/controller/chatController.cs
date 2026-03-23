using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatController : MonoBehaviour
{
     public static chatController Instance = null;
     public GameObject Page1;
     public GameObject Page2;
     public GameObject Page3;
     public GameObject Page4;
     public GameObject Page6;
     public GameObject Page7;
     public GameObject Page5;

     public Transform slotParent;
     public BaseNews[] KeywordNewsQueue;
     public GameObject[] KWNewsPrefabQueue;
     public Transform[] newSlots;


     void Awake()
     {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);


        KeywordNewsQueue = new BaseNews[4];
     }


     public BaseNews creatNews( int type,int number) //生成一个消息信息在信息队列中
    {
        BaseNews baseNews = new BaseNews();
        
        baseNews= ReadExcel.Instance.getNewsData(type,number);

        return baseNews;


    }

    public GameObject creatNewsPrefab (BaseNews baseNews ) //生成一个消息实例
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/UI/News");
        GameObject news =  Instantiate(obj);
        Debug.Log(news);
        news.transform.SetParent(slotParent);
        
        Text Content= news.transform.GetChild(1).GetComponent<Text>();
        Content.text = baseNews.newsContent;
        Text number= news.transform.GetChild(2).GetComponent<Text>();
        number.text = baseNews.number.ToString() ;

        return news;
    }
}
