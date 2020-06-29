using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        float horizantalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizantalInput);
    }
}
