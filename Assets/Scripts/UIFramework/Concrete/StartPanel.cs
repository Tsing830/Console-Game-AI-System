using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 开始主面板
/// </summary>
public class StartPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/StartPanel";

    public StartPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("BtnSetting").onClick.AddListener(() =>
        {
            //点击事件可以写在这里面
            PanelManager.Push(new SettingPanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("BtnPlay").onClick.AddListener(() =>
        {
            //点击事件可以写在这里面
            PanelManager.Pop();

            PanelManager.Push(new SelectPlayerPanel());

            
        });
        UITool.GetOrAddComponentInChildren<Button>("Continue").onClick.AddListener(() =>
        {
            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
            GameDataManger.Instance.isfirst = false;
        });
        UITool.GetOrAddComponentInChildren<Button>("ProducerList").onClick.AddListener(() =>
        {
            //点击事件可以写在这里面
            PanelManager.Push(new ProducerListPanel());
        });
    }

}
