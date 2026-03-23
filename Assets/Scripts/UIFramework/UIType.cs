using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType 
{

    ///<Summary>
    /// UI名字
    ///<Summary>
    public string Name { get;  private set; }

    ///<Summary>
    /// UI
    /// UI路径
    ///<Summary>
    public string Path { get; private set; }

    public UIType(string path)
    {
        Path = path;
        Name = path.Substring(path.LastIndexOf('/') + 1);
    }


}
