using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{

    public abstract void UseSkill(SkillManager manager, Transform wisp, Transform lantern, int index);



    public abstract void UpdateManager(bool state, int index);



}
