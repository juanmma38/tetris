using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayField : MonoBehaviour
{

    public static int w = 10;
    public static int h = 22;
    public static int score = 0;
    public static Transform[,] grid = new Transform[h, w];
    public int cambioRitmo = 50;
    public static float cambioRitmoJuego = 0.0f;
    public static int velocity = 1;
    public static List<GameObject> listaObjs = new List<GameObject>();
    public delegate void MoveTetronimos(bool _active );
    public static int indiceMatch;
    private Move move;
    public static List<GameObject> listaObjsEscena = new List<GameObject>();
    public static int[] arrRows=new int[w];
    public static bool activeGameOver = false;
    public static bool win = false;
    public static int targetScore = 80;
    void Start()
    {

        move = GetComponent<Move>();
    }

   //me falta establecer la col de la grilla para q baje el nivel q deberia
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }
    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
                (int)pos.x < w &&
                (int)pos.y >= 0);
    }
    public static void deleteRow(int y)
    {
        //print("**********delete row************");
        //print("****y**** " + y);
        for (int x = 0; x < w; ++x)
        {
            //print("x " + x);
           // print("grid " + grid[y, x].position);
           
            Destroy(grid[y, x].gameObject);
            grid[y, x] = null;
            
        }
        
    }
    public static bool gameOver()
    {
        for(int i = 0; i < listaObjsEscena.Count; i++)
        {
            for (int i2 = 0; i2 < listaObjsEscena[i].transform.childCount; i2++)
            {
                float y = listaObjsEscena[i].transform.GetChild(i2).transform.position.y;
                if (y >= 20)
                {
                    print("game over");
                    
                    activeGameOver = true;
                    destruyendoObjEscena();
                    
                   return true;
                }
               
            }
            
        }
        return false;
    }
    public static void destruyendoObjEscena()
    {
        int countObj = listaObjsEscena.Count;
        for (int i3 = 0; i3 < countObj; i3++)
        {
            Destroy(listaObjsEscena[i3]);
        }
        listaObjsEscena.Clear();

    }
    public static void decreaseRow(int y)
    {
       // print("************decrease row**************");
       // print("y " + y);
        for (int x = 0; x < w; ++x)
        {
            if (grid[y, x] != null)
            {
                // Move one towards bottom
                //arrRows[x] += 1;
                grid[y-1, x] = grid[y, x];
                listaObjs.Add(grid[y, x].gameObject);
                grid[y, x] = null;
            }
        }
    }
   
    public static void decreaseRowsAbove(int y)
    {
        
        for (int i = y; i < h; ++i)
        {
            decreaseRow(i);

        }
       
    }
    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
            if (grid[y, x] == null)
            {
               // print("pos  a evaluar " + grid[y, x]);
                return false;
            }
        return true;
    }

    public static bool deleteFullRows()
    {
        bool entrando=false;
        
        for (int y = 0; y < h; ++y)
        {
            if (isRowFull(y))
            {
                //print("fila llena");
                indiceMatch +=1;
                entrando = true;
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
                score += 10;
                if (score >= targetScore)
                {
                    win = true;
                }
                
                /*if (score >= cambioRitmoJuego)
                {
                    if (cambioRitmoJuego < 1.0f)
                        cambioRitmoJuego += 0.1f;
                }*/
            }
        }
        Move.Moviendo2();
        return entrando;

    }
    
}
