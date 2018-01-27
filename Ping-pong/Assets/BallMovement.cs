using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    
	void Start () {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(3,0,3), ForceMode.Impulse);
    }
}
