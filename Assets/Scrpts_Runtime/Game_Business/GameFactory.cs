using System;
using UnityEngine;

public static class GameFactory {

    public static PlayerEntity Role_Create(GameContext ctx) {

        bool has = ctx.assets.TryGetEntity("Player_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("No prefab found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PlayerEntity entity = go.GetComponent<PlayerEntity>();

        entity.id = ctx.idService.playerIDRecord++;
        entity.healthMax = 10;
        entity.health = 10;

        entity.Ctor();


        return entity;
    }


    public static BlockEntity Block_Create(GameContext ctx, int typeID, Vector3 pos) {

        bool has = ctx.templateContext.blocks.TryGetValue(typeID, out BlockTM tm);

        if (!has) {
            Debug.LogError("No block found");
            return null;
        }
        ctx.assets.TryGetEntity("Block_Entity", out GameObject prefab);
        GameObject go = GameObject.Instantiate(prefab);

        go.tag = tm.tag;
        go.layer = LayerMask.NameToLayer(tm.Layer);
        BlockEntity entity = go.GetComponent<BlockEntity>();



        entity.Ctor();
        entity.id = ctx.idService.blockIDRecord++;
        entity.typeID = typeID;

        entity.SetPos(pos);
        entity.SetAni(tm.animatior);
        entity.SetSr(tm.sprite);
        entity.SetColliderSize(tm.colliderSize, tm.colliderOffset);

        entity.moveSpeed = tm.moveSpeed;
        entity.isLeft = tm.isLeft;
        entity.isCelling = tm.isCelling;

        entity.selfMoveSpeed = ctx.gameEntity.objMoveSpeed;

        return entity;
    }

    public static WallEntity Wall_Create(GameContext ctx, Vector3 pos) {

        bool has = ctx.assets.TryGetEntity("Wall_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("No prefab found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        WallEntity entity = go.GetComponent<WallEntity>();

        entity.id = ctx.idService.WallIDRecord++;
        entity.moveSpeed = ctx.gameEntity.objMoveSpeed;
        entity.SetPos(pos);
        return entity;
    }

}