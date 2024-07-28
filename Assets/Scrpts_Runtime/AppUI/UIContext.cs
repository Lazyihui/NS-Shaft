using System;
using UnityEngine;


public class UIContext {


    public Panel_HeartInfo panel_HeartInfo;

    public Panel_Layer panel_Layer;

    // inject

    public Canvas canvas;

    public AssetsContext assetsContext;


    public UIContext() {

    }

    public void Inject(AssetsContext assetsContext, Canvas canvas) {
        this.assetsContext = assetsContext;
        this.canvas = canvas;
    }


}