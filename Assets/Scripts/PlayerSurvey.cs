using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurvey : MonoBehaviour
{
    Camera camera;

    public RaycastHit hit;

    public GameObject hitObject;

    private void Awake()
    {
        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.red);

        CheckLookObject();
    }

    public void CheckLookObject()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        if (Physics.Raycast(ray, out hit, 15f))
        {
            hitObject = hit.collider.gameObject;
        }
        else
        {
            hitObject = null;
        }
    }
}
