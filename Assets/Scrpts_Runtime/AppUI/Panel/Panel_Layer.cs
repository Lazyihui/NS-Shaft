using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Layer : MonoBehaviour {
    [SerializeField] public Text firstTextUp;

    [SerializeField] public Text firstTextDown;

    [SerializeField] public Text secondTextUp;

    [SerializeField] public Text secondTextDown;


    [SerializeField] public Text thirdTextUp;

    [SerializeField] public Text thirdTextDown;

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

        // int f = 0;
        // int s = 0;
        // int t = 0;

        // floorT = 
        thirdTextUp.text = floorT.ToString();
        secondTextUp.text = floorS.ToString();
        firstTextUp.text = floorF.ToString();


    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

}
