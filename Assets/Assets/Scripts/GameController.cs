using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MyExtensions;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Text clock;
    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private GameObject screen;

    private int seconds;
    private int minutes;
    private int randomSpawn;
    private Documents[] docs;
    public Vector3 props = new Vector3(1000,1000,1000);
    public Text texto1;
    private GameObject gameObject;
    public int verba = 1000000;
  
    public bool ok = true;
    public TextAsset asset;
    
    [SerializeField]
    private GameObject isFadeActive;
    [SerializeField]
    private GameObject day;
    float a;
    public bool inGame;
    [SerializeField]
    private GameObject magnifyGlass_C;
    [SerializeField]
    private GameObject magnifyGlass;


    void Start()
    {
        seconds = 0;
        minutes = 0;
        randomSpawn = 2;
        ok = true;
        GetAllDocs();
        this.isFadeActive.SetActive(true);
        inGame = false;
       
    }
    void GetAllDocs()
    {
        string[] splitDocs = asset.text.Split('/');
        docs = new Documents[splitDocs.Length];
        for (int i = 0; i < splitDocs.Length; i++)
        {
            string[] splitProps = splitDocs[i].Split(':');
            string[] vector = splitProps[2].Split(',');
            docs[i] = new Documents(splitProps[0], splitProps[1],
                new Vector3(int.Parse(vector[0]), int.Parse(vector[1]), int.Parse(vector[2])), int.Parse(splitProps[3]));
        }
    }
    public void StartToGame()
    {
        inGame = true;
    }

	void FixedUpdate () 
    {
        if(inGame) 
        {
            texto1.text = "Verba:" + verba.ToString();
            seconds = Mathf.FloorToInt(Time.fixedTime);
            minutes = Mathf.FloorToInt(seconds / 60);
            seconds = seconds - (60 * minutes);
            if(seconds < 10 && minutes < 10)
                clock.text = "0" +  minutes + ":0" + seconds;
            else if ( minutes < 10)
                clock.text = "0" +  minutes + ":" + seconds;
            else if (seconds < 10)
                clock.text = minutes + ":0" + seconds;
            else
                clock.text = minutes + ":" + seconds;

            if(seconds.Equals(randomSpawn))
            {
                OnCreate();
                randomSpawn = Random.Range(0,59);
            }
            randomSpawn = Random.Range(0, 59);
        }
        else if (isFadeActive.activeSelf && isFadeActive.GetComponent<Image>().color.a < 0.2f)  
        {
            magnifyGlass_C.SetActive(true);
            magnifyGlass.SetActive(true);

        }
    }
    public void OnCreate()
    {
        int temp = Random.Range(0,docs.Length-1);
        while(docs[temp].GetUse())
        {
            temp = Random.Range(0, docs.Length - 1);
        }
        gameObject = (GameObject)Instantiate(paper);
        gameObject.GetComponent<RectTransform>().SetParent(screen.GetComponent<RectTransform>(), false);
        gameObject.GetComponent<RectTransform>().position = new Vector3(10, Random.Range(-300, 300) / 100, 0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500, 0));
        gameObject.GetComponent<PaperManager>().SetDoc(docs[temp], temp);
          
    }
}
