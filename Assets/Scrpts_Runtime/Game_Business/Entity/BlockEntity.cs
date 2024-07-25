using System;
using UnityEngine;

public class BlockEntity : MonoBehaviour {


    public int id;

    public int typeID;


    public bool isLeft;

    public float moveSpeed;
    public void Ctor() {

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