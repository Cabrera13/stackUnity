using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
	bool MoveX = true;
	float distance = 4.0f;
	float direction = 1.0f;
	public float speed = 4.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if (MoveX) {
			pos.x += Time.deltaTime * speed * direction;
		if (pos.x >= distance) {
			pos.x = distance;
			direction = -direction;
		}else if (pos.x <= -distance){
			pos.x = -distance;
			direction = -direction;
		}
	}
	else {
		pos.z += Time.deltaTime * speed * direction;
		if (pos.z >= distance) {
			pos.z = distance;
			direction = -direction;
		}else if (pos.z <= -distance){
			pos.z = -distance;
			direction = -direction;
		}
	}
	transform.position = pos;
	}
}
