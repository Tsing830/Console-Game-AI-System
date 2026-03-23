using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;   

public class VedioLoad : MonoBehaviour
{

    public Slider slider;
    private float lookTime;

    // Start is called before the first frame update
    void Start()
    {
        lookTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(int.Parse(gameObject.transform.GetChild(7).GetComponent<Text>().text) == 0 )
        {
            
            slider.value = (float)(lookTime / int.Parse
                (gameObject.transform.GetChild(6).GetComponent<Text>().text));

            lookTime += ScoreController.Instance.timeSpeed * Time.deltaTime * 60 ;
        
        }
        
    }
}
