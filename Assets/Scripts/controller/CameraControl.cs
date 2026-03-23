using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
	public int speed;
	private float ry = 0;
	public GameObject position;
	public Material[] walls1;
	public Material[] walls2;
	public Material[] walls3;
	public Material[] walls4;
    public GameObject gameObject;

    void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			//向左转
			transform.Rotate(Vector3.up * Time.deltaTime * 30 * speed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			//向右转
			transform.Rotate(Vector3.down * Time.deltaTime * 30 * speed);
		}
		ry = position.GetComponent<Transform>().localEulerAngles.y;

		if ((ry >= 320 && ry <= 360) || ry >= 0 && ry <= 140)
        {
			dis(walls1, true);
		}
        else
        {
			dis(walls1, false);
		}
			

		if (ry >= 230 && ry <= 360 || ry >= 0 && ry <= 50)
        {
			dis(walls2, true);
		}
        else
        {
			dis(walls2, false);
		}
						
		if (ry >= 140 && ry <= 320)
        {
			dis(walls3, true);
		}
        else
        {
			dis(walls3, false);
		}
			
		if (ry >= 50 && ry <= 230)
        {
			dis(walls4, true);
			gameObject.SetActive(false);
		}
        else
        {
			dis(walls4, false);
			gameObject.SetActive(true);
		}

    }


	public void dis(Material[] walls, bool ifHide)
	{
		if(ifHide)
		{
			foreach (Material wall in walls)
			{
				if(wall.GetFloat("_Opacity")> 0)
				{
					wall.SetFloat("_Opacity",wall.GetFloat("_Opacity")-Time.deltaTime*3);
					wall.renderQueue = 2501;
				}
				else
				wall.SetFloat("_Opacity",0);
			}
		}
		else
		{
			foreach (Material wall in walls)
			{
				if(wall.GetFloat("_Opacity")< 1)
				{
					wall.SetFloat("_Opacity",wall.GetFloat("_Opacity")+Time.deltaTime*5);
					wall.renderQueue = 2500;
				}
				else
				wall.SetFloat("_Opacity",1);

			}
		}
		
	}

	








}


