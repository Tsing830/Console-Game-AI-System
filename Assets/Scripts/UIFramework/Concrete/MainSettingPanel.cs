using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSettingPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/MainSettingPanel";

    public MainSettingPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("ReturnStartScene").onClick.AddListener(() =>
        {
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        });
        
    }

    public override void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
}
