using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockTM", menuName = "Template/BlockTM")]
public class BlockTM : ScriptableObject {
    [Header("Block")]

    public int typeID;

    [Header("Conveyor")]

    public bool isLeft;

    public float moveSpeed;
}