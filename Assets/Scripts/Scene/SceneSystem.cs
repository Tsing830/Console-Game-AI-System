using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSystem 
{
    public SceneState sceneState;

    public void SetScene(SceneState state)
    {
        if (sceneState != null)
            sceneState.onExit();
        sceneState = state;
        if (sceneState != null)
            sceneState.onEnter();
    }
 
}
