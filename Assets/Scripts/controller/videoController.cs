using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;
using UnityEngine.UI;

public class videoController : MonoBehaviour
{
    public static videoController Instance;

    public BaseVideo[] VideoQueue = new BaseVideo[6] ;      //视频信息队列
    public GameObject[] VideoPrefabQueue;                   //视频实例队列
    public GameObject[] slotPos;                             //视频槽
    public GameObject videoQueueParent;


    public BaseVideo[] VideoQueueNotOnLook =new BaseVideo[6];  //待选视频信息队列
    public GameObject[] VideoPrefabQueueNotOnLook;              //待选视频实例队列
    public GameObject[] SelectSlotPos ;                         //待选视频槽
    public GameObject   selectParent;

    public GameObject[] videoTypePos;                           //视频类型选择槽
    public int[]        videotype;                              //视频类型选择类型
    public GameObject[] videoTypePrefab;                        //视频选择实例
    public GameObject videoTypeParent;

    public int[] AlreadyLookvideo;                              //记录已经看过的视频
    public int[] ForecastAlreadyLookvideo;                      //预测记录已经看过的视频
    public int   videomemorylenght;                             //记忆长度

    public int[] PlayerBehaviorForecast;                        //行为预测
    public float[] forecastTried;
    public float[] forecastLike;
    public float forecastSelfcontrol;


    public BaseVideo[] AlreadyBuildUpVideo=new BaseVideo[40];
    public int  AlreadyBuildUpNum=0;


    public int MaxColumn;
    public bool islookVideo;

    public GameObject belong;
    public Transform videoCanvas;
    public Transform DeletPos;
    
    
    public float looktime;


    public int brushnumber;                                     //刷掉视频数量


    public GameObject selectVideoPage;
    public GameObject content;
    private float[] size = { 315.6f, 435.76f, 567.66f, 677.434f, 801.53f };


    public int[] Num = new int[13];  //相应按钮下视频数量
    public bool[] bools = new bool[13];  //相应按钮是否已被激活



    public Text joytext;
    public Text Anxioustext;
    float temp = 0f;


    public int[] behavior;

    public Transform[] test;
    void Awake()
    {
        Instance = this;
        islookVideo = true;

        AlreadyLookvideo = new int[videomemorylenght];
        for (int i = 0; i < videomemorylenght; i++)
        {
            AlreadyLookvideo[i] = -1;
        }
       

            
    }
    void Start()
    {
        
        looktime = 200;
        creatvideoType();

    }

    void Update()
    {


        if (!islookVideo)
        {
            return;//暂停运行
        }
        else
        {
            joytext.text = ScoreController.Instance.joy.ToString();
            Anxioustext.text = ScoreController.Instance.DailyAnxious.ToString();
            

            looktime -=Time.deltaTime * ScoreController.Instance.timeSpeed * 60;
            if(looktime < 0  && islookVideo )
            {
                lookFirstVideo();
            }

            for (int i = 0; i < 6; i++)
            {
                if (bools[i] == true && Num[i] < 6)
                {
                    float time = Random.Range(2, 5);

                    temp += Time.deltaTime * 1;

                    if(temp >= 2)
                    {
                        Num[i]++;
                        content.GetComponent<RectTransform>().sizeDelta = new Vector2(726.339f, size[Num[i] - 2]);
                        for (int j = 0; j < VideoPrefabQueueNotOnLook.Length; j++)
                        {
                            if(VideoPrefabQueueNotOnLook[j] != null)
                            VideoPrefabQueueNotOnLook[j].transform.position = VideoPrefabQueueNotOnLook[j].GetComponent<Drag>().startpos;
                        }
                        videoController.Instance.creatSelectVideoPrefab(Num[i]-1, i + 1);
                        

                        temp = 0f;

                    }




                }
            }
        }

    }




    public BaseVideo creatVideo(int  number = 4 ,int type=0)//随机生成一个视频信息
    {
        BaseVideo basevideo = new BaseVideo();
        basevideo= ReadExcel.Instance.getVideoData(type);
        basevideo.Number = number;
        

        return basevideo;

    }
  
    public GameObject creatVideoPrefab( BaseVideo basevideo )//根据视频信息生成实例
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/UI/video" + basevideo.Typeint.ToString());
        GameObject video = Instantiate(obj);
        video.transform.SetParent(videoCanvas);

        Text name= video.transform.GetChild(4).GetComponent<Text>();
        name.text = basevideo.Name;
        Text Type = video.transform.GetChild(5).GetComponent<Text>();
        Type.text = basevideo.Type;
        Text videotime= video.transform.GetChild(6).GetComponent<Text>();
        videotime.text = basevideo.videoTime.ToString();

        if(int.Parse(video.transform.GetChild(6).GetComponent<Text>().text) > 300)
        {
            video.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }

        Text number = video.transform.GetChild(7).GetComponent<Text>();
        number.text = basevideo.Number.ToString();
        Text isonlookQueue = video.transform.GetChild(8).GetComponent<Text>();
        isonlookQueue.text = basevideo.isonlookQueue.ToString();

        return video;
    }


    public void RefreshVideo()    //随机生成五个视频
    {
        for (int i = 0; i < VideoQueue.Length-1; i++)
        {
            VideoQueue[i] =creatVideo();
            VideoQueue[i].Number = i;
            VideoQueue[i].isonlookQueue = 1;
            VideoPrefabQueue[i] = creatVideoPrefab(VideoQueue[i]);
            VideoPrefabQueue[i].transform.position = slotPos[i].transform.position;


            
        }
        refrechPbForecast(0);
    }

    public void creatSelectVideoPrefab(int num,int type=0)
    {
        VideoQueueNotOnLook[num] = creatVideo(num+5, type);
        AlreadyBuildUpVideo[AlreadyBuildUpNum] = VideoQueueNotOnLook[num];
        AlreadyBuildUpNum++;
        VideoQueueNotOnLook[num].Number = num+5;
        VideoQueueNotOnLook[num].isonlookQueue = 0;
        VideoPrefabQueueNotOnLook[num] = creatVideoPrefab(VideoQueueNotOnLook[num]);
        VideoPrefabQueueNotOnLook[num].transform.SetParent(selectParent.transform);
        VideoPrefabQueueNotOnLook[num].transform.position = SelectSlotPos[num].transform.position;
    }

    public bool loadSelectVideoPrefab(int num1,int num2, int type)
    {
        if (AlreadyBuildUpVideo[num1] != null)
        {
            if (AlreadyBuildUpVideo[num1].Typeint == type)
            {
                VideoQueueNotOnLook[num2] = AlreadyBuildUpVideo[num1];
                VideoQueueNotOnLook[num2].Number = num2 + 5;
                VideoQueueNotOnLook[num2].isonlookQueue = 0;
                VideoPrefabQueueNotOnLook[num2] = creatVideoPrefab(VideoQueueNotOnLook[num2]);
                VideoPrefabQueueNotOnLook[num2].transform.SetParent(selectParent.transform);
                VideoPrefabQueueNotOnLook[num2].transform.position = SelectSlotPos[num2].transform.position;
                return true;
            }
            else
                return false;
        }
        else
            return false;

    }
     public void deleteVideo(string name)  //如果从生成视频栏拖出视频 在存储视频的数组中删除该视频
    {
        for(int i= 0; i < AlreadyBuildUpVideo.Length; i++)
        {
            if (AlreadyBuildUpVideo[i] != null) 
            {
                if(AlreadyBuildUpVideo[i].Name == name)
                {
                    AlreadyBuildUpVideo[i] = null;
                    break;
                }
            }
        }
    }



        


    public void lookFirstVideo()  //看了一个视频
    {
       
        
        ScoreController.Instance.DailyAnxious += 2;
        for (int i = 0; i < 2; i++)
        {
            PlayerBehaviorForecast[i] = PlayerBehaviorForecast[i+1];
        }
        refrechPbForecast(2);


        if(PlayerBehaviorForecast[0]  == 1)
        {
            ScoreController.Instance.timeSpeed = 1;
            looktime= VideoQueue[1].videoTime;
            ScoreController.Instance.videotried[VideoQueue[0].Typeint-1] += 25;
            ScoreController.Instance.selfControll += 2;
            ScoreController.Instance.DailyAnxious -= 4;
            //PhonePanelController.Instance.Debugstate("看完长视频");
            addAvideoToMemoryQueue(VideoQueue[0].Typeint-1);
            brushnumber =0;
            checkAlreadyLookVideo();
            ScoreController.Instance.likeImage.SetActive(true);
            StartCoroutine("hide", ScoreController.Instance.likeImage);


        }
        else if(PlayerBehaviorForecast[0]  == 2)
        {
            ScoreController.Instance.timeSpeed = 1;
            ScoreController.Instance.videotried[VideoQueue[0].Typeint-1] += 10;
            looktime= Random.Range(80,(int)VideoQueue[1].videoTime);
            //PhonePanelController.Instance.Debugstate("没看完长视频");
            ScoreController.Instance.joy -= 10 ;

            ScoreController.Instance.selfControll -= 0.5f;
            brushnumber =0;
        }
        else if(PlayerBehaviorForecast[0] == 3)
        {
            looktime =60;                   //直接刷掉
            //PhonePanelController.Instance.Debugstate("刷掉长视频");
            ScoreController.Instance.joy -= 4 ;
            ScoreController.Instance.selfControll -= 0.2f;
            brushnumber +=1;
        }
        else if(PlayerBehaviorForecast[0] == 4)
        {
            ScoreController.Instance.timeSpeed = 0.5f;
            addAvideoToMemoryQueue(VideoQueue[0].Typeint-1);
           // PhonePanelController.Instance.Debugstate("看完短视频");
            ScoreController.Instance.selfControll -= 0.2f;
            looktime= VideoQueue[1].videoTime;
            ScoreController.Instance.joy += 4 ;
            brushnumber =0;
                checkAlreadyLookVideo();

        } 
        else if(PlayerBehaviorForecast[0] == 5)
        {
            ScoreController.Instance.timeSpeed = 0.5f;
            looktime= 30;
            //PhonePanelController.Instance.Debugstate("没看完短视频");
            ScoreController.Instance.joy -= 8 ;
            brushnumber +=1;
        }

        deletVideofromQueue(0);

    }

    //    if(VideoQueue[0].videoTime > 300)            // 判断长短视频
    //     {
    //         ScoreController.Instance.timeSpeed = 1;
    //         if(precent(ScoreController.Instance.videolike[VideoQueue[0].Typeint-1] - ScoreController.Instance.videotried[VideoQueue[0].Typeint-1]
    //                 +ScoreController.Instance.selfControll - 60 ))
    //         {
    //             if(VideoQueue[0].videoQuality > 70  && precent(ScoreController.Instance.selfControll))
    //             {
    //                 looktime= VideoQueue[0].videoTime;
    //                 ScoreController.Instance.videotried[VideoQueue[0].Typeint-1] += 25;
    //                 ScoreController.Instance.selfControll += 2;
    //                 ScoreController.Instance.DailyAnxious -= 4;
    //                 PhonePanelController.Instance.Debugstate("看完长视频");
    //                 addAvideoToMemoryQueue(VideoQueue[0].Typeint-1);
    //                 brushnumber =0;

    //             }
    //             else
    //             {
    //                 ScoreController.Instance.videotried[VideoQueue[0].Typeint-1] += 10;
    //                 looktime= Random.Range(80,(int)VideoQueue[0].videoTime);
    //                 PhonePanelController.Instance.Debugstate("没看完长视频");
    //                 ScoreController.Instance.joy -= 10 ;

    //                 ScoreController.Instance.selfControll -= 0.5f;
    //                 brushnumber =0;
    //             }
    //         }
    //         else
    //         {
    //             looktime =30;                   //直接刷掉
    //             PhonePanelController.Instance.Debugstate("刷掉长视频");
    //             ScoreController.Instance.joy -= 4 ;
    //             ScoreController.Instance.selfControll -= 0.2f;
    //             brushnumber +=1;

    //         }
    //     }
    //     else
    //     {
    //         ScoreController.Instance.timeSpeed = 0.5f;

    //         if(precent(ScoreController.Instance.videolike[VideoQueue[0].Typeint-1] - ScoreController.Instance.videotried[VideoQueue[0].Typeint-1]
    //                     - 40 + ScoreController.Instance.selfControll))
    //             {
    //                 addAvideoToMemoryQueue(VideoQueue[0].Typeint-1);
    //                 PhonePanelController.Instance.Debugstate("看完短视频");
    //                 ScoreController.Instance.selfControll -= 0.2f;
    //                 looktime= VideoQueue[0].videoTime;
    //                 ScoreController.Instance.joy += 4 ;
    //                 brushnumber =0;
    //             }
    //             else
    //             {
    //                 looktime= 30;
    //                 PhonePanelController.Instance.Debugstate("没看完短视频");
    //                 ScoreController.Instance.joy -= 8 ;
    //                 brushnumber +=1;

    //             }

    //     }



    //改变数值





    public void deletVideofromQueue(int number ,bool isup =true )//从队列删除视频 自动补充最后一个
    {
        if(isup)
        StartCoroutine(Hidevideo(VideoPrefabQueue[number],isup ));
        else
        Destroy(VideoPrefabQueue[number]);
        

        for (int i = number; i < 5; i++)
        {
                VideoUp(VideoPrefabQueue[i] , i);

                if(i!=4)
                {
                    VideoQueue[i]=VideoQueue[i+1];
                    VideoPrefabQueue[i]=VideoPrefabQueue[i+1];
                    VideoQueue[i].Number -=1;
                }
                else
                {
                    VideoQueue[i] = creatVideo();
                    VideoQueue[i].isonlookQueue = 1;
                    VideoPrefabQueue[i]=creatVideoPrefab(VideoQueue[i]);
                    VideoPrefabQueue[i].transform.position = slotPos[i].transform.position - new Vector3(0,120,0);
                    VideoUp(VideoPrefabQueue[i] , i+1);

                    
                }

                Text Vnumber = VideoPrefabQueue[i].transform.GetChild(7).GetComponent<Text>();
                Vnumber.text = VideoQueue[i].Number.ToString();

        }
            
            
    }


    public void addVideoToQueue(int number , BaseVideo basevideo , GameObject thisVideo)//加入视频到队列
    {
        Destroy(VideoPrefabQueue[4]);
         for (int i = 5; i > number-1; i--)
        {
            if(i != number)
            {
                VideoQueue[i]=VideoQueue[i-1];
                VideoPrefabQueue[i]=VideoPrefabQueue[i-1];
                VideoQueue[i].Number +=1;
                Text Vnumber = VideoPrefabQueue[i].transform.GetChild(7).GetComponent<Text>();
                Vnumber.text = VideoQueue[i].Number.ToString();
            }
            else
            {
                VideoQueue[i] = basevideo;
                VideoQueue[i].Number = i;
                VideoQueue[i].isonlookQueue = 1;
                VideoPrefabQueue[i] = thisVideo;
                Text isonLookQueue = VideoPrefabQueue[i].transform.GetChild(8).GetComponent<Text>();
                isonLookQueue.text = basevideo.isonlookQueue.ToString();
                Text Vnumber = VideoPrefabQueue[i].transform.GetChild(7).GetComponent<Text>();
                Vnumber.text = VideoQueue[i].Number.ToString();
            }
        }
    } 


    public void moveVideo( int to,int from = 5)  //短视频在视频队列中移动
    {
        for (int i = 0; i < 5; i++)
        {
            if(i!=from)
            {
                if(to>from)
                {
                    if(i<=to && i>from)
                    {
                        Vector3 moveto =new Vector3(0,0,0);
                        moveto =slotPos[VideoQueue[i].Number].transform.position;
                        moveto += new Vector3(0,120,0);
                        LeanTween.move(VideoPrefabQueue[i],moveto,0.5f);
                    }
                    else
                    {
                        LeanTween.move(VideoPrefabQueue[i],slotPos[VideoQueue[i].Number].transform.position,0.5f);
                    }
                }
                else if(to<from)
                {
                    if(i>=to && i<from)
                    {
                        Vector3 moveto =new Vector3(0,0,0);
                        moveto =slotPos[VideoQueue[i].Number].transform.position;
                        moveto -= new Vector3(0,120,0);
                        LeanTween.move(VideoPrefabQueue[i],moveto,0.5f);
                    }
                    else
                    {
                        LeanTween.move(VideoPrefabQueue[i],slotPos[VideoQueue[i].Number].transform.position,0.5f);
                    }
                }
                else
                {
                    LeanTween.move(VideoPrefabQueue[i],slotPos[VideoQueue[i].Number].transform.position,0.5f);
                }
            }
            
        }

            
    }
   
    public void moveVideoChange(int to,int from)  //放下短视频后改变短视频的顺序
    {
        if(to>from)
        {
            BaseVideo tempB = new BaseVideo();
            GameObject tempG = new GameObject();
            tempG = VideoPrefabQueue[from];
            tempB =  VideoQueue[from];
            for (int i = from; i < to+1; i++)
            {
                if(i!=to)
                {
                    VideoQueue[i]=VideoQueue[i+1];
                    VideoQueue[i].Number -= 1;
                    VideoPrefabQueue[i]= VideoPrefabQueue[i+1];
                    Text Vnumber = VideoPrefabQueue[i].transform.GetChild(7).GetComponent<Text>();
                    Vnumber.text = VideoQueue[i].Number.ToString();
                }
                else
                {
                    VideoQueue[i] = tempB;
                    VideoQueue[i].Number = to;
                    VideoPrefabQueue[i] = tempG;
                    Text Vnumber = VideoPrefabQueue[i].transform.GetChild(7).GetComponent<Text>();
                    Vnumber.text = VideoQueue[i].Number.ToString();
                }
            }
        }
        else if(to<from)
        {
            BaseVideo tempB = new BaseVideo();
            GameObject tempG = new GameObject();
            tempG = VideoPrefabQueue[from];
            tempB =  VideoQueue[from];
            for (int i = from; i > to-1; i--)
            {
                if(i!=to)
                {
                    VideoQueue[i]=VideoQueue[i-1];
                    VideoQueue[i].Number += 1;
                    VideoPrefabQueue[i]= VideoPrefabQueue[i-1];
                    Text Vnumber = VideoPrefabQueue[i].transform.GetChild(7).GetComponent<Text>();
                    Vnumber.text = VideoQueue[i].Number.ToString();
                }
                else
                {
                    VideoQueue[i] = tempB;
                    VideoQueue[i].Number = to;
                    VideoPrefabQueue[i] = tempG;
                    Text Vnumber = VideoPrefabQueue[i].transform.GetChild(7).GetComponent<Text>();
                    Vnumber.text = VideoQueue[i].Number.ToString();
                }
            }
        }
    }

    public void VideoUp(GameObject videoPrefab , int number ) //短视频向上移动
    {
        if(number!= 0)
        LeanTween.move(videoPrefab,slotPos[number-1].transform.position,0.5f);
    }



    public bool precent(float number)
    {
        int checknumber = Random.Range(0,101);
         
        if(checknumber<number)
            return true;
        else
            return false;
    }
 

    IEnumerator Hidevideo(GameObject video , bool isup )    //短视频淡出
    {
        if(isup)
        {
            LeanTween.move(video,video.transform.position + new Vector3(0,120,0),0.5f);
        }
        
        yield return new WaitForSeconds(0.5f);   
        Destroy(video);
        
    }
    IEnumerator Deletvideo(GameObject video )    //短视频淡出
    {
        
        yield return new WaitForSeconds(0.5f);   
        Destroy(video);
        
    }







    public void creatvideoType()
    {
        for (int i = 0; i < videotype.Length; i++)
        {
            videoTypePrefab[i] = creatvideoTypePrefab(videotype[i]);
            videoTypePrefab[i].transform.SetParent(videoTypeParent.transform);
            videoTypePrefab[i].transform.position = videoTypePos[i].transform.position;


        }
    }


    public GameObject creatvideoTypePrefab(int type)
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/UI/videoType" + type.ToString());
        GameObject videoType = Instantiate(obj);


        Text typeint = videoType.transform.GetChild(0).GetComponent<Text>();
        typeint.text = type.ToString();
        Text typeString = videoType.transform.GetChild(1).GetComponent<Text>();
        typeString.text = ReadExcel.Instance.typeIntToString(type);
        return videoType;
    }



    public void checkAlreadyLookVideo()
    {
        int memory = 0;
        int nowVdeoType = AlreadyLookvideo[videomemorylenght-1];
        for (int i = 0; i < videomemorylenght -1 ; i++)
        {
            if(AlreadyLookvideo[i+1] != -1)
            {
                if(AlreadyLookvideo[i+1] == AlreadyLookvideo[i])
                {
                    memory++;
                }
                else
                {
                    memory = 0;
                }
            }
        }

        if(memory >= 3)
        {
            ScoreController.Instance.videotried[AlreadyLookvideo[videomemorylenght-1]] += 25;
            Debug.Log("Yes" + nowVdeoType+ "fatigue");
            ScoreController.Instance.boringImage.SetActive(true);
            StartCoroutine("hide", ScoreController.Instance.boringImage);
            if(nowVdeoType == 2 || nowVdeoType ==3|| nowVdeoType ==4)
            {
                for (int i = 0; i < 13; i++)
                {
                    if(ScoreController.Instance.videotried[i] >= 20)
                    ScoreController.Instance.videotried[i] -= 10;
                    else
                    ScoreController.Instance.videotried[i] = 10;

                }
            }
        }
    }


 

    public void addAvideoToMemoryQueue(int type)
    {
       
       
            for (int i = 0; i < videomemorylenght; i++)
            {

                if(i !=videomemorylenght-1 )
                AlreadyLookvideo[i] = AlreadyLookvideo[i+1];
                else
                AlreadyLookvideo[i] = type;


            }
        
    }


       public void ForecastCALV( int nowvideoint)
    {
        int memory = 0;
        for (int i = 0; i < videomemorylenght -1 ; i++)
        {
            if(AlreadyLookvideo[i+1] != -1)
            {
                if(AlreadyLookvideo[i+1] == AlreadyLookvideo[i])
                {
                    memory++;
                }
                else
                {
                    memory = 0;
                }
            }
        }

        if(memory >= 3)
        {
            forecastTried[nowvideoint] += 25;
            Debug.Log("Predictions for" + nowvideoint+ "fatigue");
            if(nowvideoint == 2 || nowvideoint ==3 || nowvideoint ==4)
            {
                for (int i = 0; i < 13; i++)
                {
                    if(forecastTried[i] >= 20)
                    forecastTried[i] -= 10;
                    else
                    forecastTried[i] = 10;

                }
            }
        }
    }


    public void addFAVMQueue(int type)
    {
       
       
            for (int i = 0; i < videomemorylenght; i++)
            {

                if(i !=videomemorylenght-1 )
                ForecastAlreadyLookvideo[i] = ForecastAlreadyLookvideo[i+1];
                else
                ForecastAlreadyLookvideo[i] = type;


            }
        
    }

    public int[] getplayerBehavior(int from)
    {
        int[] pB = new int[3];

        forecastTried =  ScoreController.Instance.videotried;
        forecastLike =  ScoreController.Instance.videolike;
        forecastSelfcontrol  =  ScoreController.Instance.selfControll;

        ForecastAlreadyLookvideo = AlreadyLookvideo;


        for (int i = 0; i < 3; i++)
        {
            pB[i] = PlayerBehaviorForecast[i];
            
        }

        for (int i = 0; i < 3; i++)
        {
            
            if(i<from)
            {
                if(PlayerBehaviorForecast[i] == 1)
                {
                    if(VideoQueue[i].Typeint-1 != 4)
                    forecastTried[VideoQueue[i].Typeint-1] += 10;

                    addFAVMQueue(VideoQueue[i].Typeint-1);
                    addFAVMQueue(VideoQueue[i].Typeint-1);
                    forecastSelfcontrol +=2;
                }
                else if(PlayerBehaviorForecast[i] == 2)
                {
                    forecastTried[VideoQueue[i].Typeint-1] += 10;
                    forecastSelfcontrol -= 0.5f;
                }
                else if(PlayerBehaviorForecast[i] == 3)
                {
                    forecastSelfcontrol -= 0.2f;
                }
                else if(PlayerBehaviorForecast[i] == 4)
                {
                    forecastSelfcontrol -= 0.2f;
                    addFAVMQueue(VideoQueue[i].Typeint-1);
                }
               
            }
            else
            {
                // Debug.Log((VideoQueue[i].Typeint-1)+"的概率"+(forecastLike[VideoQueue[i].Typeint-1] - forecastTried[VideoQueue[i].Typeint-1]
                //             +forecastSelfcontrol - 60));
                if(VideoQueue[i].videoTime > 300)            // 判断长短视频
                {

                     Debug.Log("Predicts that video" + i + "has a" + (forecastLike[VideoQueue[i].Typeint-1] - forecastTried[VideoQueue[i].Typeint-1]
                            +20 )+ "%probability of being watched");
                    //ScoreController.Instance.timeSpeed = 1;
                    if(precent(forecastLike[VideoQueue[i].Typeint-1] - forecastTried[VideoQueue[i].Typeint-1]
                            +20 ))
                    {   
                       
                        
                        if(precent(forecastSelfcontrol))
                        {
                            // //ScoreController.Instance.videotried[VideoQueue[0].Typeint-1] += 25;
                            forecastSelfcontrol += 2;
                            // //ScoreController.Instance.DailyAnxious -= 4;
                            // //addAvideoToMemoryQueue(VideoQueue[0].Typeint-1);
                            addFAVMQueue(VideoQueue[i].Typeint-1);
                            addFAVMQueue(VideoQueue[i].Typeint-1);
                            if(VideoQueue[i].Typeint-1 != 4)
                                forecastTried[VideoQueue[i].Typeint-1] += 10;
                            ForecastCALV(VideoQueue[i].Typeint-1);
                            

                            pB[i] = 1;

                        }
                        else
                        {
                            forecastTried[VideoQueue[0].Typeint-1] += 10;
                            // looktime= Random.Range(80,(int)VideoQueue[0].videoTime);
                            // PhonePanelController.Instance.Debugstate("没看完长视频");
                            // ScoreController.Instance.joy -= 10 ;

                            forecastSelfcontrol -= 0.5f;
                            // brushnumber =0;
                            pB[i] = 2;

                        }
                    }
                    else
                    {
                        // looktime =30;                   //直接刷掉
                        // PhonePanelController.Instance.Debugstate("刷掉长视频");
                        // ScoreController.Instance.joy -= 4 ;
                        forecastSelfcontrol -= 0.2f;
                        // brushnumber +=1;
                        pB[i] = 3;

                        
                    }
                }
                else
                {
                    //ScoreController.Instance.timeSpeed = 0.5f;
                    Debug.Log("Predicts that video" + i + "has a" + (forecastLike[VideoQueue[i].Typeint-1] - forecastTried[VideoQueue[i].Typeint-1]+30 )+ "%probability of being watched");

                    if(precent(forecastLike[VideoQueue[i].Typeint-1] - forecastTried[VideoQueue[i].Typeint-1]+30
                               ))
                        {
                            // addAvideoToMemoryQueue(VideoQueue[0].Typeint-1);
                            // PhonePanelController.Instance.Debugstate("看完短视频");
                            forecastSelfcontrol -= 0.2f;
                            // looktime= VideoQueue[0].videoTime;
                            // ScoreController.Instance.joy += 4 ;
                            // brushnumber =0;
                            pB[i] = 4;
                            addFAVMQueue(VideoQueue[i].Typeint-1);
                            ForecastCALV(VideoQueue[i].Typeint-1);


                        }
                        else
                        {
                            // looktime= 30;
                            // PhonePanelController.Instance.Debugstate("没看完短视频");
                            // ScoreController.Instance.joy -= 8 ;
                            // brushnumber +=1;
                            pB[i] = 5;


                        }
                    
                }
            }

            
            
        }


        return pB;
    }



    public void refrechPbForecast( int from)
    {

        int[] newForecast = new int[3];
        newForecast = getplayerBehavior(from);

        for (int i = 0; i < 3; i++)
        {
                
            if(newForecast[i] == 1 || newForecast[i] == 4)
            {
                test[i].GetChild(0).gameObject.SetActive(true);
                test[i].GetChild(1).gameObject.SetActive(false);
                test[i].GetChild(2).gameObject.SetActive(false);
                //test[i].text = "看完";
            }
            else  if(newForecast[i] == 3 || newForecast[i] == 5)
            {
                test[i].GetChild(1).gameObject.SetActive(true);
                test[i].GetChild(0).gameObject.SetActive(false);
                test[i].GetChild(2).gameObject.SetActive(false);
                //test[i].text = "不看";
            }
            else if(newForecast[i] == 2)
            {
                test[i].GetChild(0).gameObject.SetActive(false);
                test[i].GetChild(1).gameObject.SetActive(false);
                test[i].GetChild(2).gameObject.SetActive(true);
                //test[i].text = " 没看完";
            }
        }

        PlayerBehaviorForecast = newForecast;

    }



    IEnumerator hide(GameObject iamge)
        {

            yield return new WaitForSeconds(2);
            iamge.SetActive(false);
        
        }

}
