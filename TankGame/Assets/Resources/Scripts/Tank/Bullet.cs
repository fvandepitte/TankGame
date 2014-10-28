using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int TTL = 5;
    private float start;

	// Use this for initialization
	void Start () {
        start = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (start + TTL - Time.time < 0)
        {
            Destroy(gameObject);
        }
	}
}
