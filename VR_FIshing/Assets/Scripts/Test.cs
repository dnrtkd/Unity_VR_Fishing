using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]private LineRenderer line;
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private Transform HookPos;
    [SerializeField] private Transform pos3;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, pos3.position);
        line.SetPosition(1, pos1.position);
        line.SetPosition(2, pos2.position);
        line.SetPosition(3, HookPos.position);
    }
}
