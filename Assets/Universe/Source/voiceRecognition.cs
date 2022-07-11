using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voiceRecognition: MonoBehaviour
{
    public SaveHandler SaveHandler1;
    public GameObject shop;
    public GameObject games;
    public GameObject player;
    public float spawnDistance;

    private Vector3 playerPosition;
    private Vector3 playerDirection;
    private Quaternion playerRotation;
    private Vector3 spawnPosition;
    
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;
    
    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    public void OnPhraseRecognized(PhraseRecognizedEventArgs args)
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
        if (args.text == m_Keywords[4])
        {
            Debug.Log("Save");
            SaveHandler1.SaveAllObjects = true; 
            
            
        }
    }
    

    /*
    private void Update()
    {
        ControllerHandler controllerHandler = FindObjectOfType<ControllerHandler>();
        if (controllerHandler.secondary == true)
        {
            spawnPosition = playerPosition + playerDirection * spawnDistance;
            Instantiate(shop, spawnPosition, Quaternion.identity);
        }

        if (controllerHandler.saveButton > 0)
        {
            SaveHandler1.SaveAllObjects = true;
        }
        if (controllerHandler.primary == true)
        {
            spawnPosition = playerPosition + playerDirection * spawnDistance;
            Instantiate(games, spawnPosition, Quaternion.identity);
        }
    }

*/

}
