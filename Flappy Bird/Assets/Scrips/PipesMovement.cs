using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    private float pipesSpeed = 5f;

    private float leftScreenEdge;

    // Start is called before the first frame update
    private void Start()
    {
        leftScreenEdge = Camera.main.ScreenToWorldPoint(Vector2.zero).x - 1f;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += (Vector3)Vector2.left * pipesSpeed * Time.deltaTime;

        //Destroy the pipe if it reaches the left screen edge
        if (transform.position.x < leftScreenEdge)
        {
            Destroy(gameObject);
        }
    }
}
