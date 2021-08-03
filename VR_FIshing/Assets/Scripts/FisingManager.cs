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
        if(Input.GetKeyDown(KeyCode.Q))  //낚시대 던지기
        {
            HookAway();
        }

        if (Input.GetKeyDown(KeyCode.W))  //훅 원위치
        {
            HookOrigin();
        }

        if (isfishingStart)   //물고기가 미끼 뭄
        {
            distance = Vector3.Distance(fishingHook.transform.position, returnPos.transform.position);

            if(!isfishTrue)
            {
                
            }

            




            Debug.Log(distance);
            if (Input.GetKey(KeyCode.E))  //릴 감기
            {
                
                RellWind(0);
                
            }

            if (Input.GetKey(KeyCode.R))  //릴 풀기
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


    void HookAway() // 낚시지 던지기
    {
        HookRigid.isKinematic = false;
        HookRigid.AddForce(this.transform.rotation * Vector3.up*speed);
        
        
    }

    void HookOrigin() //낚시지 원위치
    {
        HookRigid.isKinematic = true;
        fishingHook.transform.localPosition = HookOriginPos;
        
    }

    void RellWind(int num)  //릴 감기
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
