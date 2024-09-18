using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class CameraFollow : MonoBehaviour {

    public float distance;
    public float height;
    //public Transform tf;
    //public Transform ballTransform;
    //public Rigidbody rgBall;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rgBall = ballTransform.GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Dot product of two normalized vector is equals to cos of theire angle.
    //    float yRotation = -Mathf.Acos(Vector3.Dot(rgBall.velocity.normalized, Vector3.right)) * Mathf.Rad2Deg;
    //    tf.eulerAngles = new Vector3(0, yRotation, 0);
    //}

    public float smoothness;

    public Transform camTarget;

    Vector3 velocity;

    void LateUpdate()
    {
        if (!camTarget)
            return;

        Vector3 pos = Vector3.zero;
        pos.x = camTarget.position.x;
        pos.y = camTarget.position.y + height;
        pos.z = camTarget.position.z - distance;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);
    }

    //public Transform target;

    //private void Start()
    //{
    //    GetComponent<NavMeshAgent>().SetDestination(target.position);
    //}

    //private void Update()
    //{
    //   // transform.localPosition = new Vector3(0, 0, transform.localPosition.z);
    //}
}
