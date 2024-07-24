using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    Context ctx;
    bool isTearDown = false;

    void Awake()
    {

        ctx = new Context();

        ctx.Inject();

        // === Load===
        ModuleAssets.Load(ctx.assets);

        WallDomain.Spawn(ctx.gameContext);

    }

    void Update()
    {

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
