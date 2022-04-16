using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour,IPointerUpHandler,IBeginDragHandler,IEndDragHandler
{

    public static bool isTouched { get; set; }
    public GameObject ball;



     void Start() {

        ball = GameObject.FindWithTag("Ball");
        isTouched = false;
      
    }


    /*
     ********************************EVENTY*********************************************
     */

    // VOLA CONTROLER LOPTY ABY JU ODPALIL
    public void OnPointerUp(PointerEventData eventData) { ball.GetComponent<Controller>().hit(GetSliderValue()); }


    // VRACIA SILU ODPALU ZO SLIDERU
    public float GetSliderValue() { return gameObject.GetComponent<Slider>().value; }
  


    // Ošetrenie pohybu kamery zároveò s použitim powerslideru (Pokial pouziva hrac slider camera sa nehybe)
    public void OnBeginDrag(PointerEventData eventData) => isTouched = true; 

    public void OnEndDrag(PointerEventData eventData) => isTouched = false; 
}
