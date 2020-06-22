using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;


public class Ampel : MonoBehaviour
{
    public int vidas = 3;
    public Text vidasText; 

    public string currentTime; 

    timer current; 

    void Start()
    {
        //moveSpeed = 1f;
       if( vidasText == null) {
            vidasText = GameObject.Find( "VidasText" ).GetComponentInChildren<Text>();
            setVidas(); 
       }

    }

    // Update is called once per frame
    void Update()
    {

        // Get the current screen position of the mouse from Input

        Vector3 mousePos2D = Input.mousePosition;                             



        // The Camera's z position sets how far to push the mouse into 3D

        mousePos2D.z = -Camera.main.transform.position.z;                    



        // Convert the point from 2D screen space into 3D game world space

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);    



        // Move the x position of this Ampelmann to the x position of the Mouse

        Vector3 pos = this.transform.position;

        pos.x = mousePos3D.x;

        this.transform.position = pos;

        //transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime); 

    }

    void OnCollisionEnter(Collision coll)
    {                         

        // Find out what hit this basket

        GameObject collidedWith = coll.gameObject;                    

        if (collidedWith.tag == "Bomb")
        {                          
            Destroy(collidedWith);
            vidas -= 1;
            if(vidas == 0){
                SceneManager.LoadScene("Game Over"); 
            }
            setVidas(); 

        }

    }

    void setVidas(){
        vidasText.text = "Vidas: " + vidas.ToString(); 
    }
}
