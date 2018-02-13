using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    // Use this for initialization
    void Awake() {
       // DontDestroyOnLoad(this);
    }
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //Debug.Log("2");
        //BuildAncestorAndScore.buildAncestor();
        //BuildAncestorAndScore.showAncestor();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}



	