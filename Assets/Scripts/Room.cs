using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour {

	public Home home;

	private IEnumerable<Collider2D> colliders;
	
	void Start () {
		colliders = GetComponentsInChildren<Collider2D>().Where(col => !col.isTrigger);
	}

	void Update() {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wubs" && !home.displayed) {
			foreach(Collider2D col in colliders) {
				Physics2D.IgnoreCollision(other, col, false);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Wubs") {
			foreach(Collider2D col in colliders) {
				if(col.tag == "Objects" && !col.IsTouching(GetComponent<Collider2D>())) {

				} else {
					Physics2D.IgnoreCollision(other, col, true);
				}
			}
		}
	}
}
