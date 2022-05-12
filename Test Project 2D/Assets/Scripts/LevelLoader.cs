using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static bool levelChange;

    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
              //other.name should equal the root of your Player object
              if (other.name == "Player") {
                  //The scene number to load (in File->Build Settings)
                  //SceneManager.LoadScene ("Level_2");
                  levelChange = true;
              }
              else {
                  levelChange = false;
              }
          }
    void OnDestroy()
    {
        if (levelChange == true)
        {
            levelChange = false;
        }
    }
}
