using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaperManager : MonoBehaviour {
    
    private GameController gamecontroller;
    private Documents myDoc;
    private Vector3 effects;

    [SerializeField]
    private Text texto;
    [SerializeField]
    private BoxCollider2D myCollider;
    // Use this for initialization
    void Start () 
    {
        gamecontroller = GameObject.Find("Main Camera").GetComponent<GameController>();
	}
	// Update is called once per frame

	void Update () 
    {
        if (transform.GetChild(1).GetComponent<Image>().enabled && myDoc.GetUsed().Equals(0))
        {
            myCollider.enabled = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5500, 0));
            gamecontroller.props += myDoc.GetVector();
            myDoc.SetUsed(1);
            gamecontroller.verba -= myDoc.GetValue();

        }
        else if (transform.GetChild(2).GetComponent<Image>().enabled && myDoc.GetUsed().Equals(0))
        {
            myCollider.enabled = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5500, 0)); 
            myDoc.SetUsed(2);
           

        }
    }
    public void SetDoc(Documents doc, int id)
    {
        myDoc = doc;
        myDoc.Use();
        texto.text = myDoc.GetText();
        
    }
}
