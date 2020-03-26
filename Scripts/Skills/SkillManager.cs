using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{


    private bool[] skill_available;

    [Header("Settings")]
    public bool LeftClick;
    private int click;
    public Skill[] skills;

    [Header("Transforms")]
    public Transform wisp;
    public Transform lantern;

    private void Start()
    {
        skill_available = new bool[skills.Length];
        for (int i = 0; i < skill_available.Length; i++)
        {
                skill_available[i] = true;
        }
        if (LeftClick == true)
        {
            click = 0;
        }
        else
        {
            click = 1;
        }
    }

    public void UpdateState(bool state, int index)
    {
        skill_available[index] = state;
    }



    private void Update()
    {
        if (Input.GetMouseButton(click))
        {
            if (Input.GetKeyDown("1"))
            {
                if (skills.Length>0)
                {
                    TriggerSkill(0);
                    skill_available[0] = false;
                }
            }
            else if (Input.GetKeyDown("2"))
            {
                if (skills.Length > 1)
                {
                    TriggerSkill(1);
                    skill_available[1] = false;
                }
            }
            else if (Input.GetKeyDown("3"))
            {
                if (skills.Length > 2)
                {
                    TriggerSkill(2);
                    skill_available[2] = false;
                }
            }
            else if (Input.GetKeyDown("4"))
            {
                if (skills.Length > 3)
                {
                    TriggerSkill(3);
                    skill_available[3] = false;
                }
            }
            else if (Input.GetKeyDown("5"))
            {
                if (skills.Length > 4)
                {
                    TriggerSkill(4);
                    skill_available[4] = false;
                }
            }
            else if (Input.GetKeyDown("6"))
            {
                if (skills.Length > 5)
                {
                    TriggerSkill(6);
                    skill_available[5] = false;
                }
            }
            else if (Input.GetKeyDown("q"))
            {
                if (skills.Length > 6)
                {
                    TriggerSkill(6);
                    skill_available[6] = false;
                }
            }
            else if (Input.GetKeyDown("e"))
            {
                if (skills.Length > 7)
                {
                    TriggerSkill(7);
                    skill_available[7] = false;
                }
            }
        }
    }

    public void TriggerSkill(int index)
    {
        if (skill_available[index] == true)
        {
            skills[index].UseSkill(this, wisp,lantern, index);
        }
    }
}
