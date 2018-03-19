using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScreen : MonoBehaviour {

    public Animator anim;
    void Start () {
        AnimatorClipInfo[] info = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, info[0].clip.length-1);
        //gameObject.SetActive(false);
    }
	
	
}
