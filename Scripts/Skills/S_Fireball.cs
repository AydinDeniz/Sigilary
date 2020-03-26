using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Fireball : Skill
{
    public GameObject fireball;
    public float force;
    private Transform wisp;
    private Transform lantern;
    private GameObject summon;
    private SkillManager manager;

    override public void UseSkill(SkillManager manager,Transform wisp, Transform lantern, int index)
    {
        print("lanternsa");
        this.wisp = wisp;
        this.lantern = lantern;
        this.manager = manager;
        summon = Instantiate(fireball, wisp.position, wisp.rotation);
        summon.GetComponent<Rigidbody2D>().AddForce(summon.transform.right * force, ForceMode2D.Impulse);
        //summon.transform.position = (Vector2)Camera.main.transform.position;
        //summon.transform.SetParent(Camera.main.transform);
        StartCoroutine(Wait(index));
    }

    private IEnumerator Wait(int index)
    {
        yield return new WaitForSeconds(5);
        UpdateManager(true, index);
    }

    override public void UpdateManager(bool state, int index)
    {
        manager.UpdateState(state, index);
    }
}