using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Layer : MonoBehaviour {
    [SerializeField] public Text firstText;

    [SerializeField] public Text firstTextOld;

    public int floor;

    public int floorF, floorS, floorT;

    public Transform first, second, third;

    public Transform firstOld, secondOld, thirdOld;

    public void Ctor() {

    }

    public void Init(int layerNumber) {

        floor = layerNumber;
        floorF = floor / 100;
        floorS = (floor % 100) / 10;
        floorT = floor % 10;

    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

}
