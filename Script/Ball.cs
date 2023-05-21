using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int passing;
    public Material blueMa;
    public Material orangeMa;
	TrailRenderer trail;
	public bool isGoal;

	private void Awake()
	{
		trail = GetComponent<TrailRenderer>();
	}

	private void Start()
	{
		isGoal = false;
		Init();
	}

	public void ChangeColor()
	{
		Init();
	}

	private void Init()
	{
		switch (GameManager.instance.ballColor)
		{
			case GameManager.colorData.Blue:
				gameObject.GetComponent<MeshRenderer>().material = blueMa;
				trail.material = blueMa;
				break;
			case GameManager.colorData.Orange:
				gameObject.GetComponent<MeshRenderer>().material = orangeMa;
				trail.material = orangeMa;
				break;
		}
	}
}
