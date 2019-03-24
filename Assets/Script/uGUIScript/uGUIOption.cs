using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uGUIOption : MonoBehaviour {
    private GameObject Player;
    private GameObject Canvas;
    private GameObject Panel;
    private GameObject GameOver;
    private GameObject Clear;
    private GameObject Score;
    private GameObject PleasePush;
    private PlayerStatus PlayerStatus;
    private fadeOut fadeOut;
    private double tmpTime = 0;

    private float alfa;
    private float speed = 0.01f;
    void Start () {
        GameOver = GameObject.Find ("GameOver");
        PleasePush = GameObject.Find ("PleasePush");
        Clear = GameObject.Find ("Clear");
        Player = GameObject.Find ("chr_robot");
        Canvas = GameObject.Find ("CanvasGUI");
        Panel = GameObject.Find ("Panel");
        Score = GameObject.Find ("Score");
        PleasePush.SetActive (false);
        GameOver.SetActive (false);
        Clear.SetActive (false);
    }
    void Update () {
        PlayerStatus = Player.GetComponent<PlayerStatus> ();
        fadeOut = Panel.GetComponent<fadeOut> ();
        if (PlayerStatus.isDeath) {
            GameOver.SetActive (true);
            PleasePush.SetActive (true);
            tmpTime += Time.deltaTime;
            if (tmpTime * 1 % 2 > 1) {
                PleasePush.SetActive (false);
            }
            if (Input.GetKeyDown (KeyCode.Return)) {
                SceneManager.LoadScene ("StageScene");
            }
        }

        if (fadeOut.isWhiteScreen) {
            Clear.SetActive (true);
            Score.GetComponent<Text> ().color = new Color (1, 0.92f, 0.016f, 1);
            PleasePush.GetComponent<Text> ().color = new Color (1, 0.92f, 0.016f, 1);
            PleasePush.SetActive (true);
            tmpTime += Time.deltaTime;
            if (tmpTime * 1 % 2 > 1) {
                PleasePush.SetActive (false);
            }
            Clear.GetComponent<Text> ().color = new Color (
                Clear.GetComponent<Text> ().color.r,
                Clear.GetComponent<Text> ().color.g,
                Clear.GetComponent<Text> ().color.b,
                alfa);
            alfa += speed;
            if (Input.GetKeyDown (KeyCode.Return)) {
                SceneManager.LoadScene ("TitleScene");
            }
        }
    }
}
