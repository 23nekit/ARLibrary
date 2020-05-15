using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float AliveTime = 3;

	private void Awake()
	{
		Destroy(gameObject, AliveTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball")
		{
			BallManager.AllBalls.Remove(other.gameObject);
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}
}
