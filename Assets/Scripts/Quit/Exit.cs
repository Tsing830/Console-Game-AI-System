using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainScene ms = (MainScene)GameRoot.Instance.SceneSystem.sceneState;
            Debug.Log("退出被点击了");
            ms.panelManager.Pop();
        }
    }
}
