using System;
using System.Collections.Generic;


public class WallRespository {

    Dictionary<int, WallEntity> all;

    WallEntity[] temArray;

    public WallRespository() {
        all = new Dictionary<int, WallEntity>();
        temArray = new WallEntity[5];
    }

    public void Add(WallEntity entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(WallEntity entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out WallEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new WallEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out WallEntity entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<WallEntity> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }
    public WallEntity Find(Predicate<WallEntity> predicate) {
        foreach (WallEntity Wall in all.Values) {
            bool isMatch = predicate(Wall);

            if (isMatch) {
                return Wall;
            }
        }
        return null;
    }

}