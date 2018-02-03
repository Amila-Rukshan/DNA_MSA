using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateExtends : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        //Debug.Log("1");
        BuildAncestorAndScore.changescore += UpdateScoreBoard;

    }

    // Update is called once per frame
    void UpdateScoreBoard()
    {
        GetComponent<Text>().text = "extends: " + BuildAncestorAndScore.extends2;

    }
}
