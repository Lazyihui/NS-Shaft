using System;
using System.Collections.Generic;
using UnityEngine;


public class GameEntity
{
    public float restFixTime;
    public float objMoveSpeed;


    // 用于生成板子

    public float blockSpawnTimer;

    public float blockSpawnInterval;

    public GameEntity()
    {
        objMoveSpeed = 1.5f;

        blockSpawnTimer = 0;
        blockSpawnInterval =2.5f;
    }

}