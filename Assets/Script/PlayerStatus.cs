using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {
    public GameObject target;
    private GameObject ContinueButton;
    private GameObject GameOverText;
    private MeshRenderer mesh;

    public bool isInvincible = false;
    public bool isAttack = false;
    private float PlayerHP = 3;
    private float InvincibleTime = 3;
    private float meshTime = 0;
    private float tmpTime;

    // Start is called before the first frame update
    void Start () {
        mesh = GetComponent<MeshRenderer> ();
        tmpTime = InvincibleTime;
        GameOverText = GameObject.Find ("GameOverText");
        GameOverText.SetActive (false);

    }

    // Update is called once per frame
    void Update () {
        if (PlayerHP < 1) {
            Destroy (gameObject);
            Instantiate (target, transform.localPosition, transform.rotation);
            GameOverText.SetActive (true);
            //SceneManager.LoadScene ("GameOverScene");
        }
        //無敵状態フラグ
        if (isInvincible) {
            tmpTime -= Time.deltaTime;
            mesh.enabled = false;
            if (tmpTime * 10 % 2 > 1) {
                mesh.enabled = true;
            }
            if (tmpTime < 0) {
                mesh.enabled = true;
                isInvincible = false;
                tmpTime = InvincibleTime;
            }
        } else {
            mesh.enabled = true;
        }
    }
    public void OnCollisionStay (Collision collision) {
        if (collision.gameObject.CompareTag ("enemy")) {
            if (!isInvincible && !isAttack) {
                PlayerHP -= 1;
                isInvincible = true;
            }
            if (isAttack) {
                Destroy (collision.gameObject);
            }
        }
    }
}
