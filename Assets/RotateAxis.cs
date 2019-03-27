using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxis : MonoBehaviour {
    private GameObject Camera;
    private PlayerMove PlayerMove;
    private int cameraRotationYF;
    private int cameraRotationYC;
    [SerializeField] private int enterFromLeftAngle;
    [SerializeField] private int enterFromRightAngle;
    private float direction;
    private GameObject Player;
    void Start () {
        Camera = GameObject.Find ("MultipurposeCameraRig");
        Player = GameObject.Find ("chr_robot");
        PlayerMove = Player.GetComponent<PlayerMove> ();
    }
    void Update () {
        cameraRotationYF = Mathf.FloorToInt (Camera.transform.eulerAngles.y);
        cameraRotationYC = Mathf.CeilToInt (Camera.transform.eulerAngles.y);
        direction = PlayerMove.direction;
    }
    private void OnTriggerStay (Collider other) {
        //カメラを回してプレイヤーも追従させる
        if (other.gameObject.CompareTag ("Player")) {
            //プレイヤーが回転エリアからはみ出ないようにする
            transform.localScale = new Vector3 (10, 2, 10);
            if (direction > 0) {
                //
                if　 (Mathf.DeltaAngle (Camera.transform.eulerAngles.y, enterFromRightAngle) < -0.1f) {
                    Camera.transform.Rotate (new Vector3 (0f, -5f, 0f));
                }
                if　 (Mathf.DeltaAngle (Camera.transform.eulerAngles.y, enterFromRightAngle) > 0.1f) {
                    Camera.transform.Rotate (new Vector3 (0f, 5f, 0f));
                }
                if (cameraRotationYF == enterFromRightAngle || cameraRotationYC == enterFromRightAngle) {
                    transform.localScale = new Vector3 (1f, 2f, 1f);
                    Camera.transform.rotation = Quaternion.Euler (0, enterFromRightAngle, 0);
                    PlayerMove.IsMoveTrue ();
                }
            }
            if (direction < 0) {
                if　 (Mathf.DeltaAngle (Camera.transform.eulerAngles.y, enterFromLeftAngle) > 0.1f) {
                    Camera.transform.Rotate (new Vector3 (0f, 5f, 0f));
                }
                if　 (Mathf.DeltaAngle (Camera.transform.eulerAngles.y, enterFromLeftAngle) < -0.1f) {
                    Camera.transform.Rotate (new Vector3 (0f, -5f, 0f));
                }
                if (cameraRotationYF == enterFromLeftAngle || cameraRotationYC == enterFromLeftAngle) {
                    Camera.transform.rotation = Quaternion.Euler (0, enterFromLeftAngle, 0);
                    transform.localScale = new Vector3 (1f, 2f, 1f);
                    PlayerMove.IsMoveTrue ();
                }
            }
        }
    }
    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Player")) {
            if (cameraRotationYC == enterFromLeftAngle || cameraRotationYF == enterFromLeftAngle) {
                Player.transform.position = new Vector3 (transform.position.x, Player.transform.position.y, transform.position.z);
                PlayerMove.IsMoveFalse ();
            }
            if (cameraRotationYC == enterFromRightAngle || cameraRotationYF == enterFromRightAngle) {
                Player.transform.position = new Vector3 (transform.position.x, Player.transform.position.y, transform.position.z);
                PlayerMove.IsMoveFalse ();
            }
        }
    }
}