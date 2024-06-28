using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Puntuacion : MonoBehaviour
{
    public TextMeshProUGUI textoPuntuacionActual;
    public TextMeshProUGUI textoPuntuacionMasAlta;

    private int puntuacionActual = 0;
    private int highScore = 0;
    public Color boxColor= Color.blue;

    public static Puntuacion instancia;

    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        
    }


    private void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }        
        
        instancia = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
        ActualizarUI();
        
    }


    public void AumentarPuntuacion()
    {
        puntuacionActual++;      

        
        if (puntuacionActual >= highScore)
        {
            highScore = puntuacionActual;
            SaveScore();
        }
        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPuntuacionActual.text = "Puntuación: " + puntuacionActual.ToString();
        textoPuntuacionMasAlta.text = "Record: " + highScore.ToString();
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            
        }
    }
}
