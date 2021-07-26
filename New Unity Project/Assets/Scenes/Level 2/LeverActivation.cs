using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{
	public bool hasBeenHit;
	public static bool activateTeleporter = false;
	public GameObject activateTeleportText;
	public GameObject teleporter;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter()
	{
		activateTeleportText.SetActive(true);
	}

	void OnTriggerStay(Collider other)
	{
		if (hasBeenHit == false)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (other.tag == "Player1")
				{
					GetComponent<Animator>().enabled = true;
					hasBeenHit = true;
					activateTeleporter = true;
					teleporter.SetActive(true);
					activateTeleportText.SetActive(false);
				}
			}

		}
	}

	void OnTriggerExit()
    {
		activateTeleportText.SetActive(false);
	}
}
