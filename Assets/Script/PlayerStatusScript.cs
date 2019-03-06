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
    public bool isAttack = false;

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
            if (collision.gameObject.CompareTag ("enemy")) {
                if (!isInvincible) {
                    PlayerHP -= 20;
                    isInvincible = true;
                }
                if(isAttack){
                    Destroy (collision.gameObject);
                }
        }
    }
}
