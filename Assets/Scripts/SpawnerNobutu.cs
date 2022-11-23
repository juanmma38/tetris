using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNobutu : MonoBehaviour
{ public GameObject[] groups;
    private Tetronimo piezaProxima;
    private Tetronimo piezaActual;
    private bool active = false;
   GameObject spawnNextBase;
    void Start()
    {
        //(int)piezaActual
        piezaActual = (Tetronimo)Random.Range(0, System.Enum.GetNames(typeof(Tetronimo)).Length);
        spawnNextBase=GameObject.FindGameObjectWithTag("spawnNext");
        GameObject obj=Instantiate(groups[(int)piezaActual], transform.position, Quaternion.identity);
        TestPlayField.listaObjsEscena.Add(obj);
        piezaProxima= (Tetronimo)Random.Range(0, System.Enum.GetNames(typeof(Tetronimo)).Length);
        spawnNextBase.transform.GetChild((int)piezaProxima).gameObject.SetActive(true);

    }
    public void InstancePiece()
    {
        GameObject obj=Instantiate(groups[(int)piezaProxima], transform.position, Quaternion.identity);
        TestPlayField.listaObjsEscena.Add(obj);
        spawnNextBase.transform.GetChild((int)piezaProxima).gameObject.SetActive(false);//apago el q estaba
        piezaProxima = (Tetronimo)Random.Range(0, System.Enum.GetNames(typeof(Tetronimo)).Length);//genero spawn net
        
        spawnNextBase.transform.GetChild((int)piezaProxima).gameObject.SetActive(true);//muestro el sapwn next
    }
   
    public void spawnNext()
    {

        if (active == false)
        { 
            active = true;
      
            InstancePiece();
        }
        else
        {      
            active = false;
        
            InstancePiece();

        }
    }
    public GameObject getSpawnNext
    {
        set{ spawnNextBase = value; }
        get { return spawnNextBase;}
    }
}
