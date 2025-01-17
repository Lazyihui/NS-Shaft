using System;
using UnityEngine;


public static class PlayerDomain {

    public static PlayerEntity Spawn(GameContext ctx) {

        PlayerEntity entity = GameFactory.Role_Create(ctx);
        ctx.playerRespository.Add(entity);
        return entity;
    }

    public static void ModifyHealth(PlayerEntity player, int value) {
        player.ModifyHealth(value);
    }

    public static void Move(GameContext ctx, PlayerEntity player, Vector2 moveAxis) {
        player.Move(moveAxis);

    }

    public static void MoveUp(PlayerEntity player, float trampolineSpeed) {
        player.moveUp(trampolineSpeed);
    }


}


