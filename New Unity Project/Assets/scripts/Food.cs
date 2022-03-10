
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    public BoxCollider2D GridArea;
    public Transform FruitTransform;
    public Transform SnakeTransform;
    public BoxCollider2D snakeBox;
    private Vector3 FruitPos;


    private void Awake()
    {
        FruitTransform = GetComponent<Transform>();
    }

    private void Start()
    {

        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.GridArea.bounds;
        
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizePosition();
        }
    }
}

   
