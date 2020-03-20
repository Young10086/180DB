
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadText : MonoBehaviour
{
    private string[] myText01;
    private string myText02;
    private string myText03;
    float timer;


    public int NUM1;
    public int NUM2;
    public int NUM3;
    void Start()
    {
        ReadText01();
        ReadText02();
        ReadText03();
    }

    private void ReadText01()
    {

        myText02 = File.ReadAllText("C:\\Users\\15724\\Downloads\\AAA\\BBBB.txt");
        Debug.Log(myText02);
        NUM1 = int.Parse(myText02);
    }
    private void ReadText02()
    {

        myText02 = File.ReadAllText("C:\\Users\\15724\\Downloads\\AAA\\AAA.txt");
        Debug.Log(myText02);
        NUM2 = int.Parse(myText02);
    }
    private void ReadText03()
    {

        myText02 = File.ReadAllText("C:\\Users\\15724\\Downloads\\AAA\\CCC.txt");
        Debug.Log(myText03);
        NUM3 = int.Parse(myText03);
    }

    private void Update()
    {
   
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            timer = 0;
            ReadText01();
            ReadText02();
            ReadText02();
        }
    }

}
