using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {
	int index;
	public Color[] colors;
	float indexColor;
	float increment = 0.1f;
	float d;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public Color getNextColor() {
		int ind = Random.Range(0, colors.Length);
		Color newColor = Color.Lerp(colors[index], colors[(index+1) % colors.Length], indexColor);
		if (indexColor == 1.0f) {
			indexColor = -increment;
			 index = (index+1) % colors.Length;

		}
		indexColor += increment;
		return newColor;
	}
}
