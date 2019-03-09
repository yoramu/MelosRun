using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DecisionGameOver : MonoBehaviour {
    public GameObject Player;
    public GameObject GameOverText;
    public GameObject PleasePush;
    public GameObject target;
    public int PlayerHP;
    public bool flag = false;
    private double tmpTime = 0;
    void Start () {
        GameOverText = GameObject.Find ("GameOverText");
        GameOverText.SetActive (false);
        PleasePush = GameObject.Find ("PleasePush");
        PleasePush.SetActive (false);
        Player = GameObject.Find ("chr_robot");
    }
    void Update () {
        PlayerHP = Player.GetComponent<PlayerStatus> ().PlayerHP;
        if (PlayerHP < 1 && !flag) {
            GameOverText.SetActive (true);
            PleasePush.SetActive (true);
            Instantiate (target, Player.transform.localPosition, Player.transform.rotation);
            Player.SetActive (false);
            flag = true;
            //Destroy (Player);
        }
        if (flag) {
            tmpTime += Time.deltaTime;
            PleasePush.SetActive (false);
            if (tmpTime * 1 % 2 > 1) {
                PleasePush.SetActive (true);
            }
            if (Input.GetKeyDown (KeyCode.Return)) {
                SceneManager.LoadScene ("MainGameScene");
            }
        }
    }
}
