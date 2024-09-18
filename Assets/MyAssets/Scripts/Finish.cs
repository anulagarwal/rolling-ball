using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            print("Win");
            FindObjectOfType<Ball>().GetComponent<Ball>().force =+ 500;

            FindObjectOfType<CameraFollow>().distance = 9;
            FindObjectOfType<CameraFollow>().height = -2;

            GameObject winParticle = GameObject.Find("WinParticle");
            winParticle.transform.parent = null;
            winParticle.transform.position = new Vector3(0, winParticle.transform.position.y, winParticle.transform.position.z);
            winParticle.transform.eulerAngles = new Vector3(90,0,90);
            winParticle.GetComponent<ParticleSystem>().Play();
            AudioManager.Instance.Play("WinParticle");
            Invoke("StopBall", 1);
            Destroy(FindObjectOfType<CameraFollow>());
            Destroy(GetComponent<BoxCollider>());

            if (86 == PlayerPrefs.GetInt("Level", 0))
                FindObjectOfType<GameManager>().OpenCommingSoonPanel();
            else
                FindObjectOfType<GameManager>().Win();
        }
    }

    private void StopBall()
    {
        FindObjectOfType<Ball>().gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
