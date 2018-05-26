using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IntersectingType{ GAME_OVER, NOT_CUT, TO_CUT};

public class IntersectingUtils{

	float distanceBetweenCenters;
	float size;
	float lastCubePos;
	Vector3 currentCubePos;
	Vector3 lastCubeSize;


	public IntersectingType IntersectingCubes (GameObject currentCube, GameObject lastCube, bool x_AxisDirection, float perfectOffset_percent)
	{
		distanceBetweenCenters = 0.0f;
		size = 0.0f;
		lastCubePos = 0.0f;
		lastCubeSize = lastCube.transform.localScale;
		currentCubePos = currentCube.transform.position;
		


		if (x_AxisDirection) {
			distanceBetweenCenters = currentCube.transform.position.x - lastCube.transform.position.x;
			size = currentCube.transform.localScale.x;
			lastCubePos = lastCube.transform.position.x;
		}
		else {
			distanceBetweenCenters = currentCube.transform.position.z - lastCube.transform.position.z;
			size = currentCube.transform.localScale.z;
			lastCubePos = lastCube.transform.position.z;
		}


		//Calcular la intersecció entre els dos cubs
		if (Mathf.Abs (distanceBetweenCenters) >= size) 
		{
			return IntersectingType.GAME_OVER;

		} 
		else if (Mathf.Abs (distanceBetweenCenters)/size <= perfectOffset_percent) 
		{
			return IntersectingType.NOT_CUT;
		} 
		else 
		{
			return IntersectingType.TO_CUT;
		}
	}
	
	public void SetTransformsInToCut(GameObject cubeToFall, GameObject cubeToStay, bool x_AxisDirection)
	{
		float direction = distanceBetweenCenters / Mathf.Abs (distanceBetweenCenters);

		float stay_Size = size - Mathf.Abs (distanceBetweenCenters);
		float fall_Size = size - stay_Size;
		float stay_Pos = lastCubePos + (size*0.5f - stay_Size*0.5f)*direction ;
		float fall_Pos = stay_Pos + size*0.5f*direction;

		Vector3 _pos = currentCubePos;
		Vector3 _size = lastCubeSize;
		if (x_AxisDirection) {
			_pos.x = fall_Pos;
			cubeToFall.transform.position = _pos;
			_pos.x = stay_Pos;
			cubeToStay.transform.position = _pos;
			_size.x = fall_Size;
			cubeToFall.transform.localScale = _size;
			_size.x = stay_Size;
			cubeToStay.transform.localScale = _size;

		} else {
			_pos.z = fall_Pos;
			cubeToFall.transform.position = _pos;
			_pos.z = stay_Pos;
			cubeToStay.transform.position = _pos;
			_size.z = fall_Size;
			cubeToFall.transform.localScale = _size;
			_size.z = stay_Size;
			cubeToStay.transform.localScale = _size;
		}
	}
}
