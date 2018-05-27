using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {
	int index;
	public Color[] colors;
	float indexColor;
	public GameObject bd; 
	float increment = 0.2f;
	float d;
	// Use this for initialization
	void Start () {
		int index = Random.Range(0, colors.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		public Color getNextColor() {
		Color newColor = Color.Lerp(colors[index], colors[(index+1) % colors.Length], indexColor);
		print ("indexcolor"+ indexColor);
		if (indexColor == 1.0f) {
			indexColor = -increment;
			 index = (index+1) % colors.Length;
		}
		indexColor += increment;
		return newColor;
	}

}
