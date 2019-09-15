using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainBehavior : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.UpArrow)) {
            this.GetComponent<Transform> ().Translate (new Vector3 (0, 0.2f));		
        }
        if (Input.GetKeyDown (KeyCode.DownArrow)) {
            this.GetComponent<Transform> ().Translate (new Vector3 (0, -0.2f));	
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.GetComponent<Transform> ().Translate (new Vector3 (0.2f, 0)); 
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.GetComponent<Transform> ().Translate (new Vector3 (-0.2f, 0));
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag.Equals ("key")) 
        {
            SceneManager.LoadScene (1);
        }
        
    }
    
}
