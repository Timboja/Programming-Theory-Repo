using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Vector3 cameraWelcomePosition;
    private Vector3 currentPosition;

    private Vector3 topDownView;
    private Quaternion targetRotationTopDownView = Quaternion.identity;

    private Vector3 actionView;
    private Quaternion targetRotationActionView = Quaternion.identity;

    
    public bool isLerpingWelcome;
    public bool isLerpingSwitch;
    private float timer;

    public float CameraPanTimeWelcome;
    public float CameraPanTimeSwitch;

    public float turningRateWelcome;
    public float turningRateSwitch;

    public void CamWelcomeToTopView()
    {

        isLerpingWelcome = true;
        cameraWelcomePosition = transform.position;
        topDownView = new Vector3(-3.85F, 19.54F, -1.66F);
        targetRotationTopDownView = Quaternion.Euler(90, 0, 0);

    }

    public void CamSwitchView()
    {
        if (!isLerpingSwitch)
        {
            isLerpingSwitch = true;
            currentPosition = transform.position;
            actionView = new Vector3(-3F, 4, -14);
            targetRotationActionView = Quaternion.Euler(15.682F, -9.394F, 0);
        }
    }

    void FixedUpdate()
    {
        if (isLerpingWelcome)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(cameraWelcomePosition, topDownView, timer / CameraPanTimeWelcome);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationTopDownView, turningRateWelcome * Time.deltaTime);

            if (transform.position == topDownView)
            {
                timer = 0;
                isLerpingWelcome = false;
                //transform.rotation = Quaternion.Euler(90, 0, 0);
                //Debug.Log("Movement Stop");
            }
        }

        
        if (isLerpingSwitch && currentPosition == actionView)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(currentPosition, topDownView, timer / CameraPanTimeSwitch);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationTopDownView, turningRateSwitch * Time.deltaTime);

            if (transform.position == topDownView)
            {
                timer = 0;
                isLerpingSwitch = false;
                //Debug.Log("Movement Stop");
            }
        }
        
        
        if (isLerpingSwitch && currentPosition == topDownView)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(currentPosition, actionView, timer / CameraPanTimeSwitch);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationActionView, turningRateSwitch * Time.deltaTime);

            if (transform.position == actionView)
            {
                timer = 0;
                isLerpingSwitch = false;
                //Debug.Log("Movement Stop");
            }
        }
        
    }
}
