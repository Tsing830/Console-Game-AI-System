using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/AppPanel";

    public AppPanel() : base(new UIType(path)) { }
    public override void OnEnter()
    {
        
        // UITool.GetOrAddComponentInChildren<Button>("Video").onClick.AddListener(() =>
        // {

        //     PanelManager.Push(new LookVideoPanel());
        //     videoController.Instance.RefreshVideo();
        //     //PanelManager.Pop();

        // });

        UITool.GetOrAddComponentInChildren<Button>("App1").onClick.AddListener(() =>
        {

            ScoreController.Instance.isClickApp1 = true;
            PanelManager.Pop();
            PanelManager.Pop();
            PanelManager.Push(new APPmessagePanel());
            



        });
        UITool.GetOrAddComponentInChildren<Button>("App1.2").onClick.AddListener(() =>
        {

            ScoreController.Instance.isClickApp1 = true;
            PanelManager.Pop();
            PanelManager.Pop();
            PanelManager.Push(new APPmessageLibPanel());




        });
         UITool.GetOrAddComponentInChildren<Button>("App2").onClick.AddListener(() =>
        {

            PanelManager.Pop();
            PanelManager.Pop();
            PanelManager.Push(new chatPanel());
         



        });
        


        // UITool.GetOrAddComponentInChildren<Button>("test").onClick.AddListener(() =>
        // {
        //     newsController.Instance.addNews(1,false);
        // });


    }
}
