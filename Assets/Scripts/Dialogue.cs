using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Sprite[] sprites;
    private  Sprite sprite;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Image>().sprite=sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            index++;
            if (index < 10)
            {
                GetComponentInChildren<Image>().sprite = sprites[index];
            }
            else
            {
                GetComponentInChildren<Image>().sprite = sprites[9];
                //Application.LoadLevel(1);
                SceneManager.LoadScene(1);
            }
        
        }
    }
}
