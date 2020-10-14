using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_IceCone : Skill
{
    [Header("Settings")]
    public GameObject iceCone;
    public float moveSpeed;
    public float maxSize;
    public float growthRate;
    public float growthFrequency;
    private Transform wisp;
    private Transform lantern;
    private GameObject summon;
    private SkillManager manager;


    override public void UseSkill(SkillManager manager, Transform wisp, Transform lantern, int index)
    {
        print("IceConedebug");
        this.wisp = wisp;
        this.lantern = lantern;
        this.manager = manager;
        summon = Instantiate(iceCone, wisp.position, wisp.rotation);
        StartCoroutine(Conification());
        StartCoroutine(Wait(index));
    }

    private IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(5);
        UpdateManager(true, index);
    }

    private IEnumerator Conification()
    {
        while (maxSize >= summon.transform.localScale.y)
        {
            summon.transform.localScale *= growthRate;
            summon.transform.position += summon.transform.right * moveSpeed;
            yield return new WaitForSeconds(growthFrequency);
        }
    }

    override public void UpdateManager(bool state, int index)
    {
        manager.UpdateState(state, index);
    }
}