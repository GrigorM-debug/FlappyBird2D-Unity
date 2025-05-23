using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Vector2 direction;

    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private AudioClip wingSound;

    [SerializeField] private AudioClip objectHitSound;
    [SerializeField] private AudioClip dieSound;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] sprites;

     //Scoring point audio
    [SerializeField] AudioClip scorePointSound;

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

    /*Changing different sprites stored in array to 
    simulated that the bird is flying*/
    private void PlayerSpriteAnimation()
    {
        currentSpriteIndex++;

        if (currentSpriteIndex >= sprites.Length)
        {
            currentSpriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    //If the bird hit pipe or ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log($"Object hit: {collision.gameObject.name}");
        //Add for the pipes
        if (collision.gameObject.tag == "Ground"
            || collision.gameObject.tag == "BottomPipe"
            || collision.gameObject.tag == "TopPipe")
        {
            Die();
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    //Triggering the scoring point between the pipes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoringPoint")
        {
            Debug.Log($"Scoring point entered: {collision.gameObject.name}");
            SoundFXManager.instance.PlaySoundFXClip(scorePointSound, transform, 1f);
            FindAnyObjectByType<GameManager>().IncreaseScore();

            //To prevent double scoring
            collision.gameObject.SetActive(false);
        }
    }

    //Playing die sounds
    private void Die()
    {
        SoundFXManager.instance.PlaySoundFXClip(objectHitSound, transform, 1f);
        SoundFXManager.instance.PlaySoundFXClip(dieSound, transform, 1f);

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z - 180
        );

        transform.position -= new Vector3(0, 5f, 0);
    }
}
