using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed
            * Time.deltaTime);
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
