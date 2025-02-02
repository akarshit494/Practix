﻿using UnityEngine;
using System.Collections;

public class MainRodComponent : MonoBehaviour
{
    public GameObject requiredPoseObject;

    public GameObject m_brokenRodPart;

    float timeDuration = 1.5f;

    void Start()
    {
        // BreakRod();
    }

    // Steps for the end section of the componenet
    public void AtEnd()
    {
        MoveToPosition();
        Invoke("CallForEndOfStep", timeDuration);
    }


    void MoveToPosition()
    {
        LeanTween.move(gameObject, requiredPoseObject.transform.position, timeDuration)
          .setEaseInCirc();
    }

    void CallForEndOfStep()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        GameEvents.instance.Step1Complete();
    }


    // step 5 funtions
    public void BreakRod(float waitTime = 0)
    {
        StartCoroutine(RemoveOutline(waitTime));
    }

    IEnumerator RemoveOutline(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        m_brokenRodPart.GetComponent<Outline>().enabled = false;
        m_brokenRodPart.SetActive(false);
    }

   

}
