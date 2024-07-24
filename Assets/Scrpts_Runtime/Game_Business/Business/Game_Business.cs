using System;
using UnityEngine;


public static class GameBusiness
{
    public static void Enter(GameContext ctx)
    {
        WallDomain.Spawn(ctx,new Vector3(0,0,0));
        WallDomain.Spawn(ctx,new Vector3(0,-12.5f,0));
        Debug.Log("GameBusiness Enter");

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
    }

    static void LogicFix(GameContext ctx, float dt)
    {
        int WallLen = ctx.wallRespository.TakeAll(out WallEntity[] walls);
        for (int i = 0; i < WallLen; i++)
        {
            WallEntity wall = walls[i];
            WallDomain.Move(ctx, wall, dt);
        }


    }

    static void LateTick(GameContext ctx, float dt)
    {
    }
}