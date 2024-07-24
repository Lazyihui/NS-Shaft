using System;
using System.Collections.Generic;
using UnityEngine;

public class GameContext
{
    public GameEntity gameEntity;

    public IDService idService;
    //repo
    public WallRespository wallRespository;

    public PlayerRespository playerRespository;


    //Inject
    public AssetsContext assets;

    public ModuleInput moduleInput;

    public GameContext()
    {
        gameEntity = new GameEntity();
        idService = new IDService();

        wallRespository = new WallRespository();
        playerRespository = new PlayerRespository();
    }

    public void Inject(AssetsContext assets, ModuleInput moduleInput)
    {
        this.assets = assets;
        this.moduleInput = moduleInput;
    }
}