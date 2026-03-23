using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleltVideoPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SeleltVideoPanel";

    public SeleltVideoPanel() : base(new UIType(path)) { }

  public override void OnEnter()
    {
      
        UITool.GetOrAddComponentInChildren<Button>("Return").onClick.AddListener(() =>
        {

            PanelManager.Push(new SeleltTypePanel());
            PanelManager.Pop();
        });
        

    }
}
