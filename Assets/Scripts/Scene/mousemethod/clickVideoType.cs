using UnityEngine;
using UnityEngine.UI;


public class clickVideoType : MonoBehaviour
{
    

    private bool flag = false;



    private float[] size = { 315.6f, 435.76f, 567.66f, 677.434f, 801.53f };



    public void ClickMethod()
    {
        if(videoController.Instance.selectVideoPage.activeSelf == true)
        {
                foreach (GameObject video in videoController.Instance.VideoPrefabQueueNotOnLook)
            {
                    if(video!=null && video.transform.GetChild(8).GetComponent<Text>().text == "0")
                    Destroy(video);

            }
        }
        else
            videoController.Instance.selectVideoPage.SetActive(true);

        for (int k = 1; k < 14; k++)
        {
            if (this.transform.GetChild(0).GetComponent<Text>().text == k.ToString())
            {
                if (flag == false)
                {
                    flag = true;
                    int num = Random.Range(2, 7);
                    videoController.Instance.Num[k - 1] = num;
                    videoController.Instance.bools[k - 1] = true;
                    videoController.Instance.content.GetComponent<RectTransform>().sizeDelta = new Vector2(726.339f, size[num - 2]);
                    for (int i = 0; i < num; i++)
                    {

                        //videoController.Instance.content.transform.GetChild(i).gameObject.SetActive(false);
                        videoController.Instance.creatSelectVideoPrefab(i, k);

                    }
                }
                else
                {
                    for (int i = 0, j = 0; i < 40; i++)
                    {
                        videoController.Instance.content.GetComponent<RectTransform>().sizeDelta = new Vector2(726.339f, size[videoController.Instance.Num[k-1]-2]);
                        if (videoController.Instance.loadSelectVideoPrefab(i, j, k))
                            j++;

                    }


                }

            }
        }
    }










}

