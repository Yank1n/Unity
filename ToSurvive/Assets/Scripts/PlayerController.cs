using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;

    void Start()
    {

    }

    void Update()
    {
        if (!EnemyScript.gameOver && !GameManager.win)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = -Input.GetAxisRaw("Vertical");

            Vector3 movementDirection = new Vector3(verticalInput, 0f, horizontalInput).normalized;

            if (movementDirection.magnitude >= 0.1f)
            {
                controller.Move(movementDirection * speed * Time.deltaTime);
            }
        }
    }
}
