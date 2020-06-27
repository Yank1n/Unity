using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float horizontalInput;
	public float speed = 10f;
	public float xRange = 10f;
	public GameObject projectilePrefab;

    void Update()
    {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//launch projectile from player
			Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
		}

		//Keep player in bounds
		if (transform.position.x < -xRange)
		{
			transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
		}

		if (transform.position.x > xRange)
		{
			transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
		}

		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
