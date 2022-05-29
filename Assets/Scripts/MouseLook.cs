using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitvityX = 8f;
    [SerializeField] private float sensitvityY = 0.5f;
    private float mouseX, mouseY;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float xClamp = 85f;
    private float xRotation = 0f;

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitvityX;
        mouseY = mouseInput.y * sensitvityY;
    }
}