using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager; // GameManagerの取得
    // Start is called before the first frame update
    public void Awake() {
        if (GameManager.instance == null) {
            Instantiate(gameManager); // ヒエラルキー上にGameManagerを生成
        }
    }
}
