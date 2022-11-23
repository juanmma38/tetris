using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ui : MonoBehaviour
{
    GameObject lateral;
    public GameObject pantallaPerder;
    public GameObject pantallaWin;
    public Button butonPlayAgain;
    public Button butonExit;
    public Button butonNextLevel;
    public Button butonExitWin;
    SpawnerNobutu obj; 

    void Start()
    {
        lateral= GameObject.FindGameObjectWithTag("lateral");
        
       
   
        butonPlayAgain.onClick.AddListener(VolverAjugar);
        butonExit.onClick.AddListener(Exit);
        butonNextLevel.onClick.AddListener(NextLevel);
        butonExitWin.onClick.AddListener(ExitWin);
        obj= GetComponent<SpawnerNobutu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TestPlayField.activeGameOver)
        {
            pantallaPerder.SetActive(true);
            lateral.SetActive(false);
            obj.getSpawnNext.SetActive(false);
            TestPlayField.destruyendoObjEscena();
            TestPlayField.activeGameOver = false;


        }
        if (TestPlayField.win)
        {
            TestPlayField.destruyendoObjEscena();
            pantallaWin.SetActive(true);
            lateral.SetActive(false);
            obj.getSpawnNext.SetActive(false);
            TestPlayField.win = false;
        }
        
    }
    public void VolverAjugar()
    {
        print("volver a jugar");
        lateral.SetActive(true);
        obj.getSpawnNext.SetActive(true);
        TestPlayField.score = 0;
        TestPlayField.cambioRitmoJuego = 0;
        pantallaPerder.SetActive(false);
        obj.spawnNext();
        print("cantidad de objs " + TestPlayField.listaObjs.Count);
        
    }
    public void Exit()
    {
        print("exit");
    }
    public void NextLevel()
    {
        print("next level");
    }
    public void ExitWin()
    {
        print("exit win");
    }
}
