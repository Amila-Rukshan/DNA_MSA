using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    private  FloatingText popupTextPos;

    private FloatingText popupTextNeg;

    private  GameObject parentObj;

    private Vector2 position;

    void Start() {
        popupTextPos = Resources.Load<FloatingText>("Prefabs/PopupTextParentPositive");
        popupTextNeg = Resources.Load<FloatingText>("Prefabs/PopupTextParentNegative");
        Debug.Log("initialized");
    }

    public void CreateFloatingText(string text, int posOrNeg){
        Debug.Log("before popup creation");
        if (posOrNeg > 0)
        {
            Debug.Log("plus");
            FloatingText instance = Instantiate(popupTextPos);
            instance.transform.SetParent(parentObj.transform, false);
            instance.transform.localPosition = position;
            instance.SetPopupText(text);
        }
        else if(posOrNeg < 0)
        {
            Debug.Log("minus");
            FloatingText instance = Instantiate(popupTextNeg);
            instance.transform.SetParent(parentObj.transform, false);
            instance.transform.localPosition = position;
            instance.SetPopupText(text);
        }
        
        
    }

    public void SetParentContent(GameObject parent) {
        this.parentObj = parent;
        
    }

    public void SetPositionRelativeToContent(Vector2 position) {
        this.position = position;
    }
}
