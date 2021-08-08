using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FisingManager : MonoBehaviour  //낚시대 스크립트
{
    
    //낚시대 구성 요소
    [SerializeField] private GameObject fishingHook;  //낚시찌
    [SerializeField] private GameObject fishingReel;  //릴
    [SerializeField] private GameObject ReelMobile;   //릴 돌아가는 부분
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject catchUi; //물고기 잡았을때 뜨는 ui

    [SerializeField] private float speed;
    
    [SerializeField] private Transform returnPos;

    //물고기 배열
     

    private GameObject fish; //생성된 물고기

    private Rigidbody HookRigid;
    private Collider[] hookColl;
    private Vector3 HookOriginPos;
    
    private float distance;

    private bool isfishingStart; //게임매니저에 넘겨줄 변수

    private bool isfishOn; // 물고기가 있는지 없는지

    private float currentTime;

    private float gameTime; //낚시찌를 고기가 물었을때 부터 체크

    private float limitTime; //제한시간

    private void Start()
    {
        HookRigid = fishingHook.GetComponent<Rigidbody>();
        HookOriginPos = new Vector3(0, 0, 0);
        
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)&&!isfishingStart)  //낚시대 던지기
        {
            HookAway();
        }

        if (Input.GetKeyDown(KeyCode.W)&&!isfishingStart)  //훅 원위치
        {
            HookOrigin();
        }

        if (isfishingStart)   //물고기가 미끼 뭄
        {
            distance = Vector3.Distance(fishingHook.transform.position, returnPos.transform.position);

            gameTime += Time.deltaTime;

            
            if(!isfishOn) //물고기가 없으면
            {
                fish = Instantiate(gameManager.fish_List[UnityEngine.Random.Range(0, gameManager.fish_List.Length)],   //물고기 생성
                   fishingHook.transform.position, fishingHook.transform.rotation, fishingHook.transform);
                isfishOn = !isfishOn;
            }

            
            if (distance<3)  //거리가 3 이하이면 물고기 잡음
            {
                isfishingStart = false;
                gameManager.aquarium_list.Add(fish);
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
                    isfishingStart = true;  //물에 닿고 3초지나면 입질 시작
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
            ReelMobile.transform.Rotate(new Vector3(20, 0, 0)*Time.deltaTime*30);
        }
            
        if (num==1)
        {
            fishingReel.transform.localEulerAngles += new Vector3(0, 0, -10) * Time.deltaTime * 50;
            
        }
    }

 
     
    
        
    
}
