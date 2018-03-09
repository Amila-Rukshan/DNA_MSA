using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

    public Animator animText;

    private Text score;

    void Awake() {
        score = animText.GetComponent<Text>();
        Debug.Log("text was initialized");
        AnimatorClipInfo[] info = animText.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, info[0].clip.length-1);  
    }

    public void SetPopupText(string text) {
        score.text = text;
    }

}
