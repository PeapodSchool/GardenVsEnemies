using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
    [SerializeField] Animator animator;
    EnemySpawner currentLaneSpawner;
    //[SerializeField] int damage;
    

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners =
            FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in
            spawners)
        {
            bool isCloseEnought = Mathf.Abs(
                spawner.transform.position.y -
                transform.position.y) <=
                Mathf.Epsilon;
            if (isCloseEnought == true)
            {
                currentLaneSpawner = spawner;
                break;
            }
        }
    }

    private bool IsEnemyInLane()
    {
        if (currentLaneSpawner.transform.childCount
            <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnemyInLane() == true)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public void Fire()
    {
        var projectile = Instantiate(projectilePrefab,
            gun.transform.position, Quaternion.identity);
    }
}
