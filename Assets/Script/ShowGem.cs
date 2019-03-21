using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGem : MonoBehaviour {
    public GameObject uGUI_GemRed;
    public GameObject uGUI_GemGreen;
    public GameObject uGUI_GemBlue;
    // Start is called before the first frame update
    void Start () {
        uGUI_GemRed = GameObject.Find ("uGUI_GemRed");
        uGUI_GemGreen = GameObject.Find ("uGUI_GemGreen");
        uGUI_GemBlue = GameObject.Find ("uGUI_GemBlue");
        uGUI_GemRed.SetActive (false);
        uGUI_GemGreen.SetActive (false);
        uGUI_GemBlue.SetActive (false);
    }
    // Update is called once per frame
    void Update () { }
}
