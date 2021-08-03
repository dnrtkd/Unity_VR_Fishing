using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisingManager : MonoBehaviour
{
    [SerializeField] private GameObject fishingHook;
    [SerializeField] private GameObject fishingReel;
    
    [SerializeField] private float speed;
    
    [SerializeField] private Transform returnPos;
    
    //private Vector3 direction;
    private Rigidbody HookRigid;
    private Collider[] hookColl;
    private bool isfishingStart;
    private Vector3 HookOriginPos;
    private float currentTime;
    private float distance;
    private bool isfishTrue;
  

    private void Start()
    {
        HookRigid = fishingHook.GetComponent<Rigidbody>();
        HookOriginPos = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))  //���ô� ������
        {
            HookAway();
        }

        if (Input.GetKeyDown(KeyCode.W))  //�� ����ġ
        {
            HookOrigin();
        }

        if (isfishingStart)   //����Ⱑ �̳� ��
        {
            distance = Vector3.Distance(fishingHook.transform.position, returnPos.transform.position);

            if(!isfishTrue)
            {
                
            }

            




            Debug.Log(distance);
            if (Input.GetKey(KeyCode.E))  //�� ����
            {
                
                RellWind(0);
                
            }

            if (Input.GetKey(KeyCode.R))  //�� Ǯ��
            {

                RellWind(1);

            }
        }

       
        hookColl = Physics.OverlapSphere(fishingHook.transform.position, 0.5f);
        foreach (var i in hookColl)
        {
            if (i.tag=="water")
            {
                HookRigid.isKinematic = true;
                currentTime += Time.deltaTime;
                if (currentTime>=3)
                {
                    currentTime = 0;
                    isfishingStart = true;
                }
                
            }
        }
       
        
    }


    void HookAway() // ������ ������
    {
        HookRigid.isKinematic = false;
        HookRigid.AddForce(this.transform.rotation * Vector3.up*speed);
        
        
    }

    void HookOrigin() //������ ����ġ
    {
        HookRigid.isKinematic = true;
        fishingHook.transform.localPosition = HookOriginPos;
        
    }

    void RellWind(int num)  //�� ����
    {
         if (num==0)
        {
            fishingReel.transform.localEulerAngles += new Vector3(0, 0, 10) * Time.deltaTime*50;
            fishingHook.transform.localPosition = Vector3.MoveTowards(fishingHook.transform.localPosition, returnPos.transform.localPosition, 0.05f);
        }
            
        if (num==1)
        {
            fishingReel.transform.localEulerAngles += new Vector3(0, 0, -10) * Time.deltaTime * 50;
            
        }
    }
     
    
        
    
}
