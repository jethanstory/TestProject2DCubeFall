using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAspect : MonoBehaviour
{
    //float currentTime = 0f;
    //float startingTime = 3f;
    [SerializeField] Text CountdownText;

    // Start is called before the first frame update
    void Start()
    {
        //currentTime = startingTime;
        StartCoroutine ("startRoutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator startRoutine (){
        Time.timeScale = 0;

        float pauseTime = Time.realtimeSinceStartup + 3f;


        //currentTime -= 1 * Time.deltaTime;
        //CountdownText.text = currentTime.ToString ("0");
        CountdownText.text = pauseTime.ToString ("0");
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;

        //if (currentTime <= 0)
        //{
            Time.timeScale = 1;
            
        //}

    }
    
}

