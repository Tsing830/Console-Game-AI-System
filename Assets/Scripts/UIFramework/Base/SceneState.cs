using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneState
{
    public abstract void onEnter();

    public abstract void onExit();
}
