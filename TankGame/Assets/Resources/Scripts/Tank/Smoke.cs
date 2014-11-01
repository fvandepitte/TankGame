using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {
    
    public float TTL = 0.9F;
    private float start;

	// Use this for initialization
	void Start () {
        start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (start + TTL - Time.time < 0)
        {
            Destroy(gameObject);
        }
	}
}
