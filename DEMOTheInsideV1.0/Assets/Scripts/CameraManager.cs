using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //variables
    public float mouseSensitivity = 100;
    public Transform playerBody;
    private float xRotation = 0;
    [SerializeField] private bool CamBlock = false; // bool para checar si esta bloqueada
    [SerializeField] private CharacterInput CI; //referencia al CharacterInput
    public Transform FP; // El punto al que deseas enfocar

    private void Start()
    {
        CamBlock = CI.Focus;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CamBlock = CI.Focus;
        if (CamBlock == false)
        {
            // Solo procesa la entrada del mouse si la cámara no está bloqueada
            HandleMouseInput();
        }
        else 
        {
            StartCoroutine(BlockCameraCoroutine());
        }
    }

    private void HandleMouseInput()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private IEnumerator BlockCameraCoroutine()
    {
        Vector3 originalEulerAngles = transform.localEulerAngles;
        Quaternion TR = Quaternion.LookRotation(FP.position - transform.position);

        float elapsedTime = 0;

        while (elapsedTime < 0.5f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, TR, Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
