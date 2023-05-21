using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public PoolManager pool;

	public enum colorData { Orange, Blue }
	public colorData ballColor;
	public GameObject[] eventBox;
	public Transform minUnderBall;
	public Camera cam;
	public int clearCount;
	public bool isLive;
	public GameObject endUI;
	public GameObject gameOverUI;
	public bool allBallActive;
	public string nowScene;
	public string nextScene;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		isLive = false;
		allBallActive = true;
	}

	private void Update()
	{
		if (transform.childCount == 0)
			return;

		for (int i = 0; i < transform.childCount; i++)
		{
			if (minUnderBall == null)
				minUnderBall = transform.GetChild(i);

			if (minUnderBall.position.y > transform.GetChild(i).position.y) // ∞°¿Â ≥∑¿∫ ∫º
				minUnderBall = transform.GetChild(i);
		}

		for(int i = 0; i < transform.childCount; i++)
		{
			if (transform.GetChild(i).gameObject.activeSelf&&!transform.GetChild(i).GetComponent<Ball>().isGoal)
				break;
			if(isLive&&i==transform.childCount-1)
			{
				isLive = false;
				GameOver();
			}
		}
	}

	private void FixedUpdate()
	{
		if (minUnderBall == null)
			return;

		if(cam.transform.position.y > -150f && cam.transform.position.y > minUnderBall.position.y+15)
			cam.transform.position = new Vector3(cam.transform.position.x, minUnderBall.position.y+15, cam.transform.position.z);
	}

	public void OnClickEvent()
	{
		if (!isLive)
			return;

		switch(ballColor)
		{
			case colorData.Orange:
				ballColor = colorData.Blue;
				break;
			case colorData.Blue:
				ballColor = colorData.Orange;
				break;
		}

		for(int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).GetComponent<Ball>().ChangeColor();
		}
		
		for(int i = 0; i < eventBox.Length; i++)
		{
			eventBox[i].GetComponent<EventBlock>().Init();
		}
	}

	public void End()
	{
		isLive = false;
		endUI.SetActive(true);
	}

	public void GameOver()
	{
		gameOverUI.SetActive(true);
	}

	public void ReStart()
	{
		SceneManager.LoadScene(nowScene);
	}

	public void NextStage()
	{
		SceneManager.LoadScene(nextScene);
	}
}
