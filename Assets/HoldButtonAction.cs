using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButtonAction : MonoBehaviour
{
    private bool isLeftHolding = false;
    private bool isRightHolding = false;


    // Update is called once per frame
    void Update()
    {
        if (isLeftHolding)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().PlayerUp();
        }
        if (isRightHolding)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().PlayerDown();
        }
    }

    public void LeftUpButton()
    {
        isLeftHolding = false;
    }

    public void LeftDownButton()
    {
        isLeftHolding = true;
    }

    public void RightUpButton()
    {
        isRightHolding = false;
    }

    public void RightDownButton()
    {
        isRightHolding = true;
    }
}
