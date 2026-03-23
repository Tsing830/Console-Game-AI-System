using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelectPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SelectPanel";

    public SelectPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("NewGame").onClick.AddListener(() =>
        {
            PanelManager.Pop();
            //点击事件可以写在这里面
            PanelManager.Push(new MainPanel());
            PanelManager.Push(new AppPanel());
            
        });
        UITool.GetOrAddComponentInChildren<Button>("Load").onClick.AddListener(() =>
        {
            PanelManager.Pop();
            //点击事件可以写在这里面
            Debug.Log("读取存档按钮被点击了");
            //GameRoot.Instance.SceneSystem.SetScene(new MainScene());
            PanelManager.Push(new MainPanel());
            PanelManager.Push(new AppPanel());
            GameDataManger.Instance.Load();
            
        });
    }


    public override void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
}
