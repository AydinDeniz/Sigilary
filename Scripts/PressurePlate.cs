using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [Header("Settings")]
    public TriggerAble target;
    public string[] layerNames;
    public float delay=0;

    private bool plateState = false;
    private int onPlateNumber = 0;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        foreach (string layerName in layerNames)
        {
            if (coll.gameObject.layer == LayerMask.NameToLayer(layerName))
            {
                plateState = true;
                StartCoroutine(Wait());
                onPlateNumber++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        foreach (string layerName in layerNames)
        {
            if (coll.gameObject.layer == LayerMask.NameToLayer(layerName))
            {
                onPlateNumber--;
                if (onPlateNumber == 0)
                {
                    plateState = false;
                }
                StartCoroutine(Wait());
                
                
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay);
        if (plateState == false)
        {
            target.UnTrigger();
        }
        else
        {
            target.Trigger();
        }
    }
}
