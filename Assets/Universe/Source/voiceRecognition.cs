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
    public float spawnDistance;

    private Vector3 playerPosition;
    private Vector3 playerDirection;
    private Quaternion playerRotation;
    private Vector3 spawnPosition;

    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        playerPosition = player.transform.position;
        playerDirection = player.transform.forward;
        playerRotation = player.transform.rotation;

        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        if(args.text == m_Keywords[0])
        {
            Application.Quit();
        }
        if (args.text == m_Keywords[1])
        {
            spawnPosition = playerPosition +playerDirection *spawnDistance;
            Instantiate(shop, spawnPosition, Quaternion.identity);
        }
        if (args.text == m_Keywords[2])
        {
            spawnPosition = playerPosition + playerDirection * spawnDistance;
            Instantiate(games, spawnPosition, Quaternion.identity);
        }
    }
}
