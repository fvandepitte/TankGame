using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    public GameObject Bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Shoot() {
        Transform bulletPoint = transform.FindChild("BulletPoint");
        if (bulletPoint)
        {
            GameObject bullet = Instantiate(Bullet, bulletPoint.position, bulletPoint.rotation) as GameObject;
            bullet.transform.Translate(new Vector3(0, 0, 0.001f));
            bullet.rigidbody.velocity = GetComponentInParent<Tank>().rigidbody2D.velocity;
        }
    }
}
