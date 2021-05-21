using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
    [SerializeField] Animator animator;
    //[SerializeField] int damage;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
    }

    public void Fire()
    {
        var projectile = Instantiate(projectilePrefab,
            gun.transform.position, Quaternion.identity);
    }
}
