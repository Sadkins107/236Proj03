using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    private Vector3 smoothPos;
    private float smoothSpeed = .05f;

    public GameObject cameraLeftBorder;
    public GameObject cameraRightBorder;

    private float cameraHalf;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraHalf = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float leftBorder = cameraLeftBorder.transform.position.x + cameraHalf;
        float rightBorder = cameraRightBorder.transform.position.x - cameraHalf;

        smoothPos = Vector3.Lerp(this.transform.position,
            new Vector3(Mathf.Clamp(followTransform.position.x, leftBorder, rightBorder),
            this.transform.position.y,
            this.transform.position.z), smoothSpeed);

        this.transform.position = smoothPos;
    }
}
