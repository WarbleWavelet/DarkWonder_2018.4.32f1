using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed=10f;
    //技能
    public bool getSkill = false;
    public float timer = 0f;
    public float coolTime = 5f;
    public bool isCooled = false;//未习得技能，未冷却
    public GameObject skillPrefab;
    //
    public static Player _instance;
    //控制
    public GameObject trexGo;
    private void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Skill();
        ControlTrex();
     

    }

    private void Move()
    {
        //移动
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 offset = transform.position;
        transform.position += new Vector3(x * Time.deltaTime * speed, 0, z * Time.deltaTime * speed);
        //冷却
        if (timer < coolTime && isCooled == false)
        {
            timer += Time.deltaTime;
        }

        if (timer > coolTime && isCooled == false)
        {
            timer = 0;
            isCooled = true;
        }
    }
    void Skill()
    {
        //释放技能
        if (Input.GetButtonDown("Fire1"))
        {
            if (!getSkill)
            {
                print("未习得魔法");
            }
            else if (!isCooled)
            {
                print("技能冷却中");
            }
            else if (getSkill && isCooled)
            {
                print("大威天龙,世尊地藏,般若诸佛,般若巴嘛空！");

                Vector3 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
                Instantiate(skillPrefab, targetPos, Quaternion.identity);
                isCooled = false;
            }
        }
    }
    void ControlTrex()
    {
        //控制
        if (Trex._instance.isControl == true && Input.GetKeyDown(KeyCode.Q))
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);//关闭自身相机
            gameObject.SetActive(false);

            //Trex._instance.GetComponentInChildren<Camera>().gameObject.SetActive(true);//打开恐龙相机

            //开启恐龙相机
            trexGo.transform.Find("Camera").gameObject.SetActive(true);//transform只能找一级子节点
            trexGo.GetComponent<Trex>().isControl = true;

            //失效自己
            gameObject.SetActive(false);
        }
    }


}
