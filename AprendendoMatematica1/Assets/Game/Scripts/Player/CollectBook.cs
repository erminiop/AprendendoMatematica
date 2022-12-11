using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngineInternal;

struct nameTrigger{

}

public class CollectBook : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI knowTxt;
    [SerializeField] TextMeshProUGUI cBooksTxt;
   // [SerializeField] TextMeshProUGUI questionsTxt;
   //[SerializeField] TextMeshProUGUI correctTxt;

    int know;
    int cBooks;
    //int questions;
   // int answersCorrect;
    // Start is called before the first frame update
    void Start()
    {
        know = 0;
        cBooks = 0;
      //  questions = 0;
       // answersCorrect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        knowTxt.text = ""+know;
        cBooksTxt.text =""+cBooks;
        //questionsTxt.text = "" + questions;
        //correctTxt.text = "" + answersCorrect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Book"))
        {
            collision.gameObject.SetActive(false);
            cBooks++;
            know++;
        }
    }
}
