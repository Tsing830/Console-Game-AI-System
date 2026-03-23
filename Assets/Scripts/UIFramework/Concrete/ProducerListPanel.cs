using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProducerListPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/ProducerList";

    public ProducerListPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
}