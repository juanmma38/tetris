using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public static void Moviendo2()
    {
        for(int i = 0; i < TestPlayField.listaObjs.Count; i++)
        {
            TestPlayField.listaObjs[i].GetComponent<MoveTetronimos>().MoverActivo();

        }
    }
/*public static void Moviendo()
    {
        print("*************moviendo**************");
        for(int i = 0; i < TestPlayField.h; i++)
        {
            for(int i2 = 0; i2 < TestPlayField.w; i2++)
            {
                if (TestPlayField.grid[i, i2] != null)
                {
                    for(int i3 = 0; i3 < TestPlayField.listaObjs.Count; i3++)
                    {
                        print("lista objs " + TestPlayField.listaObjs[i3]);
                        print("arr f " + i + " c " + i2);
                        if(TestPlayField.listaObjs[i3].x==TestPlayField.grid[i,i2].position.x&&
                            TestPlayField.listaObjs[i3].y == TestPlayField.grid[i, i2].position.y)
                        {
                            print("moviendo f " + i + " c " + i2);
                            TestPlayField.grid[i, i2].gameObject.GetComponent<MoveTetronimos>().MoverActivo();
                         //   TestPlayField.grid[i, i2] = null;
                            break;
                        }
                    }
                }
            }
        }
    }*/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Print();
        }
    }
    public void Print()
    {
        print("***************print**********************");
        for (int i = 0; i < TestPlayField.h; i++)
        {
            for (int i2 = 0; i2 < TestPlayField.w; i2++)
            {
                print("indice y " + i+ "indice x "+i2);
                print(TestPlayField.grid[i, i2]);
            }
        }
            }
}
