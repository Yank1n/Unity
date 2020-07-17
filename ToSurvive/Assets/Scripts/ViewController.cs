using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 1;
    private Vector3 weaponPosition;

    void Start()
    {

    }
    void FixedUpdate()
    {
        if (!EnemyScript.gameOver && !GameManager.win)
        {
            weaponPosition = GameObject.Find("w_handgun").transform.position;
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);

                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, weaponPosition, transform.rotation);
            }
        }
    }
}
