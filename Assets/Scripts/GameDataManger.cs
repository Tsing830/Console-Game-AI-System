using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameDataManger : MonoBehaviour
{
    public static GameDataManger Instance;

    public bool continueButten;
    public bool isfirst;

    public BaseNews[] NewsQueue = new BaseNews[40];
    public Transform Player;


    const string PLAYER_DATA_KEY = "PlayerData";
    const string PLAYER_DATA_FILE_NAME = "PlayerData.game";


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        if(SaveSystemTutorial.SaveSystem.LoadFromJson<SaveData>("PlayerData.game") != null)
            continueButten = true;
        else
            continueButten = false;


        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        for (int i = 0; i < 40; i++)
        {
            if (NewsQueue[i] == null)
            {
                NewsQueue[i] = new BaseNews();
            }
        }


    }

    class SaveData//需要保存的数据写在这里
    {


        //小人状态
        public int state1; //日常状态 0 = 休息  ， 1 = 学习/工作 ， 2 = 放松     ， 3 =  短视频 
        public int state2; //事件状态 0 = 无事件， 1 = 谈恋爱    ， 2 = 减肥计划 ， 3 = .....

        //小人数值Layer1
        public float selfControll;
        public float mood;
        public float money;
        public float Anxious;

        //小人数值Layer2
        public float Concentration;
        public float DailyAnxious;
        public float sleepy;

        //小人数值Layer3
        public float joy;
        public float[] videolike;
        public float[] videotried;


        public int Days;

    }


    //public string[] Content => NewsQueue[].newsContent;
    //public int[] Number => NewsQueue[].number;

    SaveData SavingData()
    {
        var saveData = new SaveData();



        //小人状态
        saveData.state1 = ScoreController.Instance.state1;
        saveData.state2 = ScoreController.Instance.state2;

        //小人数值Layer1
        saveData.selfControll = ScoreController.Instance.selfControll;
        saveData.mood = ScoreController.Instance.mood;
        saveData.money = ScoreController.Instance.money;
        saveData.Anxious = ScoreController.Instance.Anxious;

        //小人数值Layer2
        saveData.Concentration = ScoreController.Instance.Concentration;
        saveData.DailyAnxious = ScoreController.Instance.DailyAnxious;
        saveData.sleepy = ScoreController.Instance.sleepy;

        //小人数值Layer3
        saveData.joy = ScoreController.Instance.joy;
        saveData.Days = ScoreController.Instance.Days;
        //for (int i = 0; i  < ScoreController.Instance.videolike.Length; i++)
        //{
        //    saveData.videolike[i] = ScoreController.Instance.videolike[i];
        //}
        //for (int i = 0; i < ScoreController.Instance.videotried.Length; i++)
        //{
        //    saveData.videotried[i] = ScoreController.Instance.videotried[i];
        //}


        return saveData;
    }

    void LoadData(SaveData saveData)
    {


        //小人状态
        ScoreController.Instance.state1 = saveData.state1;
        ScoreController.Instance.state2 = saveData.state2;

        //小人数值Layer1
        ScoreController.Instance.selfControll = saveData.selfControll;
        ScoreController.Instance.mood = saveData.mood;
        ScoreController.Instance.money = saveData.money;
        ScoreController.Instance.Anxious = saveData.Anxious;

        //小人数值Layer2
        ScoreController.Instance.Concentration = saveData.Concentration;
        ScoreController.Instance.DailyAnxious = saveData.DailyAnxious;
        ScoreController.Instance.sleepy = saveData.sleepy;

        //小人数值Layer3
        ScoreController.Instance.joy = saveData.joy;
        ScoreController.Instance.Days = saveData.Days;
        //for (int i = 0; i < ScoreController.Instance.videolike.Length; i++)
        //{
        //    ScoreController.Instance.videolike[i] = saveData.videolike[i];
        //}
        //for (int i = 0; i < ScoreController.Instance.videotried.Length; i++)
        //{
        //    ScoreController.Instance.videotried[i] = saveData.videotried[i];
        //}


    }

    public void Save()
    {
        SaveByJson();
    }
    public void Load()
    {
        LoadFromJson();
    }


    void SaveByJson()
    {
        SaveSystemTutorial.SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
        //SaveSystem.SaveByJson($"{System.DataTime.Now:yyyy.dd.M HH-mm-ss}.sav", SavingData());
    }
    void LoadFromJson()
    {
        var saveData = SaveSystemTutorial.SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);

        LoadData(saveData);
    }
}
