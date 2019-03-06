using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {
    private GameObject target;
    private MeshRenderer mesh;

    public float PlayerHP;
    public float InvincibleTime;
    private bool isInvincible;
    private float tmpTime;
    private float meshTime;
    public bool isAttack = false;

    // Start is called before the first frame update
    void Start () {
        mesh = GetComponent<MeshRenderer> ();
        PlayerHP = 3;
        isInvincible = false;
        InvincibleTime = 3;
        meshTime = 0;
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
        }
    }
    public void OnCollisionStay (Collision collision) {
        if (collision.gameObject.CompareTag ("enemy")) {
            if (!isInvincible) {
                PlayerHP -= 1;
                isInvincible = true;
            }
            if (isAttack) {
                Destroy (collision.gameObject);
            }
        }
    }
}
