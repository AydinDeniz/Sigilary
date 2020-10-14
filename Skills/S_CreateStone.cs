using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CreateStone : Skill
{
    [Header("Settings")]   public GameObject createStone;
    public float maxSize;
    public float growthRate;
    public float growthFrequency;
    private Transform wisp;
    private Transform lantern;
    private GameObject summon;
    private SkillManager manager;


    override public void UseSkill(SkillManager manager, Transform wisp, Transform lantern, int index)
    {
        if (summon != null)
        {
            Destroy(summon);
        }
        this.wisp = wisp;
        this.lantern = lantern;
        this.manager = manager;
        summon = Instantiate(createStone, wisp.position, wisp.rotation);
        StartCoroutine(BoulderSize());
        StartCoroutine(Wait(index));
    }

    private IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(5);
        UpdateManager(true, index);
    }

    private IEnumerator BoulderSize()
    {
        while(maxSize >= summon.transform.localScale.x)
        {
            summon.transform.localScale *= growthRate;
            yield return new WaitForSeconds(growthFrequency);
        }
    }

    override public void UpdateManager(bool state, int index)
    {
        manager.UpdateState(state, index);
    }
}
