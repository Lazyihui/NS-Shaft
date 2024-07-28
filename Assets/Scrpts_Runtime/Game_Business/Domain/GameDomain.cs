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
            int tem = UnityEngine.Random.Range(0, 10);

            int blockType = 0;
            if (tem == 0 || tem == 1) {
                blockType = 0;
            } else if (tem == 2 || tem == 3) {
                blockType = 1;
            } else if (tem == 4) {
                blockType = 2;
            } else if (tem == 5) {
                blockType = 3;
            } else if (tem == 6 || tem == 7) {
                blockType = 4;
            } else if (tem == 8 || tem == 9) {
                blockType = 5;
            }

            float x = UnityEngine.Random.Range(-4.75f, 4.75f);

            BlockDomain.Spawn(ctx, blockType, new Vector3(x, -6, 0));
            gameEntity.blockSpawnTimer = 0;
        }

    }

    public static void AddObjMoveSpeed(GameContext ctx, float dt) {
        GameEntity game = ctx.gameEntity;
        game.objMoveSpeed += 0.1f * dt;

        if (game.objMoveSpeed >= 3.5f) {
            game.blockSpawnInterval = 0.4f;
            return;
        }

        if (game.blockSpawnInterval >= 0.4f) {
            game.blockSpawnInterval -= 0.05f * dt;
        } else {
            game.blockSpawnInterval = 0.4f;
        }

        Debug.Log(game.blockSpawnInterval + "  " + game.objMoveSpeed);
    }

    public static void layerNumberUpate(GameContext ctx, float dt) {

        GameEntity game = ctx.gameEntity;

        game.layerTimer += dt;

        if (game.layerTimer >= game.layerInterval) {
            game.layerNumber++;
            game.layerTimer = 0;
        }

    }

}