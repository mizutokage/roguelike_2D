using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isMoving = false;//現在動いているかの判定
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");//変数に方向キー横軸の入力を格納
        int vertical = (int)Input.GetAxisRaw("Vertical");//変数に方向キー縦軸の入力を格納

        if(horizontal != 0)//横軸の入力が0ではないとき
        {
            vertical = 0;//縦軸の入力を0に

            if (horizontal == 1)//横軸の入力が1の時
            {
                transform.localScale = new Vector3(1, 1, 1);//キャラの向きを右へ
            }
            else if (horizontal == -1)//横軸の入力が-1の時
            {
                transform.localScale = new Vector3(-1, 1, 1);//キャラの向きを左へ
            }
        }
        else if(vertical != 0)////縦軸の入力が0ではないとき
        {
            horizontal = 0;//横軸の入力を0に
        }

        if(horizontal != 0 || vertical != 0)//横軸か縦軸の入力が0ではないとき
        {
            Move(horizontal, vertical);//関数を呼ぶ（引数はキーボードの入力値）
        }
    }
    
    public void Move(int x, int y)//移動用の関数
    {
        Vector2 start = transform.position;//Playerの現在位置を変数に格納
        Vector2 end = start + new Vector2(x, y);//移動したい位置を格納

        if (!isMoving)//今移動中でないかの確認
        {
            StartCoroutine(Movement(end));//実際にコルーチンでplayerを動かしていく
        }
    }

    IEnumerator Movement(Vector3 end)//playerを動かしていくコルーチン
    {
        isMoving = true;//移動中の判定をtrueに

        float remainingDistance = (transform.position - end).sqrMagnitude;//移動したい位置との距離の2乗を出す

        while(remainingDistance > float.Epsilon)//距離とEpsilonを比較
        {
            //playerの現在位置を変更（現在位置、移動したい目的位置、変化量）
            transform.position = Vector3.MoveTowards(this.gameObject.transform.position, end, 10f * Time.deltaTime);

            remainingDistance = (transform.position - end).sqrMagnitude;///移動したい位置との距離の2乗を出す

            yield return null;//処理を止めて次のフレームから処理を再開させる
        }
        transform.position = end;//目的地に移動させる
        isMoving = false;//移動中の判定をfalseに

    }
}