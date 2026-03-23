using UnityEngine;
using UnityEngine.UI;



public class Drag : MonoBehaviour
{ 
    public  Vector3 startpos;
    public  Vector3[] slotpos ;
    public  bool isonLookQueue = false;
    private int changePos;
    public Transform DeletPos;

    private void Start()
    {

        startpos = transform.position;
        for (int i = 0; i < videoController.Instance.slotPos.Length; i++)
        {
            slotpos[i] = videoController.Instance.slotPos[i].transform.position;

        }
        if(int.Parse(this.transform.GetChild(8).GetComponent<Text>().text) == 1)
        isonLookQueue = true;
        DeletPos = videoController.Instance.DeletPos;

    }
     


    void Update()
    {
        string thisnumber =this.transform.GetChild(7).GetComponent<Text>().text;
        int Vnumber=int.Parse(thisnumber);  
        if(Vnumber<5)
            startpos = videoController.Instance.slotPos[Vnumber].transform.position;
        else
        {
            startpos = videoController.Instance.SelectSlotPos[Vnumber - 5].transform.position;
        }
            
            
        
    }

    public void DragMethod()
    {
        string thisnumber =this.transform.GetChild(7).GetComponent<Text>().text;
        int Vnumber=int.Parse(thisnumber);
        if(Vnumber != 0)
        {

            videoController.Instance.islookVideo = false;
            
            changePos = Vnumber;


            if( !isonLookQueue)
            {
                this.transform.SetParent(videoController.Instance.videoQueueParent.transform);
            }

            transform.SetAsLastSibling();
            transform.position = Input.mousePosition;

                for (int i = 1; i < videoController.Instance.slotPos.Length-1; i++)
            {
                float distY = Mathf.Abs(transform.position.y - slotpos[i].y);
                float distX = Mathf.Abs(transform.position.x - slotpos[i].x);
                if (distY < 55   && distX < 100)
                {
                    changePos=i;
                }
            }
            videoController.Instance.moveVideo(changePos,Vnumber);
        }
    }

    
    public void EndDragMethod()
    {
        videoController.Instance.islookVideo = true;
       

        if( Vector3.Distance(transform.position,DeletPos.position) <50.0f && isonLookQueue)
        {
            string thisnumber =this.transform.GetChild(7).GetComponent<Text>().text;
            int Vnumber=int.Parse(thisnumber);
            videoController.Instance.deletVideofromQueue(Vnumber,false);
        } 
        else
        {
            for (int i = 1; i < videoController.Instance.slotPos.Length-1; i++)
            {
                float distY = Mathf.Abs(transform.position.y - slotpos[i].y);
                float distX = Mathf.Abs(transform.position.x - slotpos[i].x);
                if (distY < 55   && distX < 100)
                {
                    if( i <=2 || int.Parse(this.transform.GetChild(7).GetComponent<Text>().text)<=2)
                    {
                        int j = int.Parse(this.transform.GetChild(7).GetComponent<Text>().text);
                        if(i<=j)
                        videoController.Instance.refrechPbForecast(i);
                        else
                        videoController.Instance.refrechPbForecast(j);
                    }

                    transform.SetParent(videoController.Instance.videoQueueParent.transform);
                    transform.position = slotpos[i];
                    string thisnumber =this.transform.GetChild(7).GetComponent<Text>().text;
                    int Vnumber=int.Parse(thisnumber); 
                    if(isonLookQueue)               
                    videoController.Instance.moveVideoChange(i,Vnumber);
                    else
                    {
                        videoController.Instance.addVideoToQueue(i,videoController.Instance.VideoQueueNotOnLook[int.Parse(this.transform.GetChild(7).GetComponent<Text>().text)-5],
                                                                gameObject);
                        videoController.Instance.deleteVideo(this.transform.GetChild(4).GetComponent<Text>().text);
                        isonLookQueue = true;
                    }
                    
                    break;
                }

                if(i ==videoController.Instance.slotPos.Length-2)
                {
                    transform.position = startpos;
                    if( !isonLookQueue)
                {
                    this.transform.SetParent(videoController.Instance.selectParent.transform);
                }

                }

            }

          
        }
            
   }
}
