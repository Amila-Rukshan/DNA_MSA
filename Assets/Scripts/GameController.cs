using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void StartBuildOfSeqs() {
        BuildAncestorAndScore.buildAncestor();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}



	