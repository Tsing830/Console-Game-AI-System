 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance = null;

    [Header("人物状态")]
    public int state1 ; //日常状态 0 = 休息  ， 1 = 学习/工作 ， 2 = 放松     ， 3 =  短视频 4 = 上床准备睡觉 
    public int state2 ; //事件状态 0 = 无事件，    ， 2 = 减肥计划 ， 3 = 谈恋爱
    public int previousState;



    [Header("人物数值Layer1")]
    public float selfControll;
    public float mood;
    public float money;
    public float Anxious;

    

    [Header("人物数值Layer2")]
    public float Concentration;
    public float DailyAnxious;
    public float sleepy;
    
    [Header("人物数值Layer3——短视频")]
    public float joy;
    public float[] videolike;
    public float[] videotried;

    public int Days;
    public float times;

    public bool sendaNews;

    public float DownSpeed;
    public float maxConcentration;
    public bool  Isup;
    public bool  sendLock;
    public float sendLocktime;
    private float locktime;

    public float timeSpeed;


    public bool isOpenVideo; 
    public bool isCloseVideo;
    public Transform canv;

    public GameObject phonePanel;
    public GameObject model;

    public bool isClickApp1;
    public float randomNum = 0f;
    public float temp = 0f;

    public GameObject likeImage;
    public GameObject boringImage;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);


        if(!GameDataManger.Instance.isfirst)
        {
            Debug.Log("load");
            GameDataManger.Instance.Load();
        }
        else
        {
            Debug.Log("start");

            Days = 0;
            state2 = 0;
            selfControll = 80;
            mood = 75;
            Anxious =20;
        }
        refrechData();


        randomNum = Random.Range(2, 5);


    }

    void Update()
    {
        spendDay();
        baseStateChange();
        takevideo();
        closevideo();
        BuildMessage();


    }

  

    public void takevideo() //打开短视频软件
    {
        if(isOpenVideo)
        {
            isOpenVideo = false;
            previousState = state1;
            state1 = 3;
            MainScene ms = (MainScene)GameRoot.Instance.SceneSystem.sceneState;
            ms.panelManager.Pop();
            ms.panelManager.Pop();
            ms.panelManager.Pop();
            ms.panelManager.Push(new LookVideoPanel());
            phonePanel.SetActive(true);
            //PhonePanelController.Instance.Debugstate("进入短视频");

            joy = 50;   
            videoController.Instance.RefreshVideo();
            
        }
        
    }

    public void closevideo()
    {
        if(isCloseVideo)
        {
            
            isCloseVideo = false;
            MainScene ms = (MainScene)GameRoot.Instance.SceneSystem.sceneState;
            ms.panelManager.Pop(); 
            ms.panelManager.Push(new MainPanel());
            ms.panelManager.Push(new AppPanel());


            phonePanel.SetActive(false);
            state1 = previousState;
            Debug.Log(state1);
            DailyAnxious = Anxious+20;



        }
    }

    public void baseStateChange()
    {
        if(state1 == 0)
        {
            Concentration = maxConcentration - 40;
        }
        else if(state1 == 1)
        {
            if(Isup)
            {
                if( Concentration < maxConcentration  && Concentration > maxConcentration - 50  )
                {
                    Concentration += DownSpeed * Time.deltaTime;
                }
                else if(Concentration >= maxConcentration )
                {
                    Isup = false;
                }
            }
            else if(Concentration > maxConcentration - 50 )
            {
                Concentration -= DownSpeed * Time.deltaTime;
            }
            else
            {
                state1 = 2;
            }
            
        }
        else if(state1 == 2)
        {
            Concentration = maxConcentration - 50;

        }
        else if(state1 == 3)
        {
            if(joy < 0 || DailyAnxious >80)
            {
                
                isCloseVideo = true;
                
            }
        }

        if( sendLock )
        {
            if(locktime >0)
            {
                locktime -= Time.deltaTime;

            }
            else
            {
                sendLock = false;
                locktime = sendLocktime;
            }
        }
    }


    public void spendDay()
    {
        times += Time.deltaTime * timeSpeed;
        if(times >  1500)
        {
            state2 = 4;
            //MainScene ms = (MainScene)GameRoot.Instance.SceneSystem.sceneState;
            //ms.PanelManager
            GameRoot.Instance.SceneSystem.SetScene(new SearchScene());
            //ms.panelManager.Push(new NextDayPanel());
            refrechData();


        }
    }


    public void refrechData()
    {
        Days += 1;
        if((Days-1) % 7 +1 < 6)
        {
            times = 1020;
        } 
        else
        {
            times = 420;
        }
         state1 = 0;
        sendaNews = false;
        sendLock = false;
        isOpenVideo = false;
        locktime = sendLocktime;
        Isup = true;
        maxConcentration = selfControll;
        Concentration = selfControll-30;
        DailyAnxious = Anxious;
        Anxious +=2;

    }

    
    public void BuildMessage()
    {
        if(isClickApp1)
        {
            temp += Time.deltaTime * 1;
            if(temp>randomNum)
            {
                newsController.Instance.addNews(1, false);
                temp = 0;
                randomNum= Random.Range(2, 5);
            }
        }
    }



  
}
