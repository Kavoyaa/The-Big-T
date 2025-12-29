using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent enemy;
    public float updateSpeed = 0.1f;
    public float killDistance = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(target.position);
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < killDistance)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


}
