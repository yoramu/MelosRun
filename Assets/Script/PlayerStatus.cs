using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {
    private MeshRenderer mesh;
    private GameObject Canvas;
    private GameObject target;
    private CreateHeart CreateHeart;
    public Text scoreText;
    private bool isInvincible = false;
    private bool isAttack = false;
    public bool isDeath = false;
    public int PlayerHP = 3;
    [SerializeField] private float InvincibleTime = 3;
    private float meshTime = 0;
    private float tmpTime;
    public int score = 0;

    // Start is called before the first frame update
    void Start () {
        mesh = GetComponent<MeshRenderer> ();
        Canvas = GameObject.Find ("CanvasGUI");
        CreateHeart = Canvas.GetComponent<CreateHeart> ();
        tmpTime = InvincibleTime;
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
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
        //スコア
        scoreText.text = "Score:" + score;
    }
    public void OnCollisionStay (Collision collision) {
        if (collision.gameObject.CompareTag ("enemy")) {
            if (!isInvincible && !isAttack) {
                PlayerHP -= 1;
                isInvincible = true;
                Destroy (CreateHeart.listObj[PlayerHP]);
            }
            if (isAttack) {
                Destroy (collision.gameObject);
            }
        }
    }
    public void IsAttackTrue () {
        this.isAttack = true;
    }
    public void IsAttackFalse () {
        this.isAttack = false;
    }
}