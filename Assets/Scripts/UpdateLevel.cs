using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevel : MonoBehaviour {

    private static int level = 1;
    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = "LEVEL: " + level;
    }

    public void incrementLevel()
    {
        level += 1;
        GetComponent<Text>().text = "LEVEL: " + level;
    }

    public static void setLevel(int level) {
        UpdateLevel.level = level;   
    }

    
}
