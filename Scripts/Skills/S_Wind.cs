using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Wind : Skill
{
    public GameObject effector;
    private GameObject summon;
    private SkillManager manager;
    private Transform wisp;
    private Transform lantern;

    override public void UseSkill(SkillManager manager,Transform wisp,Transform lantern,int index)
    {
        this.wisp = wisp;
        this.lantern = lantern;
        this.manager = manager;
        summon = Instantiate(effector);
        summon.transform.position = (Vector2)Camera.main.transform.position;
        summon.transform.SetParent(Camera.main.transform);
        summon.transform.rotation = wisp.rotation;
        StartCoroutine(Wait(index));
    }

    private IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(5);
        Destroy(summon);
        UpdateManager(true, index);
    }

    override public void UpdateManager(bool state,int index)
    {
        manager.UpdateState(state, index);
    }

    
}
