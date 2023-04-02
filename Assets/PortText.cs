using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PortText : MonoBehaviour
{
    public Text Ptext;
    private string myText02;
    // Start is called before the first frame update
    void Start()
    {
        ReadText02();
        
    }

     private void ReadText02()  // 02方法
    {
        // 读取文件的所有内容
        myText02 = File.ReadAllText("Port.txt"); 
        Debug.Log(myText02);
        Ptext.text = myText02;
    }
}
