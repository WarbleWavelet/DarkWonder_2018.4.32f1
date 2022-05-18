using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ES : MonoBehaviour
{
    public static UI_ES _instance;
    public GameObject message;
    public GameObject skill;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        message.SetActive(false);
        skill.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
