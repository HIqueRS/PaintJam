using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragResp : MonoBehaviour
{

    int Previous;
    int Current;
    public GameObject Star;
    public GameObject[] Frags;

    // Start is called before the first frame update
    void Start()
    {
        Previous = 0;
        Current = 0;
        Star = GameObject.Find("Star");
    }

    // Update is called once per frame
    void Update()
    {
        Current = Star.GetComponent<Movement>().NmrDeath();
        if(Current > Previous)
        {
            for(int i=0; i<5;i++)
            {
                Frags[i].SetActive(true);
            }
        }
    }
}
