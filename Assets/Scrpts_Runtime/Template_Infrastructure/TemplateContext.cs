using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateContext{
    public Dictionary<int ,BlockTM> blocks;

    public AsyncOperationHandle blockPtr;

    public TemplateContext() {
        blocks = new Dictionary<int, BlockTM>();
    }

}