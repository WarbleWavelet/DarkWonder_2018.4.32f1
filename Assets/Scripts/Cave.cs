using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cave : MonoBehaviour
{
    public float practice_preTime = 3f;//待3秒开始修行
    public float practice_duringTime = 9f;//修行需要持续9s
    public float timer = 0f;
    public bool isPracticed = false;


    private void Start()
    {

    }

    void OnTriggerStay(Collider other)
    {
        UI_ES._instance.message.SetActive(true);
        UI_ES._instance.message.GetComponent<Text>().text = "你已经进入修炼法阵中！";
        print("进入修炼法阵");

        if (!isPracticed)
        {
            //float resPreTime = Mathf.FloorToInt(practice_preTime - timer);
            string resPreTime = (practice_preTime - timer).ToString("0.00");
            UI_ES._instance.message.GetComponent<Text>().text += "\n准备修炼剩余时间：" + resPreTime + "秒";

            if (other.tag == "Player")
            {
                timer += Time.deltaTime;
                if (timer > practice_preTime)
                {
                    print("开始修炼");
                    UI_ES._instance.message.GetComponent<Text>().text = "正在修炼中......";
                    timer += Time.deltaTime;

                    float resDuringTime = Mathf.FloorToInt(practice_duringTime - timer);
                    UI_ES._instance.message.GetComponent<Text>().text += "\n距离出关剩余时间：" + resDuringTime + "秒";

                    if (timer > practice_duringTime)
                    {
                        UI_ES._instance.message.GetComponent<Text>().text = "修炼成功！";
                        UI_ES._instance.skill.SetActive(true);
                        print("完成修炼");
                        isPracticed = true;

                        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getSkill = true;

                        //TODO:N秒后false文本
                    }
                }
            }
        }
        if (isPracticed)
        {
            UI_ES._instance.message.GetComponent<Text>().text = "你已经修炼完成，不需再进入修炼法阵中！";
        }



    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            timer = 0f;
            print("终止修炼");
            UI_ES._instance.message.SetActive(false);
            if (!isPracticed)
            {
                UI_ES._instance.message.SetActive(true);
                UI_ES._instance.message.GetComponent<Text>().text = "离开修炼法阵，未完成修炼，终止修炼！";
                //TODO:N秒后false文本
            }
        }     
    }


}

