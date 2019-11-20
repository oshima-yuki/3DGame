using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItems : MonoBehaviour
{
    public static int GemCount = 0;
    public Text Getgems;
    // Start is called before the first frame update
    void Start()
    {
        GemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Getgems.text = GemCount.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            GemCount++;
            Destroy(collision.gameObject);
        }
    }
}
