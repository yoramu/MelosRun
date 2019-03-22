using System.Collections;
using UnityEngine;

public class MainSoundScript : MonoBehaviour {
    public bool DontDestroyEnabled = true;
    void Start () {
        if (DontDestroyEnabled) {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad (this);
        }
    }
}