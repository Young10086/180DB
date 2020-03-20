using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;//引入命名空间  利用
using UnityEngine.SceneManagement;
using System.IO;
/// <summary>
/// 语音识别（主要是别关键字）
/// </summary>
public class SpeechKey1 : MonoBehaviour
{





    // 短语识别器
    private PhraseRecognizer m_PhraseRecognizer;
    // 关键字
    public string[] keywords = { "你好", "开始", "停止" };
    // 可信度
    public ConfidenceLevel m_confidenceLevel = ConfidenceLevel.Medium;

    public int myNum;
    public int NUM2;
    public float timer;
    public Text mainText;
    /// <summary>
    /// 显示的文字
    /// </summary>



    private void ReadText03()
    {

        

        NUM2 = int.Parse(File.ReadAllText("C:\\Users\\15724\\Downloads\\AAA\\AAA.txt"));
    }

    // Use this for initialization
    void Start()
    {
      
        if (m_PhraseRecognizer == null)
        {
            //创建一个识别器
            m_PhraseRecognizer = new KeywordRecognizer(keywords, m_confidenceLevel);
            //通过注册监听的方法
            m_PhraseRecognizer.OnPhraseRecognized += M_PhraseRecognizer_OnPhraseRecognized;
            //开启识别器
            m_PhraseRecognizer.Start();

            Debug.Log("创建识别器成功");
        }

    }

    public void HideText()
    {
        mainText.gameObject.SetActive(false);
    }

    /// <summary>
    ///  当识别到关键字时，会调用这个方法
    /// </summary>
    /// <param name="args"></param>
    private void M_PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        SpeechRecognition();

        print(args.text);
        string NUM1 = (args.text);
        if (myNum == 1)
        {
            if (NUM2 == 1 && NUM1 == "charge")
            {
                mainText.text = "CORRECT!";
                mainText.color = new Color32(11, 255, 64, 255);
            }
            else
            {
                mainText.text = "WRONG!";
                mainText.color = new Color32(236, 10, 16, 255);
            }
            Invoke("HideText", 2);
        }
        else if (myNum == 2)
        {
            if (NUM2 == 2 && NUM1 == "block")
            {
                mainText.text = "CORRECT!";
                mainText.color = new Color32(11, 255, 64, 255);
            }
            else
            {
                mainText.text = "WRONG!";
                mainText.color = new Color32(236, 10, 16, 255);
            }
            Invoke("HideText", 2);
        }
        else if (myNum == 3)
        {
            if (NUM2 == 1 && NUM1 == "attack")
            {
                mainText.text = "CORRECT!";
                mainText.color = new Color32(11, 255, 64, 255);
            }
            else
            {
                mainText.text = "WRONG!";
                mainText.color = new Color32(236, 10, 16, 255);
            }
            Invoke("HideText", 2);
        }
        else if (myNum == 4)
        {
            if (NUM2 == 1 && NUM1 == "attack")
            {
                mainText.text = "CORRECT!";
                mainText.color = new Color32(11, 255, 64, 255);
            }
            else
            {
                mainText.text = "WRONG!";
                mainText.color = new Color32(236, 10, 16, 255);
            }
            Invoke("HideText", 2);
        }








    }
    private void OnDestroy()
    {
        //判断场景中是否存在语音识别器，如果有，释放
        if (m_PhraseRecognizer != null)
        {
            //用完应该释放，否则会带来额外的开销
            m_PhraseRecognizer.Dispose();
        }

    }

   
    
    /// <summary>
    /// 识别到语音的操作
    /// </summary>
    void SpeechRecognition()
    {

    }


    private void Update()
    {

        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            timer = 0;

            ReadText03();
        }

    }


    public void ButtonClick(string aa)
    {
        myNum = int.Parse(aa);
        mainText.gameObject.SetActive(true);
        mainText.text = "Do the mudra and shout out the word";
        mainText.color = new Color32(11, 18, 255, 255);
    }

}