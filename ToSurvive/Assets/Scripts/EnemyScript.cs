using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private bool isDead = false;
    public bool isPlayerDead = false;
    private NavMeshAgent enemyAgent;
    private Vector3 playerPos;
    private Animator animator;
    static public int playerHP;
    static public bool gameOver;

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerHP = 5;
        gameOver = false;
    }
    void Update()
    {
        if (!gameOver && !GameManager.win)
        {
            playerPos = GameObject.Find("Isometric Person Camera").transform.position;
            /*Ray rayToPlayer = new Ray(transform.position, playerPos);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayToPlayer, out hitInfo, rayRange, chasing))
            {
                enemyAgent.SetDestination(hitInfo.point);
            }*/
            float distance = Vector3.Distance(transform.position, playerPos);
            if (distance <= 2.8f)
            {
                animator.SetBool("attack", true);
            }
            else if (distance >= 2.8f && !isDead)
            {
                animator.SetBool("attack", false);
                enemyAgent.destination = playerPos;
            }
            if (playerHP == 0)
                gameOver = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerHP--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            StartCoroutine(Death());
            isDead = true;
            animator.SetBool("isDead", true);
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
