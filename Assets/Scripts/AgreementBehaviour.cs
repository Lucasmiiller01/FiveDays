using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AgreementBehaviour : MonoBehaviour {

    public bool active;
    public string type;
    public int value;
    public string name;
    private GameController gamecontroller;
    public Text texto;

	void Start () 
    {
        active = true;
        texto = GameObject.Find("myText").GetComponent<Text>();
        this.transform.localScale = new Vector3(2, 2, 1);
        gamecontroller = GameObject.Find("Main Camera").GetComponent<GameController>();
	}
	
	
	void Update () 
    {
        if(active) this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0, 0, 0), 0.05f);
        

        if (this.active) texto.text = this.name + "-" + this.value;


	}
    public void Yes()
    {
        gamecontroller.verba -= value;
        active = false;
        gamecontroller.active = false;
        Destroy(this.gameObject);

    }
    public void No()
    {
        active = false;
        gamecontroller.active = false;
        Destroy(this.gameObject);

    }
   
    
   
}
