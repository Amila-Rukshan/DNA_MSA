using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject level;

	void Awake () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        BuildAncestorAndScore.level = UserData.GetLevel();
        UpdateScore.level = UserData.GetLevel();
        UpdateLevel.setLevel(UserData.GetLevel());
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



	