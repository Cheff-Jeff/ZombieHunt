using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraScreenRatio : MonoBehaviour
{
    // Start is called before the first frame update
    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    public float horizontalFoV = 90.0f;

    void Update()
    {
        float halfWidth = Mathf.Tan(0.5f * horizontalFoV * Mathf.Deg2Rad);

        float halfHeight = halfWidth * Screen.height / Screen.width;

        float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

        _camera.fieldOfView = verticalFoV;
    }
}
