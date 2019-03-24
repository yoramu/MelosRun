using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlienEye : MonoBehaviour {
    public float direction { get; private set; } = -0.1f;
    [SerializeField] private float speed = 10;
    private Rigidbody PlayerRigid;
    [SerializeField] private float enemyAngle = 0;
    private float tempTime1 = 0.0f;
    [SerializeField] private float interval = 0.01f;
    [SerializeField] private int stack = 0;
    private bool flag = false;
    private int temp = 0;
    void Start () {
        PlayerRigid = GetComponent<Rigidbody> ();
    }
    void Update () {
        //ステージを回すときに敵がずれてしまうため、プレイヤーが敵と同じ角度の位置のフィールドにいないときは敵を停止させる
        if (Mathf.Floor (transform.parent.transform.rotation.eulerAngles.y) == enemyAngle) {
            tempTime1 += Time.deltaTime;
            if (tempTime1 >= interval) {
                PlayerRigid.transform.localPosition += new Vector3 (direction * Time.deltaTime * speed, 0.0f, 0.0f);
                if (stack > 100) {
                    direction *= -1;
                    stack = 0;
                    flag = true;
                    // this.transform.Rotate (new Vector3 (0, 0, 180));
                }
                tempTime1 = 0;
                stack += 1;
            }
        }
        //敵を回す
        if (flag) {
            this.transform.Rotate (new Vector3 (0, 0, 10));
            temp += 1;
            if (temp > 17) {
                flag = false;
                temp = 0;
            }
        }
    }
}
