using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class VoiceReconitionMinigame : MonoBehaviour
{
    
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        if (args.text == m_Keywords[0])
        {
            SceneManager.LoadScene("OpenWorld");
        }
    }
    
    
     /* private void Update()
    {
        ControllerHandler controllerHandler = FindObjectOfType<ControllerHandler>();
        if (controllerHandler.back == true)
        {
            SceneManager.LoadScene("OpenWorld");
        }
    }*/
     
}
