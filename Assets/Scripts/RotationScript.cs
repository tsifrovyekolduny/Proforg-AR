using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateOnTap : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private Quaternion targetRotation;

    private ARRaycastManager arRaycastManager;
    private Camera arCamera;

    private void Start()
    {
        targetRotation = transform.rotation;
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        arCamera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Обработка касаний
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = arCamera.ScreenPointToRay(touch.position);

            // Проверяем, попал ли луч в объект
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    RotateObject();
                }
            }
        }
    }

    public void RotateObject()
    {
        targetRotation *= Quaternion.Euler(0, 90, 0);
    }
}