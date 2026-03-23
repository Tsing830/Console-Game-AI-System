using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageSprite : MonoBehaviour
{
    Image mainimg;
    Sprite[] change_sp;

    Vector3 start_pos;
    Vector3 end_pos;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        mainimg = transform.GetComponent<Image>();
        change_sp = Resources.LoadAll<Sprite>("Content");
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    start_pos = Input.GetTouch(0).position;
                    break;

                case TouchPhase.Moved:

                    break;
                case TouchPhase.Ended:
                    end_pos = Input.GetTouch(0).position;
                    float offset = end_pos.x - start_pos.x;
                    //向左滑动
                    if (offset < 0)
                    {
                        if (count < change_sp.Length - 1)
                        {
                            count++;
                        }
                    }
                    //向右滑动
                    else if (offset > 0)
                    {
                        if (count > 0)
                        {
                            count--;
                        }
                    }
                    mainimg.sprite = change_sp[count];
                    break;
            }
        }
    }
}