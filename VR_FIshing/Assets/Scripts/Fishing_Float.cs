using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing_Float : MonoBehaviour
{
    [SerializeField] float m_force;

    private Rigidbody rigd;
    private bool isGet_force;
    private bool Float_direction;

    private void Start()
    {
        rigd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        

        if(Input.GetMouseButtonDown(0))
        {
            if(!isGet_force)
            {
                Get_force();
            }

        }
    }

    public void Get_force()
    {
        rigd.AddForce(this.transform.rotation*Vector3.forward* m_force);
        rigd.useGravity = true;
        isGet_force = true;
    }
}
