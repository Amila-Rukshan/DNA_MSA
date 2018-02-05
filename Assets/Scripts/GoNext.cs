using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNext : MonoBehaviour {

    public void GoToNext() {
        BuildAncestorAndScore.buildAncestor();
    }
}
