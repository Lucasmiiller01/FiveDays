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
    [SerializeField]
    private TextAsset asset;
    public bool inGame;
    [SerializeField]
    private int tempDay;
    [SerializeField]
    private Text day;

    private int dayActual;
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private GameObject fade;


    void Start()
    {
        inGame = false;
        seconds = 0;
        minutes = 0;
        randomSpawn = Random.Range(40, 50);
        GetAllDocs();
        dayActual = 1;
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
	void FixedUpdate ()
    {
        if(inGame)
        {
            texto1.text = "Verba:" + verba.ToString();
            seconds = 240 + Mathf.FloorToInt(Time.fixedTime);
            minutes = Mathf.FloorToInt(seconds / 60);
            seconds = seconds - (60 * minutes);
            if(seconds < 10 && minutes < 10)
                clock.text = "0" + minutes + ":0" + seconds;
            else if (minutes < 10)
                clock.text = "0" + minutes + ":" + seconds;
            else if (seconds < 10)
                clock.text = minutes + ":0" + seconds;
            else
                clock.text = minutes + ":" + seconds;

            if(seconds.Equals(randomSpawn))
            {
                OnCreate();
                randomSpawn = Random.Range(0,30);
            }
            if(minutes >= tempDay)
            {
                ProxDay();
            }
            day.text = "Day " + dayActual.ToString();
        }
        else
        {
            seconds = 240 + Mathf.FloorToInt(Time.fixedTime);
            minutes = Mathf.FloorToInt(seconds / 60);
            seconds = seconds - (60 * minutes);
            if (seconds < 10 && minutes < 10)
                clock.text = "0" + minutes + ":0" + seconds;
            else if (minutes < 10)
                clock.text = "0" + minutes + ":" + seconds;
            else if (seconds < 10)
                clock.text = minutes + ":0" + seconds;
            else
                clock.text = minutes + ":" + seconds;
            day.text = "Day " + dayActual.ToString();
        }


    }
    public void ProxDay()
    {
        dayActual = 2;
        seconds = 0;
        minutes = 0;
        Canvas.SetActive(false);
        inGame = false;
        fade.SetActive(true);

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
