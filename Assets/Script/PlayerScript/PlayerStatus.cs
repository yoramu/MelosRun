using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {
    private MeshRenderer mesh;
    private GameObject Canvas;
    [SerializeField] private GameObject target;
    private CreateHeart CreateHeart;
    public Text scoreText;
    private bool isInvincible = false;
    private bool isAttack = false;
    public bool isDeath { get; private set; } = false;
    public int PlayerHP { get; private set; } = 3;
    [SerializeField] private float InvincibleTime = 3;
    private float meshTime = 0;
    private float tmpTime;
    private int score = 0;
    void Start () {
        mesh = GetComponent<MeshRenderer> ();
        Canvas = GameObject.Find ("CanvasGUI");
        CreateHeart = Canvas.GetComponent<CreateHeart> ();
        tmpTime = InvincibleTime;
        scoreText.text = "Score:" + score;
    }
    void Update () {
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
        //死亡フラグ
        if (PlayerHP < 1 || Canvas.GetComponent<LimitTime> ().limitTime < 0) {
            gameObject.SetActive (false);
            isDeath = true;
            Instantiate (target, transform.localPosition, transform.rotation);
        }
        //穴に落ちたらHPが0になる
        if (transform.localPosition.y < -30) {
            PlayerHP = 0;
        }
        //スコア
        scoreText.text = "Score:" + score;
    }
    //敵にあたった時の当たり判定とダメージ
    private void OnCollisionStay (Collision collision) {
        if (collision.gameObject.CompareTag ("enemy")) {
            if (!isInvincible && !isAttack) {
                PlayerHP -= 1;
                isInvincible = true;
                Destroy (CreateHeart.listObj[PlayerHP]);
                CreateHeart.LeftHearts ();
            }
            if (isAttack) {
                Destroy (collision.gameObject);
            }
        }
    }
    //トラップにあたった時の当たり判定とダメージ
    public void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("trap")) {
            if (!isInvincible) {
                PlayerHP -= 1;
                isInvincible = true;
                Destroy (CreateHeart.listObj[PlayerHP]);
                CreateHeart.LeftHearts ();
            }
        }
    }
    //他クラスから呼ばれるための関数。カプセル化。
    public void IsAttackTrue () {
        this.isAttack = true;
    }
    public void IsAttackFalse () {
        this.isAttack = false;
    }
    public void getScore (int score) {
        this.score += score;
    }
    public void AddPlayerHP () {
        this.PlayerHP += 1;
    }
}
