using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] int damage = 100;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;

    public int GetDamage() { return damage; }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed
            * Time.deltaTime);
        /*        transform.Rotate(0, 0, rotationSpeed *
                    Time.deltaTime, Space.World);*/
        /*        transform.Rotate(Vector3.forward * Time.deltaTime
                   * moveSpeed, Space.World); */
        //transform.RotateAround(transform.position, Vector3.forward, 90f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Health enemyHealth = otherCollider.GetComponent<Health>();
        Enemy enemy = otherCollider.GetComponent<Enemy>();
        if (enemyHealth && enemy)
        {
            enemyHealth.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
