using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTetronimos : MonoBehaviour
{
    private float target;
    int col;
    private bool active = false;
    private float velocity = 3f; 
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (transform.position.y > target)
            {
                transform.Translate(Vector2.down * Time.deltaTime * velocity, Space.World);
            }
            else
            {
                print("movimiento termino");
                active = false;
                TestPlayField.listaObjs.Clear();
                TestPlayField.indiceMatch = 0;
               
            }
           

                //active = false;

        }
    }   
           
    public void MoverActivo()
    {
        active = true;
      
        target = transform.position.y - TestPlayField.indiceMatch;
    }
   public int setCol
    {
        set { col = value; }
        get { return col; }
    }

}
