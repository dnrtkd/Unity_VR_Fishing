using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FisingManager : MonoBehaviour  //���ô� ��ũ��Ʈ
{
    
    //���ô� ���� ���
    [SerializeField] private GameObject fishingHook;  //������
    [SerializeField] private GameObject fishingReel;  //��
    [SerializeField] private GameObject ReelMobile;   //�� ���ư��� �κ�
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject catchUi; //����� ������� �ߴ� ui

    [SerializeField] private float speed;
    
    [SerializeField] private Transform returnPos;

    //����� �迭
     

    private GameObject fish; //������ �����

    private Rigidbody HookRigid;
    private Collider[] hookColl;
    private Vector3 HookOriginPos;
    
    private float distance;

    private bool isfishingStart; //���ӸŴ����� �Ѱ��� ����

    private bool isfishOn; // ����Ⱑ �ִ��� ������

    private float currentTime;

    private float gameTime; //����� ��Ⱑ �������� ���� üũ

    private float limitTime; //���ѽð�

    private void Start()
    {
        HookRigid = fishingHook.GetComponent<Rigidbody>();
        HookOriginPos = new Vector3(0, 0, 0);
        
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)&&!isfishingStart)  //���ô� ������
        {
            HookAway();
        }

        if (Input.GetKeyDown(KeyCode.W)&&!isfishingStart)  //�� ����ġ
        {
            HookOrigin();
        }

        if (isfishingStart)   //����Ⱑ �̳� ��
        {
            distance = Vector3.Distance(fishingHook.transform.position, returnPos.transform.position);

            gameTime += Time.deltaTime;

            
            if(!isfishOn) //����Ⱑ ������
            {
                fish = Instantiate(gameManager.fish_List[UnityEngine.Random.Range(0, gameManager.fish_List.Length)],   //����� ����
                   fishingHook.transform.position, fishingHook.transform.rotation, fishingHook.transform);
                isfishOn = !isfishOn;
            }

            
            if (distance<3)  //�Ÿ��� 3 �����̸� ����� ����
            {
                isfishingStart = false;
                gameManager.aquarium_list.Add(fish);
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
                    isfishingStart = true;  //���� ��� 3�������� ���� ����
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
            ReelMobile.transform.Rotate(new Vector3(20, 0, 0)*Time.deltaTime*30);
        }
            
        if (num==1)
        {
            fishingReel.transform.localEulerAngles += new Vector3(0, 0, -10) * Time.deltaTime * 50;
            
        }
    }

 
     
    
        
    
}
