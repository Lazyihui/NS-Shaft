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
        entity.SetColliderSize(tm.colliderSize);

        entity.moveSpeed = tm.moveSpeed;
        entity.isLeft = tm.isLeft;
        entity.isCelling = tm.isCelling;

        entity.selfMoveSpeed =ctx.gameEntity.objMoveSpeed;


        ctx.blockRespository.Add(entity);
        return entity;

    }

    public static void MoveUp(GameContext ctx, BlockEntity block, float dt) {
        
        if(block == null){
            return;
        }
        
        if(block.isCelling){
            return;
        }else{
            block.MoveUp(dt);
        }

    
    }
}
