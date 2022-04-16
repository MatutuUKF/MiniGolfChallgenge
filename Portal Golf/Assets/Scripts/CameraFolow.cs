using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    Camera mainCamera;
    public Transform ball;
    Vector3 offset;
    public float lerpRate;
    public float zoomOutMin = 10;
    public float zoomOutMax = 30;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
     
        offset = ball.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        setZoom();

         
    }

    void Follow()
    {
       
            Vector3 pos = transform.position;
        Vector3 targetPos = ball.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
        transform.LookAt(ball);
        }


    void setZoom() {

       
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        
       


    }
    void zoom(float increment)
    {
        Camera.main.orthographicSize =+ Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

}

   

