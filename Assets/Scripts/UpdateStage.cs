using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStage : MonoBehaviour {

    private int stage = 1;
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "STAGE: " + stage;
    }

    public void incrementStage() {
        stage += 1;
        GetComponent<Text>().text = "STAGE: " + stage;
    }
    public void setStage(int stage)
    {
        this.stage = stage;
        GetComponent<Text>().text = "STAGE: " + stage;
    }

}
