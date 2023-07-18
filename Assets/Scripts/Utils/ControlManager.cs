using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlManager : MonoBehaviour
{
    public UnityEvent<float, float> updateArrows, updateArrowsWheel;
    public UnityEvent jumpEvent, endJumpEvent, shootEvent, elementChangeEvent, endElementChangeEvent;
    private float horizontal, vertical;
    private bool isWheelActive = false;
    public bool isWheelDelayOver;

    // Update is called once per frame
    void Start()
    {
        isWheelDelayOver = true;
    }
    void Update()
    {
        if (isWheelActive == false)
        {
            VerifyArrows();
            VerifyJump();
            VerifyShoot();
        }
        else
        {
            VerifyArrowsWheel();
        }

        if (isWheelDelayOver)
        {
            VerifyChange();
        }
    }

    public void ChangeWheelDelayValue(bool value)
    {

        isWheelDelayOver = value;

    }

    private void VerifyArrows()
    {

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        updateArrows.Invoke(vertical, horizontal);

    }

    private void VerifyArrowsWheel()
    {

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        updateArrowsWheel.Invoke(vertical, horizontal);

    }

    private void VerifyJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpEvent.Invoke();
        }

        if (Input.GetButtonUp("Jump"))
        {
            endJumpEvent.Invoke();
        }
    }

    private void VerifyShoot()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            shootEvent.Invoke();
        }

    }

    private void VerifyChange()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            //isWheelActive = true;
            elementChangeEvent.Invoke();
            updateArrows.Invoke(0, 0);
        }

        //if (Input.GetKeyUp(KeyCode.K))
        //{
        //    isWheelActive = false;
        //    endElementChangeEvent.Invoke();
        //}
    }

}
