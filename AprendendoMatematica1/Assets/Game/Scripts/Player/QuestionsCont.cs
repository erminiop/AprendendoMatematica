
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionsCont : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI questionsTxt;
    [SerializeField] TextMeshProUGUI correctTxt;


    QuestionsCont qc;
    int questions;
    int answersCorrect;
    int conhecimento;
    // Start is called before the first frame update
    void Start()
    {
       questions = 0;
       answersCorrect = 0;
       conhecimento = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        questionsTxt.text = "" + questions;
        correctTxt.text = "" + answersCorrect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Question"))
        {
            collision.gameObject.SetActive(false);
            questions++;

            int operators;
            int A = Random.Range(0, 100);
            int B = Random.Range(0, 100);
            int C;
            int resultado;
            if (conhecimento < 100)
            {
                operators = Random.Range(0, 1);
                if (operators == 0)
                {
                    print("Teste calculo: " + A + "+" + B);
                    resultado = A + B;
                    conhecimento = conhecimento * 2;
                    print("Resultado: " + resultado);
                    
                }
                else if (operators == 1)
                {
                    print("Teste calculo: " + A + "-" + B);
                    resultado = A - B;
                    conhecimento = conhecimento * 2;
                    print("Resultado: " + resultado);
                }
                else
                {
                    print("Errrrrrooooorrr");
                }
            }
        }
    }
    private void ArithmeticOperations(int conhecimento)
    {
       
    }

}
