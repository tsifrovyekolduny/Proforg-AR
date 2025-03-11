using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.ARStarterAssets;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class SpawnConstraint : MonoBehaviour
{
    [SerializeField]
    private ARInteractorSpawnTrigger _aRContactSpawnTrigger;
    [SerializeField]
    private ObjectSpawner _objectSpawner;
    private bool _isSpawned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 1 && _isSpawned == false)
        {
            Debug.Log("Init spawn");
            _isSpawned = true;
            _aRContactSpawnTrigger.enabled = false;
            _objectSpawner.enabled = false;
        }
        
    }
}
