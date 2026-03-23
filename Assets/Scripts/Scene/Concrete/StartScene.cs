using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : SceneState
{

    readonly string sceneName = "Start";
    public PanelManager panelManager;
    public override void onEnter()
    {
        panelManager=new PanelManager();

        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            panelManager.Push(new StartPanel());
        }
    }

    public override void onExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        panelManager.PopAll();
    }
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new StartPanel());
        Debug.Log($"{sceneName}场景加载完毕");
    }
}
