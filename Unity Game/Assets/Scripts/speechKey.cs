using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;//引入命名空间  利用
using UnityEngine.SceneManagement;
/// <summary>
/// 语音识别（主要是别关键字）
/// </summary>
public class speechKey : MonoBehaviour
{


    public Animator playerA;
    public Animator playerB;
    public Animator temp;
    public Text Text_1;
    public Text Text_2;
    public float lifeA;
    public float lifeB;
    public Text aText;
    public Text bText;
    //minus effect
    public Text aText2;
    public Text bText2;

    public Text P1deadText;
    public Text P2deadText;
    public Button btn;


    public Slider aSlider;
    public Slider bSlider;
    public LoadText RT;


    // 短语识别器
    private PhraseRecognizer m_PhraseRecognizer;
    // 关键字
    public string[] keywords = { "你好", "开始","停止" };
    // 可信度
    public ConfidenceLevel m_confidenceLevel = ConfidenceLevel.Medium;

    /// <summary>
    /// 显示的文字
    /// </summary>
    private Text ShowText;

  
    public string textA;
    public string textB;
    public bool isB;
    public int health = 100;
    public float Adamage = 100;
    public float Bdamage = 100;
    
    public float indexA = 1;
    public float indexB = 1;

    public bool isPlayerA;
    // Use this for initialization
    void Start()
    {
        isB = false;
        ShowText = GameObject.Find("ShowText").GetComponent<Text>();
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



    /// <summary>
    ///  当识别到关键字时，会调用这个方法
    /// </summary>
    /// <param name="args"></param>
    private void M_PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        SpeechRecognition();
        ShowText.text = "show text：" + args.text;
        print(args.text);

        if (isB==false)
        {
            textA = args.text;
            isB = true;

        }
        else
        {
            textB = args.text;

            switch (textA)
            {
                case "attack":
                    {
                        if (RT.NUM1 != 1000 && RT.NUM1 != 1100 && RT.NUM1 != 1101) break;
                        playerA.GetComponent<AnimationEventEffects>().InstantiateEffectc(0);
                        StartCoroutine(DelayC(2));
                       
                    }
                    break;
                case "charge":
                    {
                        if (RT.NUM1 != 1111) break;
                        playerA.transform.localScale = playerA.transform.localScale * 1.5f;
                        indexA = indexA * 1.5f;
                    }
                    break;
                case "block":
                    {
                        if (RT.NUM1 != 2111) break;
                        print("111");
                        playerA.GetComponent<Animator>().SetTrigger("Fang");
                        indexB = indexB * 0.2f;
                    }
                    break;
                default:
                    break;
            }
            switch (textB)
            {
                case "attack":
                    {
                        if (RT.NUM2 != 1000 && RT.NUM2 != 1100 && RT.NUM2 != 1101 ) break;
                        playerB.GetComponent<AnimationEventEffects>().InstantiateEffectc(0);
                        StartCoroutine(DelayB(2));
            
                    }
                    break;
                case "charge":
                    {
                        if (RT.NUM2 != 1111) break;
                        playerB.transform.localScale = playerB.transform.localScale * 1.5f;
                        indexB = indexB * 1.5f;
                    }
                    break;
                case "block":
                    {
                        if (RT.NUM2 != 2111) break;
                        print("111");
                        playerB.GetComponent<Animator>().SetTrigger("Fang");
                        indexA = indexA * 0.2f;
                    }
                    break;
                default:

                    break;
            }
            isB = false;
            textA = null;
            textB = null;
            
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
    
    IEnumerator Delay(Animator a,string b,float T)
    {
        yield return new WaitForSeconds(T);
        a.SetTrigger(b);
    }

    IEnumerator DelayB( float T)
    {
        yield return new WaitForSeconds(0.3f);
        lifeA -= Random.Range(20, 30) * indexB;
        indexB = 1;
        yield return new WaitForSeconds(2.0f);
        playerB.transform.localScale = Vector3.one * 1.5f;
        if (lifeA <= 0)
        {
            P1deadText.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
        }
    }
    IEnumerator DelayC(float T)
    {
        yield return new WaitForSeconds(T);
        lifeB -= Random.Range(20, 30) * indexA;
        indexA = 1;
        playerA.transform.localScale = Vector3.one * 1.5f;
        if (lifeB <= 0)
        {
            P2deadText.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
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

        if (RT.NUM3 == 01)
        {
            temp = playerA;
            playerA = playerB;
            playerB = temp;
            Text_1.text = "Sasukei hp";
            Text_2.color = new Color32(243, 145, 15, 255);
            Text_1.color = new Color32(37, 185, 239, 255);
            Text_2.text = "Naruto hp";
        }
        if (RT.NUM3 == 10)
        {
            temp = playerB;
            playerB = playerA;
            playerA = temp;
            Text_2.text = "Sasukei hp";
            Text_1.color = new Color32(243, 145, 15, 255);
            Text_2.color = new Color32(37, 185, 239, 255);
            Text_1.text = "Naruto hp";
        }
        if (lifeA < Adamage)
        {
            Adamage = lifeA - Adamage;
            aText2.text = Adamage.ToString();
            Adamage = lifeA;
        }

        if (lifeB < Bdamage)
        {
            Bdamage = lifeB - Bdamage;
            bText2.text = Bdamage.ToString();
            Bdamage = lifeB;
        }

        aText.text = lifeA.ToString();
        bText.text = lifeB.ToString();
        
        aSlider.value = lifeA;
        bSlider.value = lifeB;

    }


    public void ButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}