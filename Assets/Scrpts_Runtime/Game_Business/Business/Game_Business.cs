using System;
using UnityEngine;


public static class GameBusiness
{
    public static void Enter(GameContext ctx)
    {
        PlayerDomain.Spawn(ctx);

        WallDomain.Spawn(ctx, new Vector3(0, 0, 0));
        WallDomain.Spawn(ctx, new Vector3(0, -12.5f, 0));

        BlockDomain.Spawn(ctx, 0,new Vector3(0, -0.7f, 0));
        BlockDomain.Spawn(ctx, 1,new Vector3(-0.2f, -3, 0));
        BlockDomain.Spawn(ctx, 2,new Vector3(-4, -2, 0));

        BlockDomain.Spawn(ctx, 3,new Vector3(5, -2, 0));

        BlockDomain.Spawn(ctx, 4,new Vector3(0, 4.7f, 0));

    }

    public static void Load_Game(GameContext ctx)
    {

    }
    public static void UnLoad_Game(GameContext ctx)
    {

    }


    public static void Tick(GameContext ctx, float dt)
    {
        PreTick(ctx, dt);

        ref float restFixTime = ref ctx.gameEntity.restFixTime;

        restFixTime += dt;
        const float FIX_INTERVAL = 0.020f;

        if (restFixTime <= FIX_INTERVAL)
        {

            LogicFix(ctx, FIX_INTERVAL);
            restFixTime = 0;
        }
        else
        {
            while (restFixTime >= FIX_INTERVAL)
            {
                LogicFix(ctx, FIX_INTERVAL);
                restFixTime -= FIX_INTERVAL;
            }
        }



        LateTick(ctx, dt);
    }

    static void PreTick(GameContext ctx, float dt)
    {
        ctx.moduleInput.ProcessMove();
    }

    static void LogicFix(GameContext ctx, float dt)
    {
        int WallLen = ctx.wallRespository.TakeAll(out WallEntity[] walls);
        for (int i = 0; i < WallLen; i++)
        {
            WallEntity wall = walls[i];
            WallDomain.Move(ctx, wall, dt);
        }

        int PlayerLen = ctx.playerRespository.TakeAll(out PlayerEntity[] players);
        for (int i = 0; i < PlayerLen; i++)
        {
            PlayerEntity player = players[i];
            PlayerDomain.Move(ctx, player, ctx.moduleInput.moveAxis);
        }


    }

    static void LateTick(GameContext ctx, float dt)
    {
    }
}