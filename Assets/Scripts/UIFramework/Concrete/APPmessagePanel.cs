using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class APPmessagePanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/APPmessagePanel";

    public APPmessagePanel() : base(new UIType(path)) { }

    public bool flag=true;


    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("from1").onClick.AddListener(() =>
        {
            newsController.Instance.clearQueue();
            if (!appController.Instance.isLoad[1])
            {
                newsController.Instance.refrechNews(1);
                appController.Instance.isLoad[1] = true;
            }
            else
                newsController.Instance.LoadNews(1);
        });
      
        UITool.GetOrAddComponentInChildren<Button>("Return").onClick.AddListener(() =>
        {
            
            PanelManager.Pop();
            PanelManager.Push(new MainPanel());
            PanelManager.Push(new AppPanel());
        });

        UITool.GetOrAddComponentInChildren<Button>("Send").onClick.AddListener(() =>
        {
            if(flag)
            {
                newsController.Instance.sendaNews();
                ScoreController.Instance.sendaNews = true;

                if (!ScoreController.Instance.sendLock)
                {
                    ScoreController.Instance.sendLock = true;
                    ScoreController.Instance.selfControll -= 2;
                    ScoreController.Instance.maxConcentration -= 5;




                    if (ScoreController.Instance.state1 == 1)        //处于工作状态
                    {
                        ScoreController.Instance.Isup = false;
                        ScoreController.Instance.Concentration = ScoreController.Instance.selfControll - 40;
                    }

                }
                else
                {
                    flag = false;   
                    Debug.Log("小人关闭了消息提示");
                }
            }
            else
            {
                newsController.Instance.sendaNews();
            }



        });

   
    }

    public override void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
}