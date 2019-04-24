using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterGuess : MonoBehaviour {

	public string word;
	public string[] words;
	string[] hints;
	string hint;
	int index;
	public static char[] array;
	public Material[] blockAlphabet;
	public GameObject hintText;
	public List<GameObject> cubes = new List<GameObject>();
	string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	// Use this for initialization
	void Start () {
		hintText = GameObject.Find ("Hint");
		words = new string[] {"DOCTOR", "COPPER", "FRENCH", "LAWYER", "ORANGE"};
		hints = new string[] {"OCCUPATION", "METAL", "LANGUAGE", "OCCUPATION", "COLOR"};

		index = Random.Range (0, words.Length - 1);

		word = words[index];
		hint = hints [index];
		hintText.GetComponent<TextMesh> ().text = hint;
		array = word.ToCharArray ();

		int letterIndex;

		for (int i = 0; i < array.Length; i++) {
			letterIndex = alphabet.IndexOf (array [i]);

			cubes[i].GetComponent<Renderer> ().material = blockAlphabet [letterIndex];


		}

		foreach (GameObject g in cubes) {
			
			g.SetActive(false);

		}

	}

	public void CubesVisible(int block){
		cubes[block].SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
