using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateController : MonoBehaviour {
	float x;
	public GameObject cube; 
	
	public List<GameObject> j;
	public GameObject s; 
	float k = 0f;
	float m = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		x += Time.deltaTime;
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			j.Add(cube);
			GameObject d = Instantiate(s);
			d.transform.position = new Vector3(j[j.Count-1].transform.position.x,j[j.Count-1].transform.position.y+m,j[j.Count-1].transform.position.z);
			j.Add(d);
			x = 0;
			m+=1;
		}

	}
}
