using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LapCounter : MonoBehaviour {

    public int CurrentLap = 1;
    private Text LapNR;
    public GameObject listRef;

	// Use this for initialization
	void Start () {

        LapNR = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        CurrentLap = listRef.GetComponent<CheckList>().currentLap;
        LapNR.text = CurrentLap.ToString("");
	}
}
