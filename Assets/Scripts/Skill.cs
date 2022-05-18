using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    //伤害
    public float damage = 50f;
    public float timer=0f;
    public float damageTime=2f;//每隔几秒扣一次血
    public float skillLifeTime = 5f;//技能存在时间


    private void Start()
    {
        //StartCoroutine((IEnumerator)IEDestroyByTime( skillLifeTime ) );//出生就注定7秒后死掉
    }
    void Update()
    {
        //DestroySkill_01(); //销毁节点
        DestroySkill_02(); //销毁节点

    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            timer += Time.deltaTime;
            if (timer > damageTime)
            {
                timer = 0f;
                Troll troll = other.GetComponent<Troll>();
                troll.Hurted(damage);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Troll troll = other.GetComponent<Troll>();
            troll.GetComponent<Animator>().SetFloat("get_hit", 0f);
        }
    }
    //销毁节点
    void DestroySkill_01()
    {
        skillLifeTime -= Time.deltaTime;
        if (skillLifeTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
    void DestroySkill_02()
    {
        Destroy(this.gameObject, skillLifeTime);
    }
    //携程销毁节点
    IEnumerable IEDestroyByTime(float time)
    {
        yield return new WaitForSeconds(time);//开携程等n秒
        Destroy(this.gameObject);
    }
}
