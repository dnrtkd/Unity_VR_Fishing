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
    public float fishforce; //����� ��
    public float limitTime; //���ѽð�
    public float rampageCycle; //���� �ֱ�

    [HideInInspector] public float size; // �¾���� ũ��
    [HideInInspector] public float weight;
    private void Start()  //����Ⱑ �����Ǹ� �ڵ����� ������
    {
        size = UnityEngine.Random.Range(minSize, MaxSize);
        weight = UnityEngine.Random.Range(minWeight, MaxWeihgt);

    }
}
