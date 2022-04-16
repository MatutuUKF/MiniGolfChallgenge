using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;



public class GameManager : Singleton<GameManager>
{
    private static int current_scene = 0;
    [SerializeField]private static int global_score = 0;
    public static int hits = 0;
       
    
    public static int [] max_hits = new int [3];

   

    /*
     * LOPTA SPADLA DO JAMKY A PREPINA SA LEVEL
     */

    public void nextLevel() =>  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

      
 
    


     void loadsetting(int[] maxhits, int scene) {

        hits = 0;
        max_hits = maxhits;
        SceneManager.LoadScene(scene);
    }

    private void resetSettings()
    {

        hits = 0;
        for (int i = 0; i < max_hits.Length; ++i) {
            max_hits[i] = 0; }
            

    }


    /*
     * METODA KONTROLUJE CI BOLA SCENA ZMENENA AK ANO ZNOVU V METODE START VYHLADA OBJEKTY
     */

    public bool scene_Was_Changed()
    {

        if (SceneManager.GetActiveScene().buildIndex != current_scene)
        {
            current_scene = SceneManager.GetActiveScene().buildIndex;
            return true;

        }
        else return false;

    }

    public void picked_level(string level) {

        Debug.Log(level);
        switch (level) {
            case "level1": loadsetting( new int[] {3, 4, 5 },2); break;
            case "level2": loadsetting(new int[] { 3, 4, 5 }, 3); break;
            case "level3": loadsetting(new int[] { 3, 4, 5 }, 4); break;

        }

    }

   
    }




