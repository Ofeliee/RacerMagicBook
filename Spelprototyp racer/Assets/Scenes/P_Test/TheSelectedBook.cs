using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSelectedBook : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
        var fin = GameObject.Find("CharacterList");
        gameObject.GetComponent<CharacterSelection>().index = fin.GetComponent<CharacterSelection>().index;
        gameObject.GetComponent<CharacterSelection>().SelectedBook();



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
