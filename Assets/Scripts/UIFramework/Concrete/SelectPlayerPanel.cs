using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SelectPlayerPanel";

    public SelectPlayerPanel() : base(new UIType(path)) { }


    public override void OnEnter()
    {
        


        UITool.GetOrAddComponentInChildren<Button>("BtnPlay").onClick.AddListener(() =>
        {
 

            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
            GameDataManger.Instance.isfirst = true;



        });


        UITool.GetOrAddComponentInChildren<Button>("Return").onClick.AddListener(() =>
        {
            PanelManager.Pop();
            PanelManager.Push(new StartPanel());


        });


    }
}
