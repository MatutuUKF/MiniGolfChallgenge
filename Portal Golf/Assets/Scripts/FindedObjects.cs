using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindedObjects : MonoBehaviour
{

     public static GameObject  ball,slider,pivot,canvas;
  
   
    public static void find_objects()
    {

       
            pivot = GameObject.Find("Pivot").gameObject;
            ball = GameObject.Find("Ball").gameObject;
            slider = GameObject.Find("PowerSlider").gameObject;
            canvas = GameObject.Find("GameControllerCanvas");
            
        
       

    }
}
