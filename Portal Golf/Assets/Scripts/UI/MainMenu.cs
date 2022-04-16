using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{


    public void chooseLevel(){

        string level = EventSystem.current.currentSelectedGameObject.name;
      
        GameManager.Instance.picked_level(level);
                
                
            

        }
    }

