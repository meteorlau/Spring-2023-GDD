using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMangosteen : EnemyBase
{
    // Start is called before the first frame update
    public GameObject circlePrefab;
    private Camera cam;

    [SerializeField] private GameObject hitVFX = null;
    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
    }

    protected override void Update()
    {
        base.Update();
    }

    public Material material;

    public void splatter()
    {

        Vector3 dimensions = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

        for (int i = 0; i < 10; i++)
        {
            int randX = Random.Range(0, (int) dimensions.x) * 2;
            int randY = Random.Range(0, (int) dimensions.y) * 2;
            
            Instantiate(circlePrefab, new Vector3(randX, randY, 0), Quaternion.identity);
        }
        

        ////circle prefab: instantiate
        //GameObject circle = new GameObject("Circle");
        //circle.layer = player.layer;

        //SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        //spriteRenderer.sprite = Resources.Load<Sprite>("");
        //spriteRenderer.color = Color.black;

        //MeshRenderer meshRenderer = square.AddComponent<MeshRenderer>();

        //MeshFilter meshFilter = square.AddComponent<MeshFilter>();

        //Mesh mesh = new Mesh();

        //Vector3[] vertices = new Vector3[4]
        //{
        //    new Vector3(0, 1),
        //    new Vector3(1, 1),
        //    new Vector3(0, 0),
        //    new Vector3(1, 0)
        //};
        //mesh.vertices = vertices;

        //int[] tris = new int[6]
        //{
        //    // lower left triangle
        //    0, 1, 2,
        //    // upper right triangle
        //    2, 1, 3
        //};
        //mesh.triangles = tris;

        //Vector3[] normals = new Vector3[4]
        //{
        //    -Vector3.forward,
        //    -Vector3.forward,
        //    -Vector3.forward,
        //    -Vector3.forward
        //};
        //mesh.normals = normals;

        //Vector2[] uv = new Vector2[4]
        //{
        //    new Vector2(0, 1),
        //    new Vector2(1, 1),
        //    new Vector2(0, 0),
        //    new Vector2(1, 0),
        //};
        //mesh.uv = uv;
        //Color[] colors = new Color[vertices.Length];

        //for (int i = 0; i < vertices.Length; i++)
        //    colors[i] = Color.Lerp(Color.red, Color.green, vertices[i].y);

        //// assign the array of colors to the Mesh.
        //mesh.colors = colors;

        //// assign the array of colors to the Mesh.
        //meshFilter.mesh = mesh;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //black out parts of camera
            //Color pink = new Color(0.0f, 0.6f, 0.3f, 1.0f);
            ////splatter();
            //collision.gameObject.GetComponent<Renderer>().material.color = pink;

            splatter();

            //GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
            //vfx.layer = gameObject.layer;
            //vfx.GetComponent<SpriteRenderer>().sortingLayerName = GetComponent<SpriteRenderer>().sortingLayerName;
            //Destroy(vfx, 5f);
            Destroy(gameObject);
        }
    }

    public override string ToString()
    {
        return "Mangosteen";
    }
}
