using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_HeartInfo : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Transform heartGroup;


    List<Image> element;


    public void Ctor() {
        element = new List<Image>();
    }

    public void Init(int hp) {


        int lasthp = element.Count;
        int diff = hp - lasthp;

        if (diff < 0) {
            for (int i = -diff; i > 0; i--) {
                Image ele = element[element.Count - 1];
                element.RemoveAt(element.Count - 1);
                Destroy(ele.gameObject);
            }
        } else if (diff > 0) {
            for (int i = 0; i < diff; i++) {

                Image ele = GameObject.Instantiate(elePrefab, heartGroup);
                element.Add(ele);

            }
        } else {
            // do nothing
        }
    }


    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }


}

