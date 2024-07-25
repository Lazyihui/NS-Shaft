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

        entity.moveSpeed = tm.moveSpeed;
        entity.isLeft = tm.isLeft;


        ctx.blockRespository.Add(entity);
        return entity;



    }
}
