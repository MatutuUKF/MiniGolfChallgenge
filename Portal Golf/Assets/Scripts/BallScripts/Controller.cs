using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{


    [SerializeField] int hit_power;
    [SerializeField] int rotate_speed;

    private Slider slider;
    private void Start()
    {
        slider = FindObjectOfType<Slider>().GetComponent<Slider>();
        hit_power = 30;
        rotate_speed = 100;
        start_position();
    }

    private void Update()
    {
        mouse_position();
        if (transform.position.y < -5) start_position();

    }


    /** ODSTREL LOPTICKY 
     * 
     * CONTROLER DOSTAVA SMER NATOCENIA LOPTY A SILU SLIDERU
     * 
     */

    public void start_position() {

        GetComponent<Rigidbody>().velocity = Vector3.zero;
       transform.position = Vector3.zero;
    
    }












    public void hit(float slider_power)
    {
        float ball_rotation = gameObject.transform.rotation.eulerAngles.y;

        Quaternion q = Quaternion.AngleAxis(ball_rotation, Vector3.up);
        Vector3 d = Vector3.forward;

        GetComponent<Rigidbody>().AddForce((((q * d) * slider_power * hit_power)), ForceMode.Impulse);

        slider.GetComponent<Slider>().value = 0;
        GameManager.hits++;
    }



    //OVLADANIE PRE EDITOR UNITY
    public void mouse_position()
    {
        var vec = gameObject.transform.rotation.eulerAngles;
        vec.y = vec.y + Input.GetAxis("Horizontal");
        gameObject.transform.rotation = Quaternion.Euler(vec);
    }
 
    //OVLADANIE PRE ANDROID
    public void finger_position()
    {
        if (PowerSlider.isTouched == false)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);


                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = rotationVector.y + touch.deltaPosition.x;
                transform.rotation = Quaternion.Euler(rotationVector);

            }
        }
    }
}
