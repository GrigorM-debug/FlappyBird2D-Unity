using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 direction;

    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private AudioClip wingSound;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] sprites;

    private int currentSpriteIndex = 0;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(PlayerSpriteAnimation), 0.15f, 0.15f);
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        //Keyboard and mouse input
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            SoundFXManager.instance.PlaySoundFXClip(wingSound, transform, 1f);
            direction = Vector2.up * jumpForce;
        }

        //Touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                SoundFXManager.instance.PlaySoundFXClip(wingSound, transform, 1f);
                direction = Vector2.up * jumpForce;
            }
        }

        //Apply gravity
        direction.y += gravity * Time.deltaTime;
        transform.position += (Vector3)direction * Time.deltaTime;
    }

    private void PlayerSpriteAnimation()
    {   
        currentSpriteIndex++;

        if (currentSpriteIndex > sprites.Length)
        {
            currentSpriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }
}
