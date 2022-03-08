using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int wallHp = 3;
    public Sprite dmgWall;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackDamage(int loss) {
        spriteRenderer.sprite = dmgWall;

        wallHp -= loss;

        if (wallHp <= 0) {
            gameObject.SetActive(false);
        }
    }
}
