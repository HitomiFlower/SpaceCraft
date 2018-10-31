using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	private const int EnemyShipIncrement = 50;

	public float leftBound = -10.5f;

	public float rightBound = 10.5f;

	public float topBound = 6.6f;

	public float bottomBound = -6.6f;

	public float enemySpeed = 0.6f;

	private static GameManager _instance;

	private int instanceNum = 0;

	public static GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<GameManager>();
			}

			return _instance;
		}
	}
	

	[SerializeField]
	private GameObject enemyShipPrefab;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("space"))
		{
			AddShip(EnemyShipIncrement);
			instanceNum += EnemyShipIncrement;
			Debug.Log("Current isntance count: <color=red>" + instanceNum + "</color>");
		}
	}

	private void AddShip(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			float xVal = Random.Range(leftBound, rightBound);
			float zVal = Random.Range(0f, 10f);

			Vector3 pos = new Vector3(xVal, 0f, zVal + topBound);
			Quaternion rot = Quaternion.Euler(0f, 180f, 0f);

			var obj = Instantiate(enemyShipPrefab, pos, rot) as GameObject;
		}
		
	}
	
}
