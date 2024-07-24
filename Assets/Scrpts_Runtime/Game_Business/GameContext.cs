using System;
using System.Collections.Generic;
using UnityEngine;

public class GameContext
{
    public GameEntity gameEntity;

    public IDService idService;
    //repo
    public WallRespository wallRespository;


    //Inject
    public AssetsContext assets;

    public GameContext()
    {
        gameEntity = new GameEntity();
        idService = new IDService();

        wallRespository = new WallRespository();
    }

    public void Inject(AssetsContext assets)
    {
        this.assets = assets;
    }
}