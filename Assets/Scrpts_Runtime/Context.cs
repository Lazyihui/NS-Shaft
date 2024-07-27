using System;
using System.Collections.Generic;   
using UnityEngine;

public class Context{
    
    public AssetsContext assets;

    public GameContext gameContext;

    public ModuleInput moduleInput;

    public TemplateContext templateContext;

    public UIContext uiContext;

    public Context(){
        assets = new AssetsContext();
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
        templateContext = new TemplateContext();
        uiContext = new UIContext();
    }


    public void Inject(Canvas canvas){
        gameContext.Inject(assets,moduleInput,templateContext,uiContext);
        uiContext.Inject(assets,canvas);
    }   
}