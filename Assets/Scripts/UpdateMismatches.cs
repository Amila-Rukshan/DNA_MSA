using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMismatches : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        BuildAncestorAndScore.changescore += UpdateScoreBoard;

    }

    // Update is called once per frame
    void UpdateScoreBoard()
    {
        GetComponent<Text>().text = "mismatches: " + BuildAncestorAndScore.mismatches2;

    }
}
