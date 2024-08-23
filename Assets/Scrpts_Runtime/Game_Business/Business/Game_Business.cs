using System;
using UnityEngine;


public static class GameBusiness {
    public static void Enter(GameContext ctx) {
        PlayerDomain.Spawn(ctx);

        WallDomain.Spawn(ctx, new Vector3(0, 0, 0));
        WallDomain.Spawn(ctx, new Vector3(0, -12.5f, 0));

        BlockDomain.Spawn(ctx, 0, new Vector3(0, -4f, 0));
        BlockDomain.Spawn(ctx, 6, new Vector3(0, 4.7f, 0));

        UIApp.Panel_HeartInfo_Open(ctx.uiContext, 10);
        UIApp.Panel_Layer_Open(ctx, ctx.uiContext);

    }

    public static void Load_Game(GameContext ctx) {

    }
    public static void UnLoad_Game(GameContext ctx) {

    }


    public static void Tick(GameContext ctx, float dt) {

        PreTick(ctx, dt);

        ref float restFixTime = ref ctx.gameEntity.restFixTime;

        restFixTime += dt;
        // ref传进去的参数在函数内部可以直接使用，而out不可（除非在函数体内部，out参数在使用之前赋值）
        const float FIX_INTERVAL = 0.020f;

        if (restFixTime <= FIX_INTERVAL) {

            LogicFix(ctx, restFixTime);
            restFixTime = 0;
        } else {
            while (restFixTime >= FIX_INTERVAL) {
                restFixTime -= FIX_INTERVAL;
                LogicFix(ctx, FIX_INTERVAL);
            }
        }



        LateTick(ctx, dt);
    }



    static void PreTick(GameContext ctx, float dt) {
        ctx.moduleInput.ProcessMove();
    }

    static void LogicFix(GameContext ctx, float dt) {

        // game
        GameDomain.ToSpawnBlock(ctx, dt);
        GameDomain.layerNumberUpate(ctx, dt);
        GameDomain.AddObjMoveSpeed(ctx, dt);

        int WallLen = ctx.wallRespository.TakeAll(out WallEntity[] walls);
        for (int i = 0; i < WallLen; i++) {
            WallEntity wall = walls[i];
            WallDomain.Move(ctx, wall, dt);
            WallDomain.MoveSpeedUpdate(ctx, wall);
        }

        int PlayerLen = ctx.playerRespository.TakeAll(out PlayerEntity[] players);
        for (int i = 0; i < PlayerLen; i++) {
            PlayerEntity player = players[i];
            PlayerDomain.Move(ctx, player, ctx.moduleInput.moveAxis);
        }

        int BlockLen = ctx.blockRespository.TakeAll(out BlockEntity[] blocks);
        for (int i = 0; i < BlockLen; i++) {
            BlockEntity block = blocks[i];
            BlockDomain.MoveUp(ctx, block, dt);
            BlockDomain.FakeBlockTrigger(ctx, block);
            BlockDomain.MoveSpeedUpdate(ctx, block);
        }

    }

    static void LateTick(GameContext ctx, float dt) {
        PlayerEntity player = ctx.playerRespository.Find(x => x.id == 0);
        UIApp.Panel_HeartInfo_Update(ctx.uiContext, player.health);
        UIApp.Panel_LayerNumber_Update(ctx, ctx.uiContext);
    }
}