using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTime : MonoBehaviour {
    public Text limitTimeText;
    public float limitTime { set; get; } = 100;
    // Start is called before the first frame update
    void Start () {
        limitTimeText.text = "Time:" + limitTime;
    }

    // Update is called once per frame
    void Update () {
        if (limitTime > 0) {
            limitTime -= Time.deltaTime;
        } else {
            limitTime = 0;
        }
        limitTimeText.text = "Time:" + Math.Floor (limitTime);
    }
}