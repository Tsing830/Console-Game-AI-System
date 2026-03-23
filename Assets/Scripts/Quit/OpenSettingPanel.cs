using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            MainScene ns = (MainScene)GameRoot.Instance.SceneSystem.sceneState;
            Debug.Log("主场景设置按钮被点击了");
            ns.panelManager.Push(new MainSettingPanel());
        }
    }
}
