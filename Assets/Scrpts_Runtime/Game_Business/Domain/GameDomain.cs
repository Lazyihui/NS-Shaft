using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDomain {


    public static void ToSpawnBlock(GameContext ctx, float dt) {

        GameEntity gameEntity = ctx.gameEntity;

        gameEntity.blockSpawnTimer += dt;

        if (gameEntity.blockSpawnTimer >= gameEntity.blockSpawnInterval) {

            // 随机
            int blockType = UnityEngine.Random.Range(0, 4);
            float x = UnityEngine.Random.Range(-4.75f, 4.75f);

            BlockDomain.Spawn(ctx, blockType, new Vector3(x, -6, 0));
            gameEntity.blockSpawnTimer = 0;
        }

    }

}