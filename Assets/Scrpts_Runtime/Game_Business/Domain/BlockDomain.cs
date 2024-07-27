using System;
using UnityEngine;

public static class BlockDomain {

    public static BlockEntity Spawn(GameContext ctx, int typeID, Vector3 pos) {

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


        ctx.blockRespository.Add(entity);
        return entity;

    }

    public static void MoveUp(GameContext ctx, BlockEntity block, float dt) {

        if (block == null) {
            return;
        }

        if (block.isCelling) {
            return;
        } else {
            block.MoveUp(dt);
        }
    }

    // 假板子collider 2D 的消失 和 animator .setTrigger("Move") 就是播动画

    public static void FakeBlockTrigger(GameContext ctx, BlockEntity block) {
        if (block == null || block.typeID != 4) {
            return;
        }

        PlayerEntity player = ctx.playerRespository.Find(x => x.id == 0);

        if (block.fakeTimer > 0.35f) {
            block.fakeTimer = 0;
            block.animator.SetTrigger("Move");
            player.DisableCurrentBlock();
        }
    }

    

}
