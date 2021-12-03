using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D body;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            body.position += Vector2.left * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.position += Vector2.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            body.position += Vector2.up * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.position += Vector2.down * moveSpeed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject laser = ObjectPool.SharedInstance.GetPooledObject();
            if (laser != null)
            {
                laser.transform.position = body.transform.position;
                laser.transform.rotation = body.transform.rotation;

                laser.GetComponent<LaserController>().Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
