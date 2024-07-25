using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public static class TemplateInfras {

    public static void Load(TemplateContext ctx) {
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "BlockTM";
            var ptr = Addressables.LoadAssetsAsync<BlockTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.blocks.Add(go.typeID, go);
            }
            ctx.blockPtr = ptr;
        }
    }

    public static void Unload(TemplateContext ctx) {
        if (ctx.blockPtr.IsValid()) {
            Addressables.Release(ctx.blockPtr);
        }
    }
}
