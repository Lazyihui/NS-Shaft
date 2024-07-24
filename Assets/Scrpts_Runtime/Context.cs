using System;
using System.Collections.Generic;   
using UnityEngine;

public class Context{
    
    public AssetsContext assets;

    public Context(){
        assets = new AssetsContext();
    }


    public void Inject(){}
}