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


    public float turningRate;

    public void Start()
    {

        topDownView = new Vector3(-3.85F, 19.54F, -1.66F);
        targetRotationTopDownView = Quaternion.Euler(90, 0, 0);

        actionView = new Vector3(-3F, 4, -14);
        targetRotationActionView = Quaternion.Euler(15.682F, -9.394F, 0);

    }

    public void CamWelcomeToTopView()
    {

        isLerpingWelcome = true;
        cameraWelcomePosition = transform.position;
        topDownView = new Vector3(-3.85F, 19.54F, -1.66F);
        targetRotationTopDownView = Quaternion.Euler(90, 0, 0);

    }

    public void CamSwitchView()
    {

        isLerpingSwitch = true;
        currentPosition = transform.position;

    }

    void FixedUpdate()
    {
        if (isLerpingWelcome)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(cameraWelcomePosition, topDownView, timer / CameraPanTimeWelcome);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationTopDownView, turningRate * Time.deltaTime);

            Debug.Log("Lerp Welcome");

            if (transform.position == topDownView)
            {
                isLerpingWelcome = false;
                Debug.Log("Movement Stop");
            }
        }

        /*
        if (isLerpingSwitch)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(currentPosition, topDownView, timer / CameraPanTimeSwitch);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationTopDownView, turningRate * Time.deltaTime);

            Debug.Log("Lerp to topdown");

            if (transform.position == topDownView)
            {
                isLerpingSwitch = false;
                Debug.Log("Movement Stop");
            }
        }
        */
        
        if (isLerpingSwitch && transform.position == topDownView)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(currentPosition, actionView, timer / CameraPanTimeSwitch);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotationActionView, turningRate * Time.deltaTime);

            Debug.Log("Lerp to action view");

            if (transform.position == actionView)
            {
                isLerpingSwitch = false;
                Debug.Log("Movement Stop");
            }
        }
        
    }
}
