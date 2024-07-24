using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    Context ctx;
    bool isTearDown = false;

    void Awake()
    {
        // ==== Phase: Instantiate ====

        ctx = new Context();
        // ==== Phase: Inject ====

        ctx.Inject();

        // ==== Phase: Load ====
        ModuleAssets.Load(ctx.assets);

        // ==== Phase: Enter Game ====
        GameBusiness.Enter(ctx.gameContext);

    }

    void Update()
    {
        float dt = Time.deltaTime;
        GameBusiness.Tick(ctx.gameContext, dt);
    }

    void OnDestory()
    {
        TearDown();
    }

    void OnApplicationQuit()
    {
        TearDown();
    }

    void TearDown()
    {
        if (isTearDown)
        {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assets);
    }
}
