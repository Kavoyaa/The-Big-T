using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent enemy;
    public float killDistance = 10f;

    bool hasKilled = false; // prevents multiple scene loads

    void Update()
    {
        enemy.SetDestination(target.position);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < killDistance && !hasKilled)
        {
            hasKilled = true;

            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene("GameOver");
        }
    }
}
