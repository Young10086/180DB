using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ReadText2 : MonoBehaviour
{
    public Text texts;
    public int num2;
    float timer;
    void Start()
    {
        num2 = int.Parse(Resources.Load("222").ToString());
        texts.text = num2.ToString();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            num2 = int.Parse(Resources.Load("222").ToString());
            texts.text = num2.ToString();
        }
    }

}
