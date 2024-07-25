using System;
using System.Collections.Generic;   
using UnityEngine;

public class Context{
    
    public AssetsContext assets;

    public GameContext gameContext;

    public ModuleInput moduleInput;

    public TemplateContext templateContext;

    public Context(){
        assets = new AssetsContext();
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
        templateContext = new TemplateContext();
    }


    public void Inject(){
        gameContext.Inject(assets,moduleInput,templateContext);
    }
}