using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : SceneState
{

    readonly string sceneName = "Main";
    public PanelManager panelManager;
    public override void onEnter()
    {
        panelManager = new PanelManager();

        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            
            panelManager.Push(new MainPanel());
            panelManager.Push(new AppPanel());
        }

    }

    public override void onExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panelManager.PopAll();
    }
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {

        panelManager.Push(new MainPanel());
        panelManager.Push(new AppPanel());
        Debug.Log($"{sceneName}场景加载完毕");
    }
}
