using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
   
    public Image star1, star2, star3;

    private void Start()
    {
   
    }
    private void Update()
    {
        showStar();

    }
    private void showStar() {

        int[] rules = GameManager.max_hits;


        if (rules[0] < GameManager.hits) {

            star1.enabled = false;

        }  if (rules[1] < GameManager.hits){

            star2.enabled = false;

        }  if (rules[2] < GameManager.hits) {

            star3.enabled = false;

        }
        }


}
