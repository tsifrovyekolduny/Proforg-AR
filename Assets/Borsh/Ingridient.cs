using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Ingridient : MonoBehaviour
{
    public int OrderNumber;
    public XRGrabInteractable Interactable;
    public float ReturningSpeed = 0.1f;
    private Vector3 _originPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _originPosition = transform.position;
        Interactable = GetComponent<XRGrabInteractable>();
    }

    public void BackToOrigin()
    {
        Debug.Log($"Moving {gameObject.name} to its origin");
        SetVisibility(true);
        StartCoroutine("ReturningToOrigin");
    }    

    void SetVisibility(bool isVisible)
    {
        GetComponentInChildren<MeshRenderer>().enabled = isVisible;
    }

    IEnumerator ReturningToOrigin()
    {        
        Interactable.enabled = false;
        while (transform.position != _originPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _originPosition, ReturningSpeed);

            yield return null;
        }
        Interactable.enabled = true;
    }

    public void GetConsumed()
    {
        SetVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
