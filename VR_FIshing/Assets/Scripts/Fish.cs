using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public string fishName;
    public float minSize;
    public float MaxSize;
    public float minWeight;
    public float MaxWeihgt; 
    public float fishforce; //물고기 힘
    public float limitTime; //제한시간
    public float rampageCycle; //난동 주기

    [HideInInspector] public float size; // 태어났을때 크기
    [HideInInspector] public float weight;
    private void Start()  //물고기가 생성되면 자동으로 설정됨
    {
        size = UnityEngine.Random.Range(minSize, MaxSize);
        weight = UnityEngine.Random.Range(minWeight, MaxWeihgt);

    }
}
