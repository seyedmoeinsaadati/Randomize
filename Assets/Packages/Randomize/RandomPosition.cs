using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

	[System.Serializable]
	public class PositionRange
	{
		public float min, max;
	}

	public GameObject[] gos;

	public PositionRange x, y, z;
	private float defX, defY, defZ;
	public bool lockX, lockY, lockZ;
	// Use this for initialization
	void Start ()
	{
		defX = gos [0].transform.position.x;
		defY = gos [0].transform.position.y;
		defZ = gos [0].transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			foreach (var item in gos) {
				Vector3 newPosition = new Vector3 (lockX ? item.transform.position.x : Random.Range (x.min, x.max), 
					                      lockY ? item.transform.position.y : Random.Range (y.min, y.max), 
					                      lockZ ? item.transform.position.z : Random.Range (z.min, z.max)); 
				item.transform.localPosition = newPosition;
			}
		}
	}
}