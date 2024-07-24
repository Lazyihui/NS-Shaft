using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Animator animator;
 

    public int id;

    public float moveSpeed;

    public void Ctor() { }

    public void Move(Vector2 moveAxis)
    {
        Vector2 oldVelocity = rb.velocity;
        oldVelocity.x = moveAxis.x * moveSpeed;
        rb.velocity = oldVelocity;

        //面向 
        
        Face(moveAxis.x);

        // 动画
    }

    void Face(float xDir)
    {
        if (xDir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (xDir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}



















