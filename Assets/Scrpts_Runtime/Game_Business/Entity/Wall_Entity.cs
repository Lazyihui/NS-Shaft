using System;
using System.Collections.Generic;

using UnityEngine;


public class WallEntity : MonoBehaviour
{
    public int id;

    public float moveSpeed;
    public void Ctor() { }

    // 移动速度 == Game_Entity.objMoveSpeed
    public void Move(float dt)
    {
        Vector2 pos = transform.position;
        pos += moveSpeed * dt * Vector2.up;// 向上移动
        transform.position = pos;
        if (pos.y > 12.5f)
        {
            transform.position = new Vector3(0, -12.5f, 0);
        }
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }
}