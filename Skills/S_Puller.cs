using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Puller : Skill
{
    [Header("Settings")]
    public GameObject puller;
    public float radius;
    public float force;
    private Transform wisp;
    private Transform lantern;
    private GameObject summon;
    private SkillManager manager;


    override public void UseSkill(SkillManager manager, Transform wisp, Transform lantern, int index)
    {
        print("Puller");
        this.wisp = wisp;
        this.lantern = lantern;
        this.manager = manager;
        summon = Instantiate(puller);
        summon.transform.position = wisp.position;
        summon.transform.parent = wisp;
        puller.GetComponent<PointEffector2D>().forceMagnitude = force;
        puller.GetComponent<CircleCollider2D>().radius = radius;
        StartCoroutine(Wait(index));
    }

    private IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(4);
        Destroy(summon);
        yield return new WaitForSeconds(1);
        UpdateManager(true, index);
    }


    override public void UpdateManager(bool state, int index)
    {
        manager.UpdateState(state, index);
    }
}
