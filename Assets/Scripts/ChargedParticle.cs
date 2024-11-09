using UnityEngine;

public class ChargedParticle : MonoBehaviour
{
    // Start is called before the first frame update
    public float charge = 1; // in coulomb
    public float voltage = 5;
    public Material positiveChargeColor;
    public Material negativeChargeColor;
    public MeshRenderer Mesh3D ; //3D mesh of our chaged particle
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Update3DTint();
    }

    void Update3DTint(){
        if(charge > 0){
            Mesh3D.material = positiveChargeColor;
        }else{
            Mesh3D.material = negativeChargeColor;
        }
    }
}
