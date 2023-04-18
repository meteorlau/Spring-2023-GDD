using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsoletePlayer : MonoBehaviour
{

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }

    private float speed = 8f;
    private float vert = 0f;
    private float horz = 0f;

    private Rigidbody2D player;
    private Camera cam;
    private Vector2 mousePos;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {

        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if (horz == 0) {
            player.velocity = new Vector2(0, player.velocity.y);
        } else {
            player.velocity = new Vector2(horz * speed, player.velocity.y);
        }

        if (vert == 0) {
            player.velocity = new Vector2(player.velocity.x, 0);
        } else {
            player.velocity = new Vector2(player.velocity.x, vert * speed);
        }

        if (Input.GetKeyDown(KeyCode.F)) 
        {
            Interactable?.Interact(this);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // movement is controlled by key press
        // moveSpeed is set in inspector
        Vector2 lookDirection = mousePos - player.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        player.rotation = angle;
    }
}