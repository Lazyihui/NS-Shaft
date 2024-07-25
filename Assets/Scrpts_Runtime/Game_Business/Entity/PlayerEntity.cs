using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Animator animator;

    public LayerMask whatIsGround;

    public int id;

    public float moveSpeed;

    public void Ctor() { }

    public void Move(Vector2 moveAxis) {
        Vector2 oldVelocity = rb.velocity;
        oldVelocity.x = moveAxis.x * moveSpeed;
        rb.velocity = oldVelocity;

        //面向 

        Face(moveAxis.x);

        //  在地上的移动动画
        animator.SetFloat("Move", Mathf.Abs(moveAxis.x));

        bool isGround = isGrounded();
        animator.SetBool("isGround", isGround);
    }

    void Face(float xDir) {
        if (xDir > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (xDir < 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    bool isGrounded() {
        // 用射线检测地面
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        // Debug.DrawRay(transform.position, Vector2.down * 1.1f, Color.red);
        // return hit.collider != null;
        //  用圆
        return Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 0.25f, whatIsGround);
    }

}



















