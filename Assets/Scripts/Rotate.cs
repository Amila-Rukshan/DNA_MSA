using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    int spinSpeed  = 500;
 
 void  Update()
    {
        this.transform.Rotate(0, 0, -spinSpeed * Time.deltaTime);
    }
}
