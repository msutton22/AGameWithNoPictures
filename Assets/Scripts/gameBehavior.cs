using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameBehavior : MonoBehaviour
{
    public float timer = 90f;
    public GameObject timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timer);

        if (timer <= 0)
        {
            SceneManager.LoadScene (3);
        }
    }
}
