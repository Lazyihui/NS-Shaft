using System;
using UnityEngine;


public static class PlayerDomain
{

    public static PlayerEntity Spawn(GameContext ctx)
    {
        bool has = ctx.assets.TryGetEntity("Player_Entity", out GameObject prefab);
        if (!has)
        {
            Debug.LogError("No prefab found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PlayerEntity entity = go.GetComponent<PlayerEntity>();

        entity.id = ctx.idService.playerIDRecord++;

        entity.Ctor();

        return entity;
    }

}


