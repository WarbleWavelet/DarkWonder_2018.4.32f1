using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meat : MonoBehaviour
{
    public int count = 0;
    public int maxCount = 5;
    public static Meat _instance;

    private Text meatText;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        _instance.gameObject.SetActive(false);

        meatText = transform.Find("MeatCount").GetComponent<Text>();//找子节点，FindChile过时
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {          
            meatText.text = count+ "/"+maxCount ;
        }
        
        if (count > maxCount)
        {
            count = maxCount;
        }
    }
}
