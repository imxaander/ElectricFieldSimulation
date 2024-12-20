using UnityEngine;

public class ConductivePaper : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject electricFields;
    public GameObject electricFieldPrefab;
    public float fieldInterval = 0.2f;
    public float length = 5;
    public float width = 2;
    public Transform boundary1; //lower
    public Transform boundary2;

    bool enabledField = false;
    void Start()
    {
        // spawn electric field lines at start

        SpawnElectricFieldLines();
        ToggleElectricField();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleElectricField();
        }
    }
    void ToggleElectricField()
    {
        if (enabledField)
        {
            electricFields.SetActive(false);
            enabledField = false;
        }
        else
        {
            electricFields.SetActive(true);
            enabledField = true;
        }

    }

    void SpawnElectricFieldLines(){
        for(float i = 0; i < length * 2.65; i+= 0.05f){
            for(float j = 0; j < width * 2; j+= 0.05f){

                float z = electricFields.transform.position.z + i * fieldInterval;
                float x = electricFields.transform.position.x + j * fieldInterval;
                if (x > boundary1.position.x && x < boundary2.position.x && z < boundary1.position.z && z > boundary2.position.z)
                {
                     Instantiate(electricFieldPrefab, new Vector3(x, electricFields.transform.position.y, z), Quaternion.identity, electricFields.transform);
                }

            }
        }
    }

    void ClearElectricFieldLines(){

    }
}
