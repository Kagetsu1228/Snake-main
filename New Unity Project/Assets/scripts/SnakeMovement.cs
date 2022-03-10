
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public GameOver GameOver;
    private Vector2 _direction = Vector2.right;
    public int highscore = 0;
    
    private LinkedList<Transform> _segments;
    public Transform segmentPrefab;
    public Transform segment;

    private void Start()
    {
        _segments = new LinkedList<Transform>();
        _segments.AddFirst(this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        Vector3 position = new Vector3(
            x: Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );

        LinkedListNode<Transform> current = _segments.First;
        Vector3 oldPosition;
        while (current != null)
        {
            oldPosition = current.Value.position;
            current.Value.position = position;
            position = oldPosition;
            current = current.Next;
        }
        
        
    }

    private void Grow()
    {
        Vector3 tailPosition = _segments.Last.Value.position; 
        Vector3 position = new Vector3(tailPosition.x, tailPosition.y);
        
        segment =  Instantiate(this.segmentPrefab, position, Quaternion.identity);
        _segments.AddLast(segment);
    }

    private void ResetState()
    {
        GameOver.Setup(highscore);
    }

    public void AddPoints()
    {
        highscore += 100;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
            AddPoints();
        } else if (other.CompareTag("Obstacle"))
        {
            ResetState();
        }
    }
}
    
