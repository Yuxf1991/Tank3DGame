using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class Subtitles : MonoBehaviour
{
    Text Titles;
    public GameObject GameCtrl;
    StreamReader sr;

    void Start()
    {
        Titles = GetComponent<Text>();
        StartCoroutine(PlayTitles("subtitle.txt"));
    }

    void Update()
    {
    }

   public  IEnumerator PlayTitles(string FileName)
    {
        GameCtrl.SendMessage("SetLevel");

        //Debug.Log(Application.dataPath + "/Subtitles/"+FileName);
        sr = new StreamReader(Application.dataPath + "/Subtitles/" + FileName, System.Text.Encoding.Default,true);
        int lineCount = int.Parse(sr.ReadLine());
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();
            GetComponent<AudioSource>().Play();
            string text = tempText.Split('$')[0];
            float tempTime;
            float.TryParse(tempText.Split('$')[1], out tempTime);
            for (int j = 0; j < text.Length; j++) {
                Titles.text = Titles.text + text[j];
                yield return new WaitForSeconds(tempTime/text.Length);
            }
            Titles.text += "\n";
        }
        yield return new WaitForSeconds(5f);
        Titles.text = "";
    }
}