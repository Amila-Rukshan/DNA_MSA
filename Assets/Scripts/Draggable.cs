using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	private Vector3 startPos;

	private Vector3[] InitialPositions;

	private Rigidbody2D rigid;

	private List<Image> blocks;

    //private float v;

    void Start() {
   
        blocks = AddSprites.blocks;
    }
	
	public void OnBeginDrag(PointerEventData eventData){
		//saving the start position of this object
		startPos = this.transform.localPosition;
		InitialPositions = new Vector3[blocks.Count];

		for (int i = 0; i < blocks.Count; i++) {
			InitialPositions [i] = blocks[i].transform.localPosition;
		}
		//Debug.Log (startPos);
	}

	public void OnDrag(PointerEventData eventData){


		//var pos = this.transform.position;
		//pos.x = Input.mousePosition.x;
		//this.transform.position = pos;
        
		rigid = GetComponent<Rigidbody2D>();

		rigid.velocity = new Vector3(Input.mousePosition.x - this.transform.position.x, 0,0).normalized * 500;
        

        //var mousePos = cam.ScreenToWorldPoint (eventData.position);
        //Debug.Log ("mouse: "+ Input.mousePosition+", "+"object: "+this.transform.localPosition);

        //Debug.Log (eventData.position.x);
        //var pos = this.transform.localPosition;
        //pos.x = mousePos.x;
        //this.transform.localPosition = pos;
    }

	public void OnEndDrag(PointerEventData eventData){


        //int jumpUnits = Mathf.RoundToInt(this.transform.localPosition.x-startPos.x)/202;
        //this.transform.localPosition = new Vector3 (startPos.x+102*jumpUnits, startPos.y, 0);
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<BoxCollider2D>().enabled = false;
        }

       
        for (int i = 0; i < blocks.Count; i++) {
            blocks[i].GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
			int jump = Mathf.RoundToInt(blocks[i].transform.localPosition.x-InitialPositions[i].x)/152;
			blocks[i].transform.localPosition = new Vector3 (InitialPositions[i].x+152*jump, InitialPositions[i].y, 0);
		}

        StartCoroutine(Wait());

        
        BuildAncestorAndScore.buildAncestor();

        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.3f);
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].GetComponent<BoxCollider2D>().enabled = true;
                }

    }
}
