using System;
using UnityEngine;


public static class UIApp {

    #region Panel_HeartInfo

    public static void Panel_HeartInfo_Open(UIContext ctx, int heartCount) {

        Panel_HeartInfo panel = ctx.panel_HeartInfo;

        if (panel == null) {
            ctx.assetsContext.panels.TryGetValue("Panel_HeartInfo", out GameObject prefab);
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_HeartInfo>();
            panel.Ctor();
            ctx.panel_HeartInfo = panel;
        }
        panel.Init(heartCount);
        panel.Show();
    }

    public static void Panel_HeartInfo_Update(UIContext ctx, int heartCount) {
        Panel_HeartInfo panel = ctx.panel_HeartInfo;
        if (panel == null) {
            Debug.LogError("Panel_HeartInfo is not opened");
            return;
        }
        panel.Init(heartCount);
    }

    public static void Panel_HeartInfo_Close(UIContext ctx) {
        Panel_HeartInfo panel = ctx.panel_HeartInfo;
        if (panel == null) {
            Debug.LogError("Panel_HeartInfo is not opened");
            return;
        }
        panel.Close();
    }
    #endregion

    #region Panel_Layer
    public static void Panel_Layer_Open(GameContext ctxContext,UIContext ctx) {
        Panel_Layer panel = ctx.panel_Layer;
        if (panel == null) {
            ctx.assetsContext.panels.TryGetValue("Panel_Layer", out GameObject prefab);
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Layer>();
            panel.Ctor();
            ctx.panel_Layer = panel;
        }
        panel.Show();
        panel.Init(ctxContext.gameEntity.layerNumber);
    }

    public static void Panel_LayerNumber_Update(GameContext ctxContext, UIContext ctx) {
        Panel_Layer panel = ctx.panel_Layer;
        if (panel == null) {
            Debug.LogError("Panel_Layer is not opened");
            return;
        }
        panel.Init(ctxContext.gameEntity.layerNumber);
    }

    public static void Panel_Layer_Close(UIContext ctx) {
        Panel_Layer panel = ctx.panel_Layer;
        if (panel == null) {
            Debug.LogError("Panel_Layer is not opened");
            return;
        }
        panel.Close();
    }

    #endregion

}