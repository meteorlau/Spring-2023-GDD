using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMangosteen : EnemyBase
{
    // Start is called before the first frame update

    [SerializeField] private GameObject hitVFX = null;
    [SerializeField] private int explosionDamage = 5;
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
            Color pink = new Color(0.0f, 0.6f, 0.3f, 1.0f);
            collision.gameObject.GetComponent<Renderer>().material.color = pink;
            GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
            vfx.layer = gameObject.layer;
            vfx.GetComponent<SpriteRenderer>().sortingLayerName = GetComponent<SpriteRenderer>().sortingLayerName;
            Destroy(vfx, 5f);
            Destroy(transform.parent.gameObject);
        }
    }

    public override string ToString()
    {
        return "Mangosteen";
    }
}
