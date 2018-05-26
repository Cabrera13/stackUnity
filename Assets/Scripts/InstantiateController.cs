using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateController : MonoBehaviour {
	float x;
	public Text UIScore;
	public GameObject spam1;
	public GameObject spam2;
	public GameObject spam3;
	public GameObject cube; 
	bool gameOver = false;
	public Camera maincamera;
	public List<GameObject> j;
	public GameObject s; 
	public int score = 0; 
	float k = 0f;
	float m = 0.5f;
	int un = -1;
	IntersectingUtils d;
	// Use this for initialization
	void Start () {
		j.Add(spam1);
		j.Add(spam2);
		j.Add(spam3);
		j.Add (cube);
		spam1.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
		spam2.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
		spam3.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
		cube.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();

		d = new IntersectingUtils();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		x += Time.deltaTime;
		var k = d;

		if (Input.GetKeyDown(KeyCode.Space) && !gameOver) {
			GameObject d;
			maincamera.transform.position = new Vector3 (maincamera.transform.position.x, maincamera.transform.position.y + 0.5f, maincamera.transform.position.z);
			IntersectingType typecube = k.IntersectingCubes(j[j.Count-1], j[j.Count-2],j[j.Count-1].GetComponent<Cube> ().MoveX, 0.05f );
			if (j[j.Count-1].GetComponent<Cube> ().MoveX == false) {
				//j.Add (d);
				if (typecube == IntersectingType.TO_CUT){
					d = Instantiate (s);
					bool posCubeX = j[j.Count-1].GetComponent<Cube> ().MoveX;
					Color colorCopia = j[j.Count-1].GetComponent<MeshRenderer>().material.color;
					Destroy(j[j.Count-1]);
					j.Remove(j[j.Count-1]);
					GameObject tallat = Instantiate(spam3);
					GameObject notallat = Instantiate(spam3);
					tallat.GetComponent<MeshRenderer>().material.color = colorCopia;
					notallat.GetComponent<MeshRenderer>().material.color = colorCopia;
					j.Add(tallat);
					j.Add(d);
					d.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
					k.SetTransformsInToCut(notallat,tallat,posCubeX);
					d.transform.position = new Vector3 (tallat.transform.position.x, tallat.transform.position.y + 0.5f,tallat.transform.position.z);
					var copia = tallat.transform.localScale;
					d.transform.localScale = copia;
					notallat.AddComponent<Rigidbody>();
					print("CUT");
				
				}
				else if (typecube == IntersectingType.NOT_CUT) {
					d = Instantiate (s);
					GameObject identiCube = Instantiate(j[j.Count-2], new Vector3(j[j.Count-2].transform.position.x,j[j.Count-1].transform.position.y, j[j.Count-2].transform.position.z), Quaternion.identity);
					j.Add(identiCube);
					j.Add(d);	
					d.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
					j[j.Count-3].GetComponent<Cube>().enabled = false;
					d.transform.localScale = identiCube.transform.localScale;
					d.transform.position = new Vector3 (identiCube.transform.position.x, identiCube.transform.position.y + 0.5f,identiCube.transform.position.z);
					print("NOTCUT");
				}
				else {
					j[j.Count-1].AddComponent<Rigidbody>();
					j[j.Count-1].GetComponent<Cube>().enabled = false;
					gameOver = true;

				}
				x = 0;
				m += 0.5f;
				un-=1;
				j[j.Count-1].GetComponent<Cube> ().MoveX = true;
				print (j.Count);
				score += 1;
				UIScore.text = score.ToString();

			} 
			else {
				if (typecube == IntersectingType.TO_CUT){
					d = Instantiate (s);
					bool posCubeX = j[j.Count-1].GetComponent<Cube> ().MoveX;
					Color colorCopia = j[j.Count-1].GetComponent<MeshRenderer>().material.color;
					Destroy(j[j.Count-1]);
					j.Remove(j[j.Count-1]);
					GameObject tallat = Instantiate(spam3);
					GameObject notallat = Instantiate(spam3);
					tallat.GetComponent<MeshRenderer>().material.color = colorCopia;
					notallat.GetComponent<MeshRenderer>().material.color = colorCopia;
					j.Add(tallat);
					j.Add(d);
					d.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
					k.SetTransformsInToCut(notallat,tallat,posCubeX);
					d.transform.position = new Vector3 (tallat.transform.position.x, tallat.transform.position.y + 0.5f,tallat.transform.position.z);
					notallat.AddComponent<Rigidbody>();
					var copia = tallat.transform.localScale;
					d.transform.localScale = copia;
				}
				else if (typecube == IntersectingType.NOT_CUT) {
					d = Instantiate (s);
					GameObject identiCube = Instantiate(j[j.Count-2], new Vector3(j[j.Count-2].transform.position.x,j[j.Count-1].transform.position.y, j[j.Count-2].transform.position.z), Quaternion.identity);
					j.Add(identiCube);
					j.Add(d);
					d.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
					j[j.Count-3].GetComponent<Cube>().enabled = false;
					d.transform.localScale = identiCube.transform.localScale;
					d.transform.position = new Vector3 (identiCube.transform.position.x, identiCube.transform.position.y + 0.5f,identiCube.transform.position.z);

					print("NOTCUT");
					
				}
				else {
					j[j.Count-1].AddComponent<Rigidbody>();
					j[j.Count-1].GetComponent<Cube>().enabled = false;
					gameOver = true;
				}
				x = 0;
				m += 0.5f;
				un-=1;
				j[j.Count-1].GetComponent<Cube> ().MoveX = false;
				print (j.Count + "d");
				score +=1;
				UIScore.text = score.ToString();


			}
		}

	}
}
