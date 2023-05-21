using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
	public Vector3 startMousePos;
	private bool isClick;
	private bool isTurn;

	private void Start()
	{
		isClick = true;
		isTurn = false;
	}

	private void OnMouseDown()
	{
		isClick = false;
		startMousePos = Input.mousePosition;
	}

	private void OnMouseUp()
	{
		startMousePos = Vector3.zero;
		isClick = true;
		isTurn = true;
		for(int i = 0; i<3; i++)
		{
			Transform ball = GameManager.instance.pool.Get(0).transform;
			ball.position = transform.position + new Vector3(Random.Range(0, 1f), -1, 0);
			ball.transform.parent = GameManager.instance.transform;
		}
		GameManager.instance.isLive = true;
		StartCoroutine(SelfActiveFalse());
		
	}

	private void Update()
	{
		if (Input.GetMouseButton(0) && isClick && !GameManager.instance.isLive)
			OnMouseDown();
		if (Input.GetMouseButtonUp(0) && !isClick && !GameManager.instance.isLive)
			OnMouseUp();
	}

	private void FixedUpdate()
	{
		if (startMousePos != Vector3.zero)
		{
			transform.position = new Vector3((Input.mousePosition.x - startMousePos.x)*Time.fixedDeltaTime*2, 0, 0);
		}

		if (transform.position.x > 12)
			transform.position = new Vector3(12, 0, 0);
		if (transform.position.x < -12)
			transform.position = new Vector3(-12, 0, 0);

		if (isTurn)
			transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(-180, 0, 0, 0), 0.1f*Time.fixedDeltaTime);
	}
	IEnumerator SelfActiveFalse()
	{
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
	}
}
