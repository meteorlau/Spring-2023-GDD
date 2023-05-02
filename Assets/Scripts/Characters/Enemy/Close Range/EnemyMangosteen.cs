using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMangosteen : EnemyBase
{
    private MangosteenDotManager dotManager;

    protected override void Start()
    {
        base.Start();
        dotManager = FindObjectOfType<MangosteenDotManager>();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dotManager.EnableDots();
            GameManager.Instance.DestroyEnemy();
            Destroy(transform.parent.gameObject);
        }
    }

    public override string ToString()
    {
        return "EnemyBomber";
    }
}