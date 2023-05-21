using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Ball") || other.transform.GetComponent<Ball>().isGoal)
			return;
		other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		other.transform.GetComponent<Ball>().isGoal = true;
		GameManager.instance.clearCount--;
		if (GameManager.instance.clearCount == 0)
			GameManager.instance.End();
	}
}
