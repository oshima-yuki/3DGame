using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    enum STEP
    {
        START,
        TALK,
        MAIN,
        END
    }

    STEP step;
    public GameObject Items;
    public GameObject Counter;
    public GameObject Result;
    public int min = -50, max = 50, x, y;
    public  int count = 10;
    float oldTime=0.0f;
    float resultTime = 0.0f;


    public Text Allgems;
    public Text Timepass;
    public Text resultTimeText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(step);
        Debug.Log(GetItems.GemCount);
        step = STEP.START;
    }

    // Update is called once per frame
    void Update()
    {
        switch (step)
        {
            case STEP.START:
                if (TextCon.textcheck)
                {
                    step = STEP.TALK;
                }
                break;
            case STEP.TALK:
                if (TextCon.textreader)
                {
                    step = STEP.MAIN;
                    Counter.SetActive(true);
                    for (int i = 0; i < count; i++)
                    {
                        CreateItems();
                    }
                    oldTime = Time.time;
                }
                break;
            case STEP.MAIN:
                Timepass.text = (Time.time-oldTime).ToString();
                if (GetItems.GemCount == count)
                {
                    step= STEP.END;
                    resultTime = Time.time - oldTime;
                }
                break;
            case STEP.END:

                Result.SetActive(true);
                Counter.SetActive(false);

                resultTimeText.text = resultTime.ToString();

                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("Main");
                   
                   
                }
                break;
        }
        Allgems.text = count.ToString();
    }

    void CreateItems()
    {

            x = Random.Range(min, max);
            y = Random.Range(min, max);
            Instantiate(Items, new Vector3(x, 1.0f, y), Quaternion.Euler(-90, 0, 0));
    }
    
}
