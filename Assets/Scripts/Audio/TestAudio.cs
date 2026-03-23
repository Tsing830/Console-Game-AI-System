using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    AudioSource Orange;//获取AudioOrange组件
    void Start()
    {
        Orange = transform.GetComponent<AudioSource>();//对Orange组件进行赋值
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            Orange.Pause();//当按下T键，音乐暂停
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Orange.UnPause();//当按下Y键，音乐继续播放
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Orange.Play();//当按下U键，音乐继续播放
        }
    }

}