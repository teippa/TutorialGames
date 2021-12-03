using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    private Rigidbody2D laserBody;

    [SerializeField] float laserVelocity = 1;

    // Start is called before the first frame update
    void Awake()
    {
        laserBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (laserBody.position.magnitude > 20)
        {
            gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        gameObject.SetActive(true);
        laserBody.velocity = Vector2.up * laserVelocity; 
    }
}
