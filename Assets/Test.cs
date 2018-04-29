using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

	public Camera camera;
	public Text text;
	Color waitingColor;

	bool waiting;
	bool testing;
	float delayTime;
	float reactTime;
	float totalTime;
	int testNum;

	// Use this for initialization
	void Start()
	{
		waiting = true;
		testing = false;
		testNum = 0;
		totalTime = 0.0f;
		waitingColor = camera.backgroundColor;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (waiting)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Init();
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				Reset();
			}
		}
		else
		{
			if (testing)
			{
				if (Input.anyKeyDown)
				{
					reactTime = (Time.time - reactTime) * 1000;
					totalTime += reactTime;
					testNum++;
					int reactInt = (int)reactTime;
					int totalInt = (int)totalTime;
					int avg = totalInt / testNum;
					text.text = "result: " + reactInt.ToString() + "ms\n\naverage: " + avg.ToString() + "ms\nattempts: " + testNum.ToString() + "\n[r] to reset stats";
					camera.backgroundColor = waitingColor;
					testing = false;
					waiting = true;
				}

			}
			else
			{
				if (delayTime <= Time.time)
				{
					reactTime = Time.time;
					camera.backgroundColor = Color.green;
					testing = true;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void Init()
	{
		delayTime = Random.value * 2.0f + 2.0f + Time.time;
		camera.backgroundColor = Color.black;
		text.text = null;
		waiting = false;
	}

	void Reset()
	{
		testNum = 0;
		totalTime = 0.0f;
	}

}
