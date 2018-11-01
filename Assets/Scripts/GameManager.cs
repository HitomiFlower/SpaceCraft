using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

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

	#region JobSystem

	public TransformAccessArray transforms;
	private MovementJob moveJob;
	private JobHandle moveHandle;

	#endregion

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

//	// Update is called once per frame
//	void Update () 
//	{
//		if (Input.GetKeyDown("space"))
//		{
//			AddShip(EnemyShipIncrement);
//			instanceNum += EnemyShipIncrement;
//			Debug.Log("Current instance count: <color=red>" + instanceNum + "</color>");
//		}
//	}
//
//	private void AddShip(int amount)
//	{
//		for (int i = 0; i < amount; i++)
//		{
//			float xVal = Random.Range(leftBound, rightBound);
//			float zVal = Random.Range(0f, 10f);
//
//			Vector3 pos = new Vector3(xVal, 0f, zVal + topBound);
//			Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
//
//			var obj = Instantiate(enemyShipPrefab, pos, rot) as GameObject;
//		}
//		
//	}

	void Start()
	{
		transforms = new TransformAccessArray(0); 
	}
	

	void Update()
	{
		moveHandle.Complete();
		if (Input.GetKeyDown("space"))
		{
			AddShip(EnemyShipIncrement);
			instanceNum += EnemyShipIncrement;
			Debug.Log("Current instance count: <color=red>" + instanceNum + "</color>");
		}
		
		moveJob = new MovementJob()
		{
			moveSpeed = enemySpeed,
			topBound = topBound,
			bottomBound = bottomBound,
			deltaTime = Time.deltaTime
		};

		moveHandle = moveJob.Schedule(transforms);
		JobHandle.ScheduleBatchedJobs();
	}
	private void AddShip(int amount)
	{
		moveHandle.Complete();
		transforms.capacity = transforms.length + amount;

		for (int i = 0; i < amount; i++)
		{
			float xVal = Random.Range(leftBound, rightBound);
			float zVal = Random.Range(0f, 10f);

			Vector3 pos = new Vector3(xVal, 0f, zVal + topBound);
			Quaternion rot = Quaternion.Euler(0f, 180f, 0f);

			var obj = Instantiate(enemyShipPrefab, pos, rot) as GameObject;
			
			transforms.Add(obj.transform);
		}
	}

	private void OnDestroy()
	{
		transforms.Dispose();
	}
}
