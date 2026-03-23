using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class newsController : MonoBehaviour
{
    public static newsController Instance;

    public BaseNews[] newsQueue = new BaseNews[4];           //消息信息队列
    public GameObject[] newsPrefabQueue;   //消息实例队列
    public GameObject[] slotPos;           //消息槽
    public Transform slotParent;
    public Text sendNewsPos;



    public BaseNews sendNews;           //发送消息信息队列
    public int sendNewsNumber;


    public int[] newsnember  =new int[10];
    public bool openvedio;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
       
        
    }



    public BaseNews creatNews( int type) //生成一个消息信息在信息队列中
    {
        BaseNews baseNews = new BaseNews();
        
        baseNews= ReadExcel.Instance.getNewsData(type);

        return baseNews;


    }

    public GameObject creatNewsPrefab (BaseNews baseNews ) //生成一个消息实例
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/UI/News");
        GameObject news =  Instantiate(obj);
        news.transform.SetParent(slotParent);
        
        Text Content= news.transform.GetChild(1).GetComponent<Text>();
        Content.text = baseNews.newsContent;
        Text number= news.transform.GetChild(2).GetComponent<Text>();
        number.text = baseNews.number.ToString() ;

        return news;
    }


    public void refrechNews(int type) //生成消息
    {
        int NewsNumber = UnityEngine.Random.Range(2, 5);
        newsnember[type] = NewsNumber;

        for (int i = 0; i < NewsNumber; i++)
        {
            newsQueue[i] = creatNews(type);
            newsQueue[i].number = i;
            newsQueue[i].Type = type;
            newsPrefabQueue[i] = creatNewsPrefab(newsQueue[i]);//实例化
            newsPrefabQueue[i].transform.position = slotPos[i].transform.position;//放入对应位置
            GameDataManger.Instance.NewsQueue[(type-1)*4+i] = newsQueue[i];           //存入游戏信息队列
        }
    }

    public void LoadNews(int type)//读取消息
    {
        for (int i = 0; i < 4; i++)
        {
            if( GameDataManger.Instance.NewsQueue[(type-1)*4+i] != null)
            {
                if( GameDataManger.Instance.NewsQueue[(type-1)*4+i].newsContent != null)
                {
                    
                    newsQueue[i] = GameDataManger.Instance.NewsQueue[(type-1)*4+i];
                    newsPrefabQueue[i] = creatNewsPrefab(newsQueue[i]);
                    newsPrefabQueue[i].transform.position = slotPos[i].transform.position;
                    newsnember[type] += 1;

                } 
            }
            
            
        }
    }


    public void clearQueue()
    {
        foreach (GameObject news in newsPrefabQueue)
        {
            if (news != null)
            {
                Destroy(news);
            }
        }
    }

    public void addNews(int type ,bool isopen)//增加消息
    {
        if (newsnember[type] < 4)
        {
            BaseNews bn = creatNews(type);
            if(isopen)
            {
                newsQueue[newsnember[type]] = bn;
                newsPrefabQueue[newsnember[type]] = creatNewsPrefab(newsQueue[newsnember[type]]);
                newsPrefabQueue[newsnember[type]].transform.position = slotPos[newsnember[type]].transform.position;
            }
            GameDataManger.Instance.NewsQueue[(type-1)+newsnember[type]] = bn;           //存入游戏信息队列
            newsnember[type] += 1;
        }
    }


    public void DeletNews(int number ,int type)
    {

        Destroy(newsPrefabQueue[number]);
        for (int i = number; i < newsnember[type]-1; i++)
        {
            if(newsQueue[i+1]!=null)
            {
                
                newsQueue[i] =newsQueue[i+1];
                newsQueue[i].number = i;
                GameDataManger.Instance.NewsQueue[(type-1)*4+i] = newsQueue[i]; 

                newsPrefabQueue[i] = newsPrefabQueue[i+1];
                Text Nnumber = newsPrefabQueue[i].transform.GetChild(2).GetComponent<Text>();
                Nnumber.text = i.ToString();
                LeanTween.move(newsPrefabQueue[i],slotPos[i].transform.position,0.5f);

            }
        }
        newsnember[type]-=1;
        for (int i = newsnember[type]; i < 4; i++)
        {
            GameDataManger.Instance.NewsQueue[(type-1)*4+i] = null;
            newsQueue[i]=null;
        }


        
    }



     public void sendaNews()
    {
        
        DeletNews(sendNewsNumber,1);

        //打开消息弹窗


    }







}
