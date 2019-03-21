using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlienEye : MonoBehaviour {
    public float direction { get; private set; } = -0.1f;
    [SerializeField] private float speed = 5;
    private Rigidbody PlayerRigid;
    [SerializeField] private float enemyAngle = 0;
    void Start () {
        PlayerRigid = GetComponent<Rigidbody> ();
    }
    void Update () {
        //ステージを回すときに敵がずれてしまうため、プレイヤーが敵と同じ角度の位置のフィールドにいないときは敵を停止させる
        if (Mathf.Floor (transform.parent.transform.rotation.eulerAngles.y) == enemyAngle) {
            PlayerRigid.transform.localPosition += new Vector3 (direction * Time.deltaTime * speed, 0.0f, 0.0f);
        }
    }
}