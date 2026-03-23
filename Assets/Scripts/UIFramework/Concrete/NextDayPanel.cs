using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NextDayPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/NextDayPanel";

    public NextDayPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("NextDay").onClick.AddListener(() =>
        {
            PanelManager.Pop();
            //点击事件可以写在这里面

            GameRoot.Instance.SceneSystem.SetScene(new MainScene());


        });

    }


    public override void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
}
