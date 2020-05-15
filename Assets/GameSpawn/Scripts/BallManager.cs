using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
	public Ball BallPrefab;
	public GameObject Floor;
	public GameObject Ceiling;
	public GameObject Parent;
	public int BallCount;
	public float Power;
	public float TimeForNewSpawn=0.6f;
	public static List<GameObject> AllBalls = new List<GameObject>();

	public void SpawnBalls()
	{
		if (AllBalls.Count == 0)
		{
			StartCoroutine(SpawnBallsOncePerTimer());
		}
	}
	private IEnumerator SpawnBallsOncePerTimer()
	{
		for (int i = 0; i < BallCount; i++)
		{
			yield return new WaitForSeconds(TimeForNewSpawn);
			GameObject NewBall = Instantiate(BallPrefab.gameObject, (Floor.transform.position + Ceiling.transform.position) / 2, Quaternion.identity);
			NewBall.transform.parent = Parent.transform;
			Vector3 BallVelocity = new Vector3(Power, 0, Power);
			Vector3 BallForceVector = Floor.transform.rotation * BallVelocity;
			NewBall.GetComponent<Rigidbody>().AddForce(BallForceVector, ForceMode.Impulse);
			NewBall.name = "Ball " + (i + 1).ToString();
			AllBalls.Add(NewBall);
		}
	}
	public void DeleteBalls()
	{
		for (int i = 0; i < AllBalls.Count; i++)
		{
			Destroy(AllBalls[i]);
		}
		AllBalls = new List<GameObject>();
	}
}
