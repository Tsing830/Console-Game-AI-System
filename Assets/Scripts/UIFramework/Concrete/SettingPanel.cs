using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SettingPanel";

    public SettingPanel() : base(new UIType(path)) { }

    
    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
}
