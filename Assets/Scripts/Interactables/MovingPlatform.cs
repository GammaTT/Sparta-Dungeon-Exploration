using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector3 StartPosition;
    [SerializeField] Vector3 EndPosition;


    public float movingTime;

    private float u;

    bool startToEnd = true;

    // Start is called before the first frame update
    void Start()
    {
        u = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startToEnd)
        {
            transform.position = (1 - u) * StartPosition + u * EndPosition;
        }
        else
        {
            transform.position = (1 - u) * EndPosition + u * StartPosition;
        }

        u -= Time.deltaTime / movingTime;

        if (u < 0.01f)
        {
            startToEnd = !startToEnd;
            u = 1.0f;
        }

        //Mathf.Lerp
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            controller.isOnMovingPlatform = true;
            controller.movingPlatform = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            controller.isOnMovingPlatform = false;
        }
    }
}
