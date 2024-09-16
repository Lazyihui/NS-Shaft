using System;
using System.Collections.Generic;
using UnityEngine;

public static class WallDomain {

    public static WallEntity Spawn(GameContext ctx, Vector3 pos) {

        WallEntity entity = GameFactory.Wall_Create(ctx, pos);

        ctx.wallRespository.Add(entity);
        return entity;
    }

    public static void Move(GameContext ctx, WallEntity wall, float dt) {
        wall.Move(dt);
    }

    public static void MoveSpeedUpdate(GameContext ctx, WallEntity wall) {
        wall.moveSpeed = ctx.gameEntity.objMoveSpeed;

    }
}