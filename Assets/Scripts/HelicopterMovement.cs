using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public AudioClip soldierPickup;
    //initialise variables
    private const float speed = 5f;
    private float maxCapacity = 3f;
    public static float  currentCapacity = 0f;
    public static float soldiersRescued = 0f;

    public static GameObject[] soldiers;
    

    public Win Win;
    public GameOver GameOver;

    // Start is called before the first frame update
    void Start()
    {
        soldiersRescued = 0f;
        currentCapacity = 0f;
        Time.timeScale = 1f;
        soldiers = GameObject.FindGameObjectsWithTag("Soldier");

    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if(soldiers.Length == soldiersRescued){

            WinGame();
         
        }
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        


    }
    public void LoseGame(){
        Time.timeScale = 0f;
        GameOver.Setup();
        
    }
    public void WinGame(){
        Time.timeScale = 0f;
        Win.Setup();
    }
    
    private void movement(){
        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKey(KeyCode.W)){
            moveY = +1f;
        }
        if(Input.GetKey(KeyCode.S)){
            moveY = -1f;
        }
        if(Input.GetKey(KeyCode.A)){
            moveX  = -1f;
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
        if(Input.GetKey(KeyCode.D)){
            moveX  = +1f;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        Vector3 moveDirection = new Vector3(moveX, moveY).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.tag == "Soldier") {
            if(currentCapacity < maxCapacity){
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                Destroy(collision.gameObject);
                currentCapacity+=1;
            }
        }

        
        if(collision.gameObject.tag == "Hospital"){
            soldiersRescued += currentCapacity;
            currentCapacity = 0;
            Debug.Log("Rescued soldiers: " + soldiersRescued.ToString());
        }

        if(collision.gameObject.tag == "Tree"){
            LoseGame();
        }       
    }

    public float getRescued(){
        return soldiersRescued;
    }
    public float getCurrentCapacity(){
        return currentCapacity;
    }
    public float getAllSoldiers(){
        return soldiers.Length;
    }


}


