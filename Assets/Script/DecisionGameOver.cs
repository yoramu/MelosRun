using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DecisionGameOver : MonoBehaviour {
    private GameObject Player;
    private GameObject Canvas;
    private GameObject GameOverText;
    private GameObject PleasePush;
    private PlayerStatus PlayerStatus;
    private double tmpTime = 0;
    void Start () {
        GameOverText = GameObject.Find ("GameOverText");
        PleasePush = GameObject.Find ("PleasePush");
        Player = GameObject.Find ("chr_robot");
        Canvas = GameObject.Find ("CanvasGUI");
        PleasePush.SetActive (false);
        GameOverText.SetActive (false);
    }
    void Update () {
        PlayerStatus = Player.GetComponent<PlayerStatus> ();
        if (PlayerStatus.isDeath) {
            GameOverText.SetActive (true);
            PleasePush.SetActive (true);
            tmpTime += Time.deltaTime;
            if (tmpTime * 1 % 2 > 1) {
                PleasePush.SetActive (false);
            }
            if (Input.GetKeyDown (KeyCode.Return)) {
                SceneManager.LoadScene ("MainGameScene");
            }
        }
    }
}