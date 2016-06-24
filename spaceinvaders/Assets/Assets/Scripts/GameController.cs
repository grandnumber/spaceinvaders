﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject hazard;
	public Vector3 spawnValues;
	public Quaternion spawnRotation; 
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnWaves ());
	}

	IEnumerator spawnWaves (){
		yield return new WaitForSeconds (startWait);
		while (true){
			
			for( int i=0; i< hazardCount; i++){
					
			Vector3 spawnPosition  = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation =  Quaternion.identity; 
			Instantiate (hazard, spawnPosition, spawnRotation); 
			yield return new WaitForSeconds (spawnWait);
		}
			yield return new WaitForSeconds (waveWait); 
	}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
