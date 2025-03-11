using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BorshPlate : MonoBehaviour
{
    [SerializeField]
    private List<int> _orderNumbers = new List<int>();
    [SerializeField]
    private Ingridient[] _ingridients;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AllBackToOrigin()
    {         
        foreach (var ingr in _ingridients) { 
            ingr.BackToOrigin();
        }
    }

    void AddToOrderNumbers(int order)
    {        
        if (order != _orderNumbers.Count + 1)
        {
            Debug.Log("Wrong order");
            _orderNumbers.Clear();
            AllBackToOrigin();
            return;
        }

        _orderNumbers.Add(order);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.transform.parent.name} collided");
        Ingridient ingridient = other.gameObject.GetComponentInParent<Ingridient>();
        if (ingridient != null)
        {
            ingridient.GetConsumed();
            AddToOrderNumbers(ingridient.OrderNumber);
        }
    }
}
