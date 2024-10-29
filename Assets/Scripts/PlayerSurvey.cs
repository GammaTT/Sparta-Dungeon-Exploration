using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSurvey : MonoBehaviour
{
    Camera camera;

    [SerializeField] private float rayDistance;

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
        //테스트용 레이
        Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.red);

    }

    private void FixedUpdate()
    {
        CheckLookObject();
    }

    public void CheckLookObject()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            hitObject = hit.collider.gameObject;
        }
        else
        {
            hitObject = null;
        }
    }
}
