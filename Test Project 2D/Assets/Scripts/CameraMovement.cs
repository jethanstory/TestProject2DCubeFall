using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject PlayerGameObject;
    //public Player player;
    public Camera camera1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        OnBecameInvisible();
        float step = 1;

        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.y += -step / 130;
        Camera.main.gameObject.transform.position = cameraPosition;

        if (Camera.main.gameObject.transform.position.y < PlayerGameObject.transform.position.y)
        {
            Application.Quit();
        }
    }
    void OnBecameInvisible() {
        //Destroy(PlayerGameObject);
        Application.Quit();
    }

}
