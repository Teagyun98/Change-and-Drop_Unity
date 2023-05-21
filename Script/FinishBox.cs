using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
	Rigidbody rigid;

	public int clearCount;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		if (GameManager.instance.clearCount > 0)
			transform.position = transform.position;
		else
			rigid.isKinematic = false;
	}

}
