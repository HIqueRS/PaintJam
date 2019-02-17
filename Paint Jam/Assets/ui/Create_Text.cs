using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_Text : MonoBehaviour
{
    public Text text;
    public GameObject Star;
    int aaa;

    // Start is called before the first frame update
    void Start()
    {
        Star = GameObject.Find("Star");
    }

    // Update is called once per frame
    void Update()
    {
        aaa = Star.GetComponent<Movement>().Frags;
        text.text = "Frags: " + aaa + "/10";
    }
}
