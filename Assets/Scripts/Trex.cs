using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trex : MonoBehaviour
{

    private CharacterController characterController;//为了Move
    public float speed = 10f;//移动速度
    //加上动画
    private new Animation animation;
    //攻击
    public bool isAttack = false;

    public static Trex _instance;
    //控制
    public bool isControl = false;
    //
    public bool getMeat = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animation =GetComponentInChildren<Animation>();

        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControl)
        {
            Move();
            Attack();
        }


    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        characterController.Move(transform.forward * y * speed * Time.deltaTime);//移动
        transform.Rotate(new Vector3(0, x * 30 * Time.deltaTime, 0));//旋转
        if (Mathf.Abs(y) > 0.1f)//移动太小不动画
        {
            animation.CrossFade("walk_loop");
        }
        else
        {
            animation.CrossFade("idle");
        }
    }

    void Attack()
    {
        if (Input.GetButton("Fire1"))
        {
            print("attack");
            isAttack = true;
            animation.CrossFade("Snap");
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isAttack = false;
        }
    }

    //void Dialogue()
    //{

    //    UI_ES._instance.message.GetComponent<Text>().text = "老铁，快给我吧！";
    //    OnGUI();

    //}
    //private void OnGUI()
    //{
    //    bool haveChose = false;
    //    float width = 240f;
    //    float height = 80f;
    //    float y = (Screen.height - height) / 2;
    //    float x = (Screen.width - width) / 2;

    //    GUI.Label(new Rect(x, y+height, width*4, height), "是否把巨怪的肉给暴龙");
    //    if (GUI.Button(new Rect(x-width, y, width, height), "给予"))
    //    {
    //        getMeat = true;
    //        haveChose = true;
    //    }
    //    if (GUI.Button(new Rect(x+width, y, width, height), "不给"))
    //    {
    //        getMeat = false;
    //        haveChose = true;
    //    }

    //    if (haveChose)
    //    {
    //        GUI.enabled = false;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            UI_ES._instance.message.gameObject.SetActive(true);
            if (Meat._instance.count ==0)
            {
                UI_ES._instance.message.GetComponent<Text>().text =" Give me meat meat,\n job will'be did did!";
            }
            if (Meat._instance.count > 0 && Meat._instance.count < Meat._instance.maxCount)
            {
                UI_ES._instance.message.GetComponent<Text>().text = "那山神是我的至亲啊，得加钱！";
            }
            if (Meat._instance.count == Meat._instance.maxCount)
            {
                UI_ES._instance.message.GetComponent<Text>().text = "按Q键。Drive me,骑我！";
                isControl = true;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI_ES._instance.message.gameObject.SetActive(false);
            GUI.enabled = false;
        }
    }
}
