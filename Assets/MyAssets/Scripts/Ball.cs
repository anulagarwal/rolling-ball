using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float force;
    private bool onground;
    private Rigidbody rb;
    public float maxAngulerVelocity;
    private Vector2 direction;
    public Joystick xJoystick, yJoystick;
    private Transform checkPoint;
    private int ballCount = 0;
    public ForceMode forceMode;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngulerVelocity;
    }

    private void Update()
    {
        direction = new Vector2(xJoystick.Direction.x, yJoystick.Direction.y);

        rb.AddTorque(Vector3.right * force * direction.y, forceMode);
        rb.AddTorque(Vector3.back * force * direction.x, forceMode);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fail"))
        {
            if (ballCount == 0 || checkPoint == null)
            {
                FindObjectOfType<GameManager>().RetryGame();
                Destroy(FindObjectOfType<CameraFollow>());
                Destroy(this);
            }
            else
            {
                transform.position = checkPoint.position;
                rb.velocity = Vector3.zero;
                transform.eulerAngles = Vector3.zero;
                ballCount--;
                FindObjectOfType<GameManager>().RemoveBallChance();
            }
        }

        if (other.gameObject.name == "Checkpoint" || other.gameObject.name == "Checkpoint " || other.gameObject.name == "Checkpoint (2)")
        {
            AudioManager.Instance.Play("CheckPoint");
            checkPoint = other.gameObject.transform;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.Instance.Play("Coin");
            FindObjectOfType<GameManager>().CoinCollect();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)
        {
            AudioManager.Instance.Play("Hit");
        }

        if (collision.gameObject.layer == 11)
        {
            onground = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            GetComponent<AudioSource>().Stop();
            onground = false;
        }
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 vel = rb.velocity;
        if (vel.magnitude > 2 && onground)
        {
            if(!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
        }
    }

}
