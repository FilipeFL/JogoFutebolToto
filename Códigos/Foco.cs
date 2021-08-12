using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foco : MonoBehaviour
{
    public GameObject FocoBola;

    private float yPos;
    private Vector3 posFoco;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FocoBola();
    }

    private void FocoBola()
    {
        posFoco = foco.transform.position;

        transform.LookAt(posFoco);
    }
}
