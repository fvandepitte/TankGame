using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public GameObject Smoke;

    public int TTL = 5;
    public float MaxSpeed = 20F;
    public float radius = 5.0F;
    public float power = 10.0F;

    private float start;
    private bool loaded;


	// Use this for initialization
	void Start () {
        start = Time.time;
        if (UnityEngine.Random.value < .15F)
        {
            rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
        }

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        gameObject.rigidbody.velocity = Vector3.Lerp(gameObject.rigidbody.velocity, gameObject.rigidbody.transform.up * MaxSpeed, Time.fixedDeltaTime);

        loaded = Time.time - start > 0.05f;

        if (start + TTL - Time.time < 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision col) {
        if (loaded) {
            Instantiate(Smoke, transform.position, transform.rotation);
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit && hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(power, explosionPos, radius);

            }

            Destroy(gameObject);
        }
    }
}
