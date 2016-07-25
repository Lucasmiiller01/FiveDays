using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
    public GameObject agreement;
    public Text texto1;
    public GameObject canvas;
    public bool active = false;
    private GameObject gameObject;
    public int counter;
    public int counter1;
    public int counter2;
    public int verba = 1000000;
    public string[] type;
    public List<string> academico = new List<string>();
    public List<string> social = new List<string>();
    public List<string> economico = new List<string>();
    public bool ok = true;
    public Text timet;
    public float time_h;
    public float time_m;
    public float fixedtime;
    int random;
    void Start()
    {
        random = 0;
        counter = 0;
        time_h = 5;
        ok = true;
    }

    public void OnCreate()
    {
        if (!active && ok)
        {
            int random = Random.Range(1,3);

            if (random == 1 && economico.Count < 1)
                random = Random.Range(2, 3);
            else if ((random == 2 && academico.Count < 1 && social.Count > 1))
                random = 3;
            else if (random == 3 && social.Count < 1 && academico.Count > 1)
                random = 2;
            else Debug.Log(random);
            switch (random)
            {
                case 1:
                    int random1 = Random.Range(0, economico.Count);
                    gameObject = (GameObject) Instantiate(agreement, new Vector2(400, 0), Quaternion.identity);
                    gameObject.transform.parent = canvas.transform;
                    gameObject.GetComponent<AgreementBehaviour>().type = type[0];

                    string[] split = economico[random1].Split('/');
              
                    foreach (string name in split)
	                {
                        gameObject.GetComponent<AgreementBehaviour>().name = split[0];
                        gameObject.GetComponent<AgreementBehaviour>().value = int.Parse(split[1].ToString());
	                }
                    if (economico.Count > 1) economico.RemoveAt(random1);
                    else economico.Clear();
                    counter++;
                
                    break;
                case 2:
                    int random2 = Random.Range(0, academico.Count);
                    gameObject = (GameObject) Instantiate(agreement, new Vector2(400, 0), Quaternion.identity);
                    gameObject.transform.parent = canvas.transform;
                    gameObject.GetComponent<AgreementBehaviour>().type = type[1];

                    string[] split1 = academico[random2].Split('/');
                    foreach (string name in split1)
	                {
                        gameObject.GetComponent<AgreementBehaviour>().name = split1[0];
                        gameObject.GetComponent<AgreementBehaviour>().value = int.Parse(split1[1].ToString());
	                }

                    if (academico.Count > 1) academico.RemoveAt(random2);
                    else academico.Clear();
                    counter1++;
                   
                    break;
                 case 3:
                    int random3 = Random.Range(0, social.Count);
                    gameObject = (GameObject) Instantiate(agreement, new Vector2(400, 0), Quaternion.identity);
                    gameObject.transform.parent = canvas.transform;
                    gameObject.GetComponent<AgreementBehaviour>().type = type[2];

                    string[] split2 = social[random3].Split('/');
                    foreach (string name in split2)
	                {
                        gameObject.GetComponent<AgreementBehaviour>().name = split2[0];
                        gameObject.GetComponent<AgreementBehaviour>().value = int.Parse(split2[1].ToString());
	                }
      
                    if (social.Count > 1) social.RemoveAt(random3);
                    else social.Clear();
                    counter2++;
                    
                    break;
            }

            if (social.Count + academico.Count + economico.Count >= 1) ok = true;
            else
                ok = false;

            active = true;
        }

    }
   
    void Update()
    {
        texto1.text = "Verba:" + verba.ToString();
        time_m = Time.fixedTime;

        if (time_m <= 9) timet.text = time_h + ":0" + Mathf.Round(time_m);
        else timet.text = time_h + ":" + Mathf.Round(time_m);
        
        if(random.Equals(0)) 
        {
            random = Random.Range(20, 40);
            fixedtime = 0;
        }
        else if (random >0 ) 
        {
            //random = 0;
            
            fixedtime = Time.deltaTime;
        }
        if (time_m > 59)
        {
            OnCreate();
            time_m = 0;
            time_h += 1;
        }
       
    }
}
