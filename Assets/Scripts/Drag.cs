using UnityEngine;
using System.Collections;


 [RequireComponent(typeof(BoxCollider))]

 public class Drag : MonoBehaviour {
     private Vector3 screenPoint;
     private Vector3 offset;

 void OnMouseDown() {

     offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
 }

 void OnMouseDrag()
 {
     Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
     Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position =  Vector3.Lerp (transform.position, curPosition, UnityEngine.Time.deltaTime);
 }
 }
