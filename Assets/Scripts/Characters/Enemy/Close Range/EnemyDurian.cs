using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDurian : EnemyBase
{
    [SerializeField] private GameObject cloud = null;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.DestroyEnemy();
            SpawnCloud();
            Destroy(transform.parent.gameObject);
        }
    }

    public override string ToString()
    {
        return "EnemyBomber";
    }

    public void SpawnCloud()
    {
        GameObject vfx = Instantiate(cloud, transform.position, Quaternion.identity);
        vfx.layer = gameObject.layer;
        vfx.GetComponent<SpriteRenderer>().sortingLayerName = GetComponent<SpriteRenderer>().sortingLayerName;
    }
}