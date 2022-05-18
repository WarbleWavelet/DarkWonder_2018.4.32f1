using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : MonoBehaviour
{

    public static Barrier _instance;
    public GameObject barrierGo;
    //public GameObject playerGo;
    //public GameObject trexGo;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

    }

    private void OnTriggerEnter(Collider other)//显示对话
    {
        if (other.tag == "Player")
        {
            UI_ES._instance.message.gameObject.SetActive(true);
            UI_ES._instance.message.GetComponent<Text>().text = "你太弱了，去找暴龙哥帮忙！";
        }
    }
    private void OnTriggerStay(Collider other)//显示对话
    {
        if (other.tag == "Trex")//被恐龙摧毁围栏，恐龙处于攻击状态
        {


            if (other.GetComponent<Trex>().isAttack == true)
            {
                Player._instance.gameObject.SetActive(true);//可以

                //playerGo是拖节点赋值的
                //playerGo.GetComponentInChildren<Camera>().gameObject.SetActive(true);//01失败
                //playerGo.transform.Find("Camera").gameObject.SetActive(true);//02成功
                //或者
                //Player._instance.GetComponentInChildren<Camera>().gameObject.SetActive(true);//03失败
                Player._instance.transform.Find("Camera").gameObject.SetActive(true);//04成功


                Player._instance.transform.position = Trex._instance.transform.position;//更新位置


                //恐龙
                //GameObject trexGo = this.trexGo;
                Trex._instance.gameObject.GetComponentInChildren<Camera>().gameObject.SetActive(false);//后关闭恐龙相机 ，不让会出现缺少相机                            
                Trex._instance.GetComponentInChildren<Trex>().isControl = false;


                print("围栏被破坏");
                Destroy(barrierGo.gameObject);//销毁围栏
                Destroy(this.gameObject);//销毁围栏对应的碰撞体，我分开放
            }
        }
    }
    private void OnTriggerExit(Collider other)//隐藏对话
    {
        if (other.tag == "Player" )
        {
            UI_ES._instance.message.gameObject.SetActive(false);
        }
    }
}
