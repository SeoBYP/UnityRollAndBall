using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField] private float rotationSpeed;
	[SerializeField] private AudioClip clip;

	[SerializeField] private AudioClip clip3;

	// Update is called once per frame
	void Update()
    {
		transform.Rotate(Vector3.up * rotationSpeed
			* Time.deltaTime, Space.World);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			AudioSource.PlayClipAtPoint(clip,this.transform.position);
			Destroy(gameObject);
		}
	}
}
