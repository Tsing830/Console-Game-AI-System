using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhonePanelController : MonoBehaviour
{
    public static PhonePanelController Instance;
    [SerializeField]
    GameObject worldPos;//3D物体（人物）
    [SerializeField]
    RectTransform rectTrans;//UI元素（如：血条等
    
    public GameObject UItest;
    public Vector2 offset;//偏移量

    [SerializeField]
    RectTransform PhoneAnimator;

    void Awake()
    {
        Instance = this;
    }

    void Update ()
    {
        Vector2 screenPos=Camera.main.WorldToScreenPoint(worldPos.transform.position);
        rectTrans.position = screenPos + offset;
    }


    

    public void Debugstate (string state)
    {
        Text State = UItest.transform.GetChild(0).GetComponent<Text>();
        State.text = state;
    }



}
