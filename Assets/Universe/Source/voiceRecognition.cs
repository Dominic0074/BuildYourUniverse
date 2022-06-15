using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voiceRecognition: MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    public GameObject shop;
    public GameObject games;
    public GameObject player;

    Vector3 playerPosition;

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

        if(args.text == m_Keywords[0])
        {
            
        }
        if (args.text == m_Keywords[1])
        {
            playerPosition = player.transform.position;
            playerPosition.x = playerPosition.x + 1;
            playerPosition.z = playerPosition.z + 1;
            Instantiate(shop, playerPosition,Quaternion.identity);
        }
        if (args.text == m_Keywords[2])
        {
            Instantiate(games, new Vector3(0, 0, 1), Quaternion.identity);
        }
    }
}
