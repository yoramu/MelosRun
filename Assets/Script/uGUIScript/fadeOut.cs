using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fadeOut : MonoBehaviour {
    private stageClear stageClear;
    public bool isWhiteScreen { get; private set; } = false;
    private float alfa;
    private float speed = 0.01f;
    private float red, green, blue;

    void Start () {
        stageClear = GameObject.Find ("clearTrigger").GetComponent<stageClear> ();
        red = GetComponent<Image> ().color.r;
        green = GetComponent<Image> ().color.g;
        blue = GetComponent<Image> ().color.b;
    }

    void Update () {
        if (stageClear.isClear) {
            GetComponent<Image> ().color = new Color (red, green, blue, alfa);
            alfa += speed;
        }
        if (alfa >= 1) {
            isWhiteScreen = true;
        }
    }
}
