using System;
using UnityEngine;
using UnityEngine.UI;

public class BlockEntity : MonoBehaviour {

    [SerializeField] Animator animator;

    [SerializeField] SpriteRenderer sr;


    public int id;

    public int typeID;


    public bool isLeft;

    public float moveSpeed;
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

    void OnCollisionEnter2D(Collision2D collision) {

        if (!gameObject.CompareTag("Nails")) {

            PlayerDomain.ModifyHealth(collision.gameObject.GetComponent<PlayerEntity>(), 1);

        } else {
            if (collision.contacts[0].normal == Vector2.down) {

                PlayerDomain.ModifyHealth(collision.gameObject.GetComponent<PlayerEntity>(), -1);
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