using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    [SerializeField] Transform aquaritr; //����Ƹ��� ��ġ

    public GameObject[] fish_List; //����� ����Ʈ
    public List<GameObject> aquarium_list; //������ ����Ʈ
    [SerializeField] private GameObject fishing_rod; //���ô�
    

    private GameObject fish; //������ �����
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fishing_rod.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            fish = Instantiate(aquarium_list[0],   //����� ����
                  aquaritr.position,aquaritr.rotation);
            Debug.Log(fish.GetComponent<Fish>().size);
            Debug.Log(aquarium_list[aquarium_list.Count-1]);
        }

        
       
    }
    public void OC_ChangeScene(string SceneName) //���ӽ� ����
    {
        SceneManager.LoadScene(SceneName);
    }

   public void OnFishInsert(bool click)
    {
        if(click)
        {
            Instantiate(aquarium_list[-1],aquaritr.position, aquaritr.rotation); //����� ����
            Debug.Log(aquarium_list[-1]);
        }
        else
        {
            aquarium_list.RemoveAt(-1);
            Debug.Log(aquarium_list[-1]);
        }
    }


    public class Aquarium
    {
      



    }

    public class Fish_list
    {

    }


        
   
}
