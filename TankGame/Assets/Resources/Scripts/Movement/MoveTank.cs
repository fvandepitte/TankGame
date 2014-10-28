using UnityEngine;
using System.Collections;

public class MoveTank : MonoBehaviour {

    public float smooth = 2.0F;
    public GameObject Tank;

    void Start() {

        Tank = Instantiate(Tank) as GameObject;

        if (Tank) {
            Camera.main.GetComponent<SmoothCamera2D>().target = Tank.transform;
        }
    }

	// Update is called once per frame
	void Update () {
        if (Tank) {

            //TankMovement
            var tankScript = Tank.GetComponent<Tank>();

            float tiltAroundZ = Input.GetAxis("Horizontal") * tankScript.RotationSpeed;
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

            Tank.rigidbody2D.velocity = (Tank.transform.up * tankScript.Speed * Input.GetAxis("Vertical"));
            Tank.rigidbody2D.transform.Rotate(target.eulerAngles);

            //BarrelMovement

            var barrelContainerScript = Tank.GetComponentInChildren<BarrelContainer>();
            var barrelContainer = barrelContainerScript.gameObject;

            //rotation
            Vector3 mousePos = Input.mousePosition;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(barrelContainer.transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            /*
            float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
            barrelContainer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
             */

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            Vector3 targetDir = new Vector3(0, 0, angle - 90);
            float step = barrelContainerScript.RotationSpeed * Time.deltaTime;


            barrelContainer.transform.rotation = Quaternion.RotateTowards(barrelContainer.transform.rotation, Quaternion.Euler(targetDir), step);

            if (Input.GetButtonDown("Fire1")) 
            {
                var barrelScript = Tank.GetComponentInChildren<Barrel>();
                barrelScript.Shoot();
            }
        }
	}
}
