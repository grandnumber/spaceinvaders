using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion; 
	public GameObject playerExplosion; 

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("boundary")) {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);

		if (other.gameObject.CompareTag ("boundary")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
			Destroy(other.gameObject); 
			Destroy(gameObject); 
		
	}

	}
