using Unity.VisualScripting;
using UnityEngine;

public class ElectricField : MonoBehaviour
{
    public const float COULOMB_CONSTANT = 8.9875517923e9F;
    // Start is called before the first frame update

    public Vector2 electricField = new Vector2(0, 0);
    public int electricFieldCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.FindGameObjectsWithTag("ChargedParticles").Length > electricFieldCount)
        {
            UpdateElectricField();
            electricFieldCount = GameObject.FindGameObjectsWithTag("ChargedParticles").Length;
        };
    }

    public void UpdateElectricField(){
        electricField = Vector2.zero;
        GameObject[] chargedParticles = GameObject.FindGameObjectsWithTag("ChargedParticles");
        foreach(GameObject chargedParticle in chargedParticles){
            // Debug.Log("Found Charge, Calculating..");
            Vector2 rVector = new Vector2(transform.position.x, -transform.position.z)- new Vector2(chargedParticle.transform.position.x, -chargedParticle.transform.position.z);
            float r = rVector.magnitude;
            float charge = chargedParticle.GetComponent<ChargedParticle>().charge;
            electricField += computeElectricField(r, charge, rVector);
            UpdateVectorRotation();
        }
    }

    void UpdateVectorRotation(){
        float angle = Mathf.Atan2(electricField.y, electricField.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    Vector2 computeElectricField(float r, float charge, Vector2 rVector){
        Vector2 eField = (COULOMB_CONSTANT * charge / Mathf.Pow(r, 3)) * rVector;
        return eField;
    }


}
