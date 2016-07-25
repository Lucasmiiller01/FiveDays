using UnityEngine;
using System.Collections;

public class NewSpaperController : MonoBehaviour {
    public GameController gameController;
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponentInParent<Animator>().enabled = false;
    }
    void OnMouseDown()
    {
        this.GetComponentInParent<Animator>().enabled = true;
       
    }
    void Update()
    {
    
        if(this.GetComponent<BoxCollider2D>().enabled == false)
        {
            if(!gameController.inGame) gameController.OnCreate();
            gameController.inGame = true;
           
        }
    }
}
