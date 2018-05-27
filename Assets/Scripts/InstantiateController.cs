using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstantiateController : MonoBehaviour {
	float x;
	 
	public Text UIScore;
	public Button buttonP;
	public GameObject spam1;
	public GameObject spam2;
	public int best = 0;
	public GameObject spam3;
	public float incrementNotCut = 0.0f;
	public GameObject cube; 
	bool gameOver = false;
	bool play = false;
	public GameObject bg;
	public Camera maincamera;
	public Material bd;
	public Text textBest;
	public int points;
	public List<GameObject> j;
	public GameObject s; 
	public GameObject scoreControler;
	public int score = 0; 
	public float incrementForCubes = 0.0f;
	float m = 1f;
	public Animation anim;
	public Text textFinal;
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
		incrementForCubes = spam1.GetComponent<Transform>().localScale.y; 
		textBest.gameObject.SetActive(false);
		best = scoreControler.GetComponent<scoreControler> ().getBest ();
		textBest.text = "Best Score: " + best.ToString();
		textFinal.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {


		var k = d;

		if (Input.GetKeyDown(KeyCode.Space) && !gameOver && play) {
			GameObject d;
			maincamera.GetComponent<Animator>().SetTrigger("setMoveCamera");
			//maincamera.transform.position = new Vector3(-10, , -9);
			//maincamera.transform.position = new Vector3 (maincamera.transform.position.x, maincamera.transform.position.y + incrementForCubes, maincamera.transform.position.z);
			IntersectingType typecube = k.IntersectingCubes(j[j.Count-1], j[j.Count-2],j[j.Count-1].GetComponent<Cube> ().MoveX, 0.06f );
			bg.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
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
				if (m == 0) {d.transform.position = new Vector3 (tallat.transform.position.x+12, tallat.transform.position.y + incrementForCubes,tallat.transform.position.z);}
				else {d.transform.position = new Vector3 (tallat.transform.position.x, tallat.transform.position.y + incrementForCubes,tallat.transform.position.z+12);}
				var copia = tallat.transform.localScale;
				d.transform.localScale = copia;
				notallat.AddComponent<Rigidbody>();
				x+=Time.deltaTime;
				if (x>=3){
					Destroy(notallat);
				}
				score += 1;
				incrementNotCut = 0;
			}
			else if (typecube == IntersectingType.NOT_CUT) {
				d = Instantiate (s);
				GameObject identiCube = Instantiate(j[j.Count-2], new Vector3(j[j.Count-2].transform.position.x,j[j.Count-1].transform.position.y, j[j.Count-2].transform.position.z), Quaternion.identity);
				j.Add(identiCube);
				j.Add(d);	
				d.GetComponent<Renderer>().material.color = GetComponent<ColorManager>().getNextColor();
				j[j.Count-3].GetComponent<Cube>().enabled = false;
				d.transform.localScale = identiCube.transform.localScale;
				if (m == 0) {d.transform.position = new Vector3 (identiCube.transform.position.x+12, identiCube.transform.position.y + incrementForCubes,identiCube.transform.position.z);}
				else {d.transform.position = new Vector3 (identiCube.transform.position.x, identiCube.transform.position.y + incrementForCubes,identiCube.transform.position.z+12);}
				print(incrementNotCut);
				if (incrementNotCut == 2) 
				{
					identiCube.GetComponent<Transform>().localScale = new Vector3(identiCube.GetComponent<Transform>().localScale.x + 1f, identiCube.GetComponent<Transform>().localScale.y, identiCube.GetComponent<Transform>().localScale.z+1f); 
					d.GetComponent<Transform>().localScale = new Vector3(d.GetComponent<Transform>().localScale.x + 1f, d.GetComponent<Transform>().localScale.y, d.GetComponent<Transform>().localScale.z+1f);incrementNotCut = 0; 
					incrementNotCut = 0;
				}
				print("NOTCUT");
				score += 1;
				incrementNotCut +=1;

			}
			else {
				print("GAMEOVER");
				j[j.Count-1].AddComponent<Rigidbody>();
				j[j.Count-1].GetComponent<Cube>().enabled = false;
				gameOver = true;
				maincamera.GetComponent<Animator>().SetTrigger("setGameOver");
				UIScore.gameObject.SetActive(false);
				textFinal.gameObject.SetActive(true);
				textFinal.text =  "Best Score: " + best.ToString();
				InvokeRepeating("setSize", 0, 0.1f);
				Invoke("finishScene", 3.5f);
			}

			scoreControler.GetComponent<scoreControler> ().setScore(score);
			UIScore.text = score.ToString();
			if (m == 0) {j[j.Count-1].GetComponent<Cube> ().MoveX = true;}
			else {j[j.Count-1].GetComponent<Cube> ().MoveX = false;}
			m+=1;
			if (m == 2f) m = 0;

			

			best = scoreControler.GetComponent<scoreControler> ().getBest ();

			if (score >= best) {
				scoreControler.GetComponent<scoreControler> ().setBest (score);
				textBest.text = "Best Score: " + best.ToString();
			}

		}


	}		
	public void destroyTallat () {
		
	}
	public void buttonPlay () {
			cube.gameObject.GetComponent<Cube>().enabled = true;
			j[j.Count-1].GetComponent<Cube> ().MoveX = true;
			textBest.gameObject.SetActive(true);
			play = true; 
			cube.transform.position = new Vector3(cube.transform.position.x+20, cube.transform.position.y, cube.transform.position.z);
			buttonP.gameObject.SetActive(false);
			UIScore.text = "0";

	}
	public void setSize () {
		if  (maincamera.GetComponent<Camera>().orthographicSize != 80) {
		maincamera.GetComponent<Camera>().orthographicSize += 0.25f;
		}
	}
	public void finishScene() {
 		SceneManager.LoadScene("scene");
	}
}
