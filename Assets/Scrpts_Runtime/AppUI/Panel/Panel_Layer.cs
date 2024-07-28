using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Layer : MonoBehaviour {
    [SerializeField] Text firstText;
    [SerializeField] Text secondText;
    [SerializeField] Text thirdText;


    public void Ctor() {

    }


    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

}
