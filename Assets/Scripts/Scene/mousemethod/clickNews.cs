using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class clickNews : MonoBehaviour
{
    public Text DisplayBtnText;                     //显示文本组件
    public Text BtnText { get; set; }

     void Start()
    {
        if(newsController.Instance != null)
        DisplayBtnText = newsController.Instance.sendNewsPos;
    }

    public void ClickMethod()
    {
            Text text = this.gameObject.GetComponentInChildren<Text>();
            BtnText = text;
            DisplayBtnText.text = BtnText.text;

            newsController.Instance.sendNewsNumber = int.Parse( transform.GetChild(2).GetComponent<Text>().text);

    }
}
