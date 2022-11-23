using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Tetronimo
{
    C, L, J, S, T, Z, I
}
public class TestGroup : MonoBehaviour
{

    public Vector3 puntoAnclaje;
    float lastFall = 0;
    private Tetronimo pieza;
    private float velocity = 10;
    private float time=0;
   
    void Start()
    {
        /*if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            //Destroy(gameObject);
        }*/
       

    }

   
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
//        print("time " + time);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if it's valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // Its not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
            }

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.Rotate(0, 0, -90);
            transform.RotateAround(transform.TransformPoint(puntoAnclaje), new Vector3(0, 0, 1), -90);
            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.RotateAround(transform.TransformPoint(puntoAnclaje), new Vector3(0, 0, 1), 90);
            }

        }
        else if (Input.GetKey(KeyCode.DownArrow) || Time.time - lastFall >= 1 - TestPlayField.cambioRitmoJuego)
        {
            // Modify position
           
            if (Input.GetKey(KeyCode.DownArrow))
            {
                
                if (isValidGridPos())
                {
                    if (time > 0.1f)
                    {

                        transform.position += new Vector3(0, -1, 0);
                        time = 0;
                    }
                }
                else
                {
                    transform.position -= new Vector3(0, 1*velocity*Time.deltaTime, 0);

                }
               

            }
            else
            {
                transform.position += new Vector3(0, -1, 0);

            }
            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                TestPlayField.deleteFullRows();

                if (!TestPlayField.gameOver()||!TestPlayField.win)
                {
                    FindObjectOfType<SpawnerNobutu>().spawnNext();
                }

                
              
                
                
                // Disable script
               
                enabled = false;
            }
            lastFall = Time.time;
        }
        
    }
        bool isValidGridPos()
        {
            foreach (Transform child in transform)
            {
                Vector2 v = TestPlayField.roundVec2(child.position);

           
                // Not inside Border?
                if (!TestPlayField.insideBorder(v))
                    return false;

                // Block in grid cell (and not part of same group)?
                if (TestPlayField.grid[(int)v.y, (int)v.x] != null &&
                    TestPlayField.grid[(int)v.y, (int)v.x].parent != transform)
                    return false;
            }
            return true;
        }
        void updateGrid()
        {
            // Remove old children from grid
            for (int y = 0; y < TestPlayField.h; ++y)
                for (int x = 0; x < TestPlayField.w; ++x)
                    if (TestPlayField.grid[y, x] != null)
                        if (TestPlayField.grid[y, x].parent == transform)
                            TestPlayField.grid[y, x] = null;

            // Add new children to grid
            foreach (Transform child in transform)
            {
                Vector2 v = TestPlayField.roundVec2(child.position);
                TestPlayField.grid[(int)v.y, (int)v.x] = child;
            
                 //print("****pos a updatiar***** ");
                //print("x " + v.x + " y " + v.y);
                //print("child " + child.name);
            }
        }
    
    }

