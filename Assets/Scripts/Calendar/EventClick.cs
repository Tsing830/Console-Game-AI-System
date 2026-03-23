using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventClick : MonoBehaviour
{
    public void OnPointerClick()
    {
        MainScene ms = (MainScene)GameRoot.Instance.SceneSystem.sceneState;
        Debug.Log("日历系统被点击了");
        ms.panelManager.Push(new CalendarPanel());
    }
}