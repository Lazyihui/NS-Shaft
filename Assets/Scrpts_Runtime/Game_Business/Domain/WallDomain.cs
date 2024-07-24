using System;
using System.Collections.Generic;
using UnityEngine;

public static class WallDomain
{

    public static WallEntity Spawn(GameContext ctx)
    {
        bool has = ctx.assets.TryGetEntity("Wall_Entity", out GameObject prefab);
        if (!has)
        {
            Debug.LogError("No prefab found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        WallEntity entity = go.GetComponent<WallEntity>();

        entity.id = ctx.idService.WallIDRecoder++;
        entity.moveSpeed = ctx.gameEntity.objMoveSpeed;

        ctx.wallRespository.Add(entity);
        return entity;
    }

    public static void Move(GameContext ctx, WallEntity wall, float dt)
    {
        wall.Move(dt);
    }
}