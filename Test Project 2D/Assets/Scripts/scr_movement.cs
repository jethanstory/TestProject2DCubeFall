using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public bool changeLevel;

    

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public LayerMask platform;
    
    void Start()
    {
        Debug.Log("HOW");
    }

    // Update is called once per frame
    void Update()
    {
        //OnBecameInvisible();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        //Debug.Log("Help");
         

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * 8f; //5f
        }

        if (IsSidewaysRight() || IsSidewaysLeft())
        {
            transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f, 0f);
        }
        changeLevel = LevelLoader.levelChange;
        
    }
    bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, platform);
        return ray.collider != null;
    }

    bool IsSidewaysRight()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.right, 0.1f, platform);
        return ray.collider != null;
    }
    bool IsSidewaysLeft()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.left, 0.1f, platform);
        return ray.collider != null;
    }
    
    void OnTriggerEnter2D(Collider2D other){
              //other.name should equal the root of your Player object
              if (other.name == "LevelEnd") {
                  //The scene number to load (in File->Build Settings)
                  //SceneManager.LoadScene ("Level_2");
                  changeLevel = true;
              }
          }
    void OnBecameInvisible() {
        //Destroy(PlayerGameObject);
        //Application.Quit();

        if (changeLevel == false) {
            SceneManager.LoadScene("GameOver");
            Debug.Log("He's done ya again");
        }
        else {
            SceneManager.LoadScene ("YouWon");
        }

    }
    
}
