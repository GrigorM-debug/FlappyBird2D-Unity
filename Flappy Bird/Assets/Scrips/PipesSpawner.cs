using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

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

        // pipesObject.transform.position += (Vector3)Vector2.up * Random.Range(minHeight, maxHeight);
        float randomY = Random.Range(minHeight, maxHeight);

        pipesObject.transform.position = new Vector3(
            pipesObject.transform.position.x,
            randomY,
            pipesObject.transform.position.z
        );
    }
}
