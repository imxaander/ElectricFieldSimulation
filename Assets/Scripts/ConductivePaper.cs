using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductivePaper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject electricFields;
    public GameObject electricFieldPrefab;
    public float fieldInterval = 0.5f;
    public float length = 5;
    public float width = 2;
    void Start()
    {
        // spawn electric field lines at start
        SpawnElectricFieldLines();
    }

    void Update()
    {
        
    }

    void SpawnElectricFieldLines(){
        for(float i = 0; i < length * 2.65; i++){
            for(float j = 0; j < width * 2; j++){
                Instantiate(electricFieldPrefab, new Vector3(electricFields.transform.position.x + j*fieldInterval, electricFields.transform.position.y, electricFields.transform.position.z + i*fieldInterval), Quaternion.identity, electricFields.transform);
            }
        }
    }

    void ClearElectricFieldLines(){

    }
}
