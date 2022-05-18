using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour
{

    public float timer = 0f;
    public float idleTime = 1f;
    public float rotateTime = 2f;
    public float runTime = 3f;
    public float speed = 3f;
    private bool isIdle = true;
    private float targetY = 0f;

    private CharacterController characterController;

    private Animator animator;

    //伤害
    public float health = 100f;
    public bool isDead = false;
    public float deadTime = 2f;
    //技能存在时间

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("0"+Time.deltaTime);
        //print("1"+Time.fixedDeltaTime);
        if (!isDead)//防止死了来不及销毁节点之前，尸体还会拖行
        {
            AIMove();
        }
        else {//几秒后销毁节点
            deadTime -= Time.deltaTime;
            if (deadTime < 0f)
            {
                Destroy(this.gameObject);
            }

        }
       
    }
    void AIMove()
    {
        timer += Time.deltaTime;
        if (Mathf.Abs(targetY) > 0.2f)//太小不转
        {
            float rotateRate = 0.05f;//2f * Time.deltaTime;
            float deltaY = targetY * rotateRate;//
            transform.Rotate(new Vector3(0, deltaY, 0));
            targetY -= deltaY;
        }
        if (timer > idleTime + rotateTime)//walk
        {
            isIdle = false;
            //transform.position += transform.forward * Time.deltaTime * speed;
            characterController.Move(transform.forward * Time.deltaTime * speed);
        }
        if (timer > idleTime + rotateTime + runTime)//重置
        {
            targetY = Random.Range(-90f, 90f);
            isIdle = true;
            timer = 0f;
        }


        //调动画
        if (isIdle)
        {
            animatorToIdle();
        }
        if (!isIdle)
        {
            animatorToWalk();
        }
    }
    void animatorToIdle()
    {
        animator.SetFloat("idle", 1f);
        animator.SetFloat("walk", 0f);
        animator.SetFloat("run", 0f);
    }
    void animatorToWalk()
    {
        animator.SetFloat("idle", 0f);
        animator.SetFloat("walk", 1f);
        animator.SetFloat("run", 0f);
    }
    void animatorToDie()
    {
        animator.SetFloat("death", 1f);

        animator.SetFloat("idle", 0f);
        animator.SetFloat("walk", 0f);
        animator.SetFloat("run", 0f);

    }

    public void Hurted(float damage)//受伤或死亡
    {
        if (isDead==false && health > 0)
        {
            health = (health - damage) > 0 ? (health - damage) : 0f;
            animator.SetFloat("get_hit", 1f);
        }
        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()//死亡
    {
        isDead = true;
        animatorToDie();
        //计时销毁节点部分不知道方不方便在这部分做

        //肉
        Meat._instance.gameObject.SetActive(true);
        Meat._instance.count++;


    }
}
