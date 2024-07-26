using System;
using UnityEngine;
using UnityEngine.UI;

public class BlockEntity : MonoBehaviour {

    [SerializeField] Animator animator;

    [SerializeField] SpriteRenderer sr;

    [SerializeField] BoxCollider2D boxCollider2D;



    public int id;

    public int typeID;


    public bool isLeft;

    public float moveSpeed;

    public float selfMoveSpeed;

    //bool 
    public bool isCelling;



    public void Ctor() {

    }

    public void SetPos(Vector3 pos) {
        transform.position = pos;
    }

    public void SetSr(Sprite sprite) {
        sr.sprite = sprite;
    }

    public void SetAni(RuntimeAnimatorController ani) {
        animator.runtimeAnimatorController = ani;
    }


    public void SetColliderSize(Vector2 size) {
        boxCollider2D.size = size;
    }

    public void MoveUp(float dt) {
        transform.position += Vector3.up * selfMoveSpeed * dt;

        // 超出屏幕销毁
        if (transform.position.y > 6) {
            TearDown();
        }
    }

    public void TearDown() {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision) {

        PlayerEntity player = collision.gameObject.GetComponent<PlayerEntity>();


        // normal conveyor
        if (!gameObject.CompareTag("Nails")) {


            // 要改 扣血
            PlayerDomain.ModifyHealth(collision.gameObject.GetComponent<PlayerEntity>(), 1);
            player.currentBlock = GetComponent<BoxCollider2D>();

        } else {

            // 尖刺 会扣血的东西
            if (collision.contacts[0].normal == Vector2.down) {
                // 要改 加血
                PlayerDomain.ModifyHealth(collision.gameObject.GetComponent<PlayerEntity>(), -1);
                player.currentBlock = GetComponent<BoxCollider2D>();

            }

            if (collision.contacts[0].normal == Vector2.up) {
                // 要改 扣血
                PlayerDomain.ModifyHealth(collision.gameObject.GetComponent<PlayerEntity>(), -1);
                player.DisableCurrentBlock();
            }
        }


    }

    void OnCollisionStay2D(Collision2D collision) {

        if (gameObject.CompareTag("Conveyor") && collision.contacts[0].normal == Vector2.down) {

            Vector2 dir = isLeft ? Vector2.left : Vector2.right;
            collision.gameObject.transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;

        }

    }

}