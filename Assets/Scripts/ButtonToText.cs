using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToText : MonoBehaviour
{
    public Text DisplayBtnText;                     //显示文本组件
    public Text BtnText { get; set; }

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Text text = this.gameObject.GetComponentInChildren<Text>();
            BtnText = text;
            DisplayBtnText.text = BtnText.text;
        }
        );
    }
}
