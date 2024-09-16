using System;
using UnityEngine;

public static class BlockDomain {

    public static BlockEntity Spawn(GameContext ctx, int typeID, Vector3 pos) {


        BlockEntity entity = GameFactory.Block_Create(ctx, typeID, pos);

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

    public static void MoveSpeedUpdate(GameContext ctx, BlockEntity block) {
        block.selfMoveSpeed = ctx.gameEntity.objMoveSpeed;
    }

}
