using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainBehavior : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;

    public float timer = 2f;
    private GameObject popup;
    
    public GameObject popup1;
    public GameObject popup2;
    public GameObject popup3;
    public GameObject popup4;

    private GameObject text;
    private GameObject text2;
    private GameObject text3;
    private GameObject text4;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                text.SetActive(false);
            }
        }
        if (text2 != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                text2.SetActive(false);
            }
        }
        if (text3 != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                text3.SetActive(false);
            }
        }
        if (text4 != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                text4.SetActive(false);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.GetComponent<Transform>().Translate(new Vector3(0, 0.2f));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.GetComponent<Transform>().Translate(new Vector3(0, -0.2f));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.GetComponent<Transform>().Translate(new Vector3(0.2f, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.GetComponent<Transform>().Translate(new Vector3(-0.2f, 0));
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("key"))
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.tag.Equals("wall"))
        {
            timer = 2f;
            ChooseMusic();
            ChoosePopup();
        }

    }

    void ChooseMusic()
    {
        var randomMusic = Random.Range(0, 4);

        switch (randomMusic)
        {
            case 0:
                sound1.Play();
                break;
            case 1:
                sound2.Play();
                break;
            case 2:
                sound3.Play();
                break;
            case 3:
                sound4.Play();
                break;
        }

    }
    
    void ChoosePopup()
    {
        var randomPopup = Random.Range(0, 4);
        GameObject canvas = GameObject.Find("Canvas");

        switch (randomPopup)
        {
            case 0:
                text = Instantiate(popup1, new Vector3(300,200,0), Quaternion.identity);
                text.transform.SetParent(canvas.transform);
                break;
            case 1:
                text2 = Instantiate(popup2, new Vector3(900,200,0), Quaternion.identity);
                text2.transform.SetParent(canvas.transform);
                break;
            case 2:
                text3 = Instantiate(popup3, new Vector3(200,600,0), Quaternion.identity);
                text3.transform.SetParent(canvas.transform);
                break;
            case 3:
                text4 = Instantiate(popup4, new Vector3(700,600,0), Quaternion.identity);
                text4.transform.SetParent(canvas.transform);
                break;
        }

    }
}
