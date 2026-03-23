using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/chatPanel";

    public chatPanel() : base(new UIType(path)) { }
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