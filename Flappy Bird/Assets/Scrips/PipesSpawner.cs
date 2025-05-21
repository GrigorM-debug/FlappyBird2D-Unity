using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pripesPrefab;
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipes), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipes));
    }

    private void SpawnPipes()
    {
        GameObject pipesObject = Instantiate(pripesPrefab, transform.position, Quaternion.identity);

        if (pipesObject.GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rigidbody2D = pipesObject.AddComponent<Rigidbody2D>();
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            rigidbody2D.simulated = true;
        }

        if (pipesObject.GetComponent<BoxCollider2D>() == null)
        {
            BoxCollider2D boxCollider2D = pipesObject.AddComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = false;
            boxCollider2D.offset = new Vector2(0, 0);
            boxCollider2D.size = new Vector2(0.6f, 3.2f);
        }

        foreach (var child in pipesObject.GetComponentsInChildren<Transform>())
        {

            if (child.tag.Contains("ScoringPoint"))
            {
                BoxCollider2D childBoxColider = child.GetComponent<BoxCollider2D>();
                childBoxColider.isTrigger = true;childBoxColider.size = new Vector2(0.25f, 2.25f);
            }
        }

        pipesObject.transform.position += (Vector3)Vector2.up * Random.Range(minHeight, maxHeight);
    }
}
