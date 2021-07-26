using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation1 : MonoBehaviour
{
	public bool hasBeenHit;
	public static bool activateDoor = false;
	public GameObject activateDoorText;

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
		activateDoorText.SetActive(true);
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
					activateDoor = true;
					activateDoorText.SetActive(false);
				}
			}			
		}
	}

	void OnTriggerExit()
	{
		activateDoorText.SetActive(false);
	}
}
