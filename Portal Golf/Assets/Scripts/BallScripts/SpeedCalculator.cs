using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCalculator : MonoBehaviour
{

    public GameObject ball;
    public Canvas canvas_controller;
 

   
    Vector3 prevPos;
    public float speed;





    private void Update()
    {
        
       if (speed != 0) disable_canvas(); else active_canvas();
    }

    
    void Start()
    {
        ball = GameObject.Find("Ball");

        start_count_speed();
    }

    void disable_canvas() => transform.parent.gameObject.GetComponentInParent<Canvas>().enabled = false;
    void active_canvas() => transform.parent.gameObject.GetComponentInParent<Canvas>().enabled = true;

    public void start_count_speed() =>  StartCoroutine(CalcSpeed());

    IEnumerator CalcSpeed()
    {


        while (true) {

             prevPos = ball.transform.position;

            yield return new WaitForFixedUpdate();

            speed = Mathf.RoundToInt(Vector3.Distance(ball.transform.position, prevPos) / Time.fixedDeltaTime);

            GetComponent<Text>().text = "Speed of Ball: " + speed;
          
        }


    }
}
