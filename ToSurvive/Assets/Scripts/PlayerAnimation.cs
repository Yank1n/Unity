using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isDead;
    void Start()
    {
        animator = GetComponent<Animator>();
        isDead = false;
    }

    void FixedUpdate()
    {
        isDead = EnemyScript.gameOver;
        if (!EnemyScript.gameOver && !GameManager.win)
        {
            if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
                animator.SetBool("isRunning", true);
            else
                animator.SetBool("isRunning", false);
        }
        else
            animator.SetTrigger("isDead");

    }
}
