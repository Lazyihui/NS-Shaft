using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    Context ctx;
    bool isTearDown = false;

    void Awake() {
        // ==== Phase: Instantiate ====

        ctx = new Context();
        // ==== Phase: Inject ====
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        ctx.Inject(canvas);


        // ==== Phase: Load ====
        ModuleAssets.Load(ctx.assets);
        TemplateInfras.Load(ctx.templateContext);

        // ==== Phase: Enter Game ====
        GameBusiness.Enter(ctx.gameContext);

    }

    void Update() {
        float dt = Time.deltaTime;
        GameBusiness.Tick(ctx.gameContext, dt);

    }

    void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assets);
        TemplateInfras.Unload(ctx.templateContext);
    }
}
