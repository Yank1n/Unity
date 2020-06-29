using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup;
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 10.0f;
    public GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            hasPowerup = true;
            StartCoroutine(PowerupCountdownRoutine());

        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(6);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Oops");
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
