using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ElementManager : MonoBehaviour
{
    public string element;

    private bool isChanging = false;

    private float changeCounter = 0,horizontal, vertical;

    public float changeDelay;

    public GameObject Wheel;

    public Image[] ElementImages;

    public UnityEvent<bool> CooldownOn;

    public UnityEvent<bool> CooldownOff;

    void Start()
    {
        element = "fire";
        changeCounter = 0;
    }

    void Update()
    {
        ChangeDelay();

        ChangeElement();
    }

    public void UpdateArrowsWheel(float verticalValue, float horizontalValue)
    {

        horizontal = horizontalValue;
        vertical = verticalValue;

    }

    public void ChangeElement()
    {
        //if ((vertical == 1) && (horizontal == 0))
        //{
        //    MakeAllElementsWhite();
        //    ElementImages[1].color = Color.red;
        //    element = "fire";
        //}

        //if ((vertical == 1) && (horizontal == 1))
        //{
        //    MakeAllElementsWhite();
        //    ElementImages[2].color = Color.red;
        //    element = "fire";
        //}
        //if ((vertical == -1) && (horizontal == 1))
        //{
        //    MakeAllElementsWhite();
        //    ElementImages[3].color = Color.red;
        //    element = "ice";
        //}
        //if ((vertical == -1) && (horizontal == 0))
        //{
        //    MakeAllElementsWhite();
        //    ElementImages[4].color = Color.red;
        //    element = "ice";
        //}
        //if ((vertical == -1) && (horizontal == -1))
        //{
        //    MakeAllElementsWhite();
        //    ElementImages[5].color = Color.red;
        //    element = "ice";
        //}
        //if ((vertical == 1) && (horizontal == -1))
        //{
        //    MakeAllElementsWhite();
        //    ElementImages[6].color = Color.red;
        //    element = "fire";
        //}

    }

    void MakeAllElementsWhite()
    {
        foreach(Image elementImage in ElementImages)
        {
            if (elementImage != ElementImages[0])
            {
                elementImage.color = Color.white;
            }
        }
    }

    public void ActivateWheel()
    {
        //Wheel.SetActive(true);

        //ElementImages = Wheel.GetComponentsInChildren<Image>();

        CooldownOn.Invoke(true);

        if (isChanging == false)
        {
            isChanging = true;

            if (element == "fire")
            {
                element = "ice";
                return;
            }

            if (element == "ice")
            {
                element = "fire";
                return;
            }
        }
    }

    public void EndChange()
    {
        //MakeAllElementsWhite();
        //Wheel.SetActive(false);
        //isChanging = true;
        CooldownOn.Invoke(true);
    }

    void ChangeDelay()
    {
        if (isChanging)
        {
            changeCounter += Time.deltaTime;

            if (changeCounter >= changeDelay)
            {
                changeCounter = 0;
                isChanging = false;
                CooldownOff.Invoke(false);

            }
        }
    }
}
