using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventBlock2 : MonoBehaviour
{
	public int num;
	public TextMeshPro text;
	public GameObject broken;
	public GameObject countBox;

	private void Start()
	{
		text.SetText($"{num}");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Ball"))
			return;

		num--;
		text.SetText($"{num}");
		if (num <= 0 && countBox.activeSelf)
		{
			countBox.SetActive(false);
			StartCoroutine(BrokenEvent());
		}
	}

	IEnumerator BrokenEvent()
	{
		broken.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		broken.SetActive(false);
	}

}
