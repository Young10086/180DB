using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ReadText : MonoBehaviour
{
    public Text texts;
    public int num;
    float timer;
    void Start()
    {
        num = int.Parse(Resources.Load("111").ToString());
        texts.text = num.ToString();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            num = int.Parse(Resources.Load("111").ToString());
            texts.text = num.ToString();
        }
        
    }

}
