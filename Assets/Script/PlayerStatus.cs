using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {
    public float PlayerHP;
    public float InvincibleTime;
    public GameObject target;
    private MeshRenderer mesh;
    private bool isInvincible;
    private float tmpTime;
    private float meshTime;
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
        if (!isInvincible) {
            if (collision.gameObject.CompareTag ("enemy")) {
                PlayerHP -= 1;
                isInvincible = true;
            }
        }
    }
}
