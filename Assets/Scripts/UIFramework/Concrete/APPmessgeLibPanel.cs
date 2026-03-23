using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APPmessageLibPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/APPmessageLibPanel";

    public APPmessageLibPanel() : base(new UIType(path)) { }
    public override void OnEnter()
    {
        
        UITool.GetOrAddComponentInChildren<Button>("Return").onClick.AddListener(() =>
        {
            
            PanelManager.Pop();
            PanelManager.Push(new MainPanel());
            PanelManager.Push(new AppPanel());
        });


    }
}