using System;
using System.Collections.Generic;


public class BlockRespository
{

    Dictionary<int, BlockEntity> all;

    BlockEntity[] temArray;

    public BlockRespository()
    {
        all = new Dictionary<int, BlockEntity>();
        temArray = new BlockEntity[5];
    }

    public void Add(BlockEntity entity)
    {
        all.Add(entity.id, entity);
    }

    public void Remove(BlockEntity entity)
    {
        all.Remove(entity.id);
    }

    public int TakeAll(out BlockEntity[] array)
    {
        if (all.Count > temArray.Length)
        {
            temArray = new BlockEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out BlockEntity entity)
    {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<BlockEntity> action)
    {
        foreach (var item in all.Values)
        {
            action(item);
        }
    }
    public BlockEntity Find(Predicate<BlockEntity> predicate)
    {
        foreach (BlockEntity Block in all.Values)
        {
            bool isMatch = predicate(Block);

            if (isMatch)
            {
                return Block;
            }
        }
        return null;
    }

}