using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Huakuai : MonoBehaviour
{
    //private RectTransform rectTra;
    private RectTransform areaRectTra;
    private UnityEngine.UI.Slider slider;
    private void Awake()
    {
        //rectTra = this.GetComponent<RectTransform>();
        areaRectTra = this.transform.Find("Area").GetComponent<RectTransform>();
        slider = this.transform.Find("Slider").GetComponent<UnityEngine.UI.Slider>();
    }
    private void Update()
    {
        float tempAnchoredPosY = slider.value * areaRectTra.sizeDelta.y;
        areaRectTra.anchoredPosition = new Vector2(areaRectTra.anchoredPosition.x, tempAnchoredPosY);
    }
}
