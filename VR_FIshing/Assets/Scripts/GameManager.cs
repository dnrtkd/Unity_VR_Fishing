using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    [SerializeField] Transform aquaritr; //아쿠아리움 위치

    public GameObject[] fish_List; //물고기 리스트
    public List<GameObject> aquarium_list; //수족관 리스트
    [SerializeField] private GameObject fishing_rod; //낚시대
    

    private GameObject fish; //생성된 물고기
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fishing_rod.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            fish = Instantiate(aquarium_list[0],   //물고기 생성
                  aquaritr.position,aquaritr.rotation);
            Debug.Log(fish.GetComponent<Fish>().size);
            Debug.Log(aquarium_list[aquarium_list.Count-1]);
        }

        
       
    }
    public void OC_ChangeScene(string SceneName) //게임신 변경
    {
        SceneManager.LoadScene(SceneName);
    }

   public void OnFishInsert(bool click)
    {
        if(click)
        {
            Instantiate(aquarium_list[-1],aquaritr.position, aquaritr.rotation); //물고기 생성
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
