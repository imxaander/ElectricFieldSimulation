using System.Collections.Generic;
using UnityEngine;

public class ChargedParticle : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public float charge = 1; // in coulomb
    public float voltage = 5;

    public Material positiveChargeColor;
    public Material negativeChargeColor;
    public Material noChargeColor;
    public MeshRenderer Mesh3D ; //3D mesh of our chaged particle
    public ConductivePaper conductivePaper;
    public bool charged = false;
    
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Charge(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Update3DTint();
    }

    void Update3DTint(){
        if(charge > 0){
            Mesh3D.material = positiveChargeColor;
        }else if(charge == 0){
            Mesh3D.material = noChargeColor;
        }else{
            Mesh3D.material = negativeChargeColor;
        }
    }

    private float Negative(float n)
    {
        if(n > 0)
        {
            return n * -1;
        }
        return n; 
    }

    private float Positive(float n)
    {
        if (n < 0)
        {
            return n * -1;
        }
        return n;
    }

    public void Discharge()
    {
        charged = false;
        charge = 0;
    }

    //+-1
    public void Charge(int polarity)
    {
        if(charged) return;
        charge = 3;
        if(polarity == -1)
        {
            this.charge = Negative(this.charge);
        }
        else
        {
            this.charge = Positive(this.charge);
        }
        this.charged = true;
        //go to closest component and charge them with same polarity

        //List<GameObject> NearGameobjects = new List<GameObject>();

        //float oldDistance = 9999;

        //foreach (GameObject g in NearGameobjects)
        //{
        //    float dist = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
        //    if (dist < oldDistance)
        //    {
        //        GameObject closestGameObject;

        //        closestGameObject = g;
        //        oldDistance = dist;

        //        Debug.Log(closestGameObject.transform.name);

        //    }
        //}



        Debug.Log("---------------");
        Collider[] closeCharges = Physics.OverlapSphere(transform.position, 0.05f);
        foreach (var closeCharge in closeCharges)
        {
            if (closeCharge.transform.CompareTag("ChargedParticles"))
            {
                Debug.Log("CHarge Close");
                closeCharge.GetComponent<ChargedParticle>().Charge(polarity);
                
            }
            
        }

        GameObject[] electricFields = GameObject.FindGameObjectsWithTag("ElectricField");
        foreach(var electricField in electricFields)
        {
            electricField.GetComponent<ElectricField>().UpdateElectricField();
        }
    }

    public void Interact()
    {
        Charge(-1);
    }
}
