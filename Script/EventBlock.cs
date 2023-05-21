using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventBlock : MonoBehaviour
{ 
	public int multi;
	public int passingNum;
	public Material blueMa;
	public Material orangeMa;
	public GameObject spike;
	public GameManager.colorData color;
	public TextMeshPro text;

	private void Start()
	{
		Init();
		text.SetText($"X {multi}");
	}

	private void OnTriggerEnter(Collider col)
	{
		if (color != GameManager.instance.ballColor)
			col.gameObject.SetActive(false);
		else
		{
			if (!col.CompareTag("Ball") || passingNum < col.transform.GetComponent<Ball>().passing)
				return;

			col.transform.GetComponent<Ball>().passing++;

			for (int i = 0; i < multi-1; i++)
			{
				Transform ball = GameManager.instance.pool.Get(0).transform;
				ball.position = col.transform.position + new Vector3(Random.Range(0,1f), Random.Range(0,1f), 0);
				ball.GetComponent<Ball>().passing = col.transform.GetComponent<Ball>().passing;
				ball.transform.parent = GameManager.instance.transform;
			}
		}

	}

	public void Init()
	{
		switch (color)
		{
			case GameManager.colorData.Blue:
				gameObject.GetComponent<MeshRenderer>().material = blueMa;
				break;
			case GameManager.colorData.Orange:
				gameObject.GetComponent<MeshRenderer>().material = orangeMa;
				break;
		}

		if (GameManager.instance.ballColor != color)
			spike.SetActive(true);
		else
			spike.SetActive(false);
	}
}
