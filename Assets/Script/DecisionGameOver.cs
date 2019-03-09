using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionGameOver : MonoBehaviour {
    public GameObject Player;
    public GameObject GameOverText;
    public GameObject PleasePush;
    public GameObject target;
    public int PlayerHP;
    public bool flag = false;
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
            if (Input.GetKeyDown (KeyCode.Return)) {
                SceneManager.LoadScene ("MainGameScene");
                Mesh.enabled = false;
                if (tmpTime * 10 % 4 > 2) {
                    Mesh.enabled = true;
                }
            }
        }
    }
}