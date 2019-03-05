using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatusScript : MonoBehaviour {
    public float PlayerHP;
    public float InvincibleTime;
    public GameObject target;
    public bool isInvincible;
    private float tmpTime;
    // Start is called before the first frame update
    void Start () {
        PlayerHP = 100;
        isInvincible = false;
        InvincibleTime = 100;
        tmpTime = InvincibleTime;
    }

    // Update is called once per frame
    void Update () {
        if (PlayerHP < 1) {
            Destroy (gameObject);
            Instantiate (target, transform.localPosition, transform.rotation);
            //SceneManager.LoadScene ("GameOverScene");
        }
        //無敵状態フラグ
        if (isInvincible) {
            tmpTime--;
            if (tmpTime < 1) {
                isInvincible = false;
                tmpTime = InvincibleTime;
            }
        }
    }
    public void OnCollisionStay (Collision collision) {
        if (!isInvincible) {
            if (collision.gameObject.CompareTag ("enemy")) {
                PlayerHP -= 20;
                isInvincible = true;
            }
        }
    }
}
