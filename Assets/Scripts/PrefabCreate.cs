using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PrefabCreate : MonoBehaviour
{
    public Button thisButton;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        thisButton.onClick.AddListener(CreatePrefab);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void CreatePrefab()
    {
        Instantiate(prefab);
    }
}
