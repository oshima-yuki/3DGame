using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	// uGUIの機能を使うお約束

public class TextCon : MonoBehaviour
{
    public string[] scenarios; // シナリオを格納する
    public Text uiText; // uiTextへの参照を保つ
    public GameObject panel;
    public GameObject Exmark;
   public static bool textcheck;
    public static bool textreader;
    int currentLine = 0; // 現在の行番号
    
    // Start is called before the first frame update
    void Start()
    {
        textcheck = false;
        textreader = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (textcheck && Input.GetMouseButtonDown(0))
        {
            panel.SetActive(true);
            Exmark.SetActive(false);
        }
        // 現在の行番号がラストまで行ってない状態でクリックすると、テキストを更新する
        if (panel.activeInHierarchy && currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
        {
            TextUpdate();
        }
            if(currentLine == scenarios.Length)
            {
                textreader =true;
            panel.SetActive(false);
        }
            
        
        
    }

    void TextUpdate()
    {
        // 現在の行のテキストをuiTextに流し込み、現在の行番号を一つ追加する
        uiText.text = scenarios[currentLine];
        currentLine++;
    }

    void OnTriggerEnter(Collider other)
    {
        Exmark.SetActive(true);
     
            if (other.gameObject.tag == "Player")
            {
            Debug.Log("tuuka");
            textcheck = true;
            }
    }
}
