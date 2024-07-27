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

                if (element.Count > 0) {
                    ele.transform.position = Vector3.zero;
                    Vector3 pos = new Vector3(13.5f, 0, 0);
                    ele.transform.position = pos + new Vector3(22 * element.Count, 0, 0);
                    Debug.Log("pos:" + ele.transform.position);
                }
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

