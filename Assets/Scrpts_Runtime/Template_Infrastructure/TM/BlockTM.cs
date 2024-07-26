using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockTM", menuName = "Template/BlockTM")]
public class BlockTM : ScriptableObject {
    [Header("Block")]

    public int typeID;

    [Header("Conveyor")]

    public bool isLeft;

    public float moveSpeed;

    [Header("Animation")]

    public RuntimeAnimatorController animatior;

    public Sprite sprite;

    public string tag;

    public string Layer;

    public Vector2 colliderSize;

    [Header("Celling")]
    public bool isCelling;


}