using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GestioneSalvataggi : MonoBehaviour
{
    public static GestioneSalvataggi Istanza;

    public PlayerController Giocatore;

    private void Awake()
    {
        if (Istanza == null)
        {
            Destroy(gameObject);
            return;
        }

        Istanza = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SalvaDati
    {
        public PlayerController Giocatore;
    }

    public void Salva()
    {
        SalvaDati salvataggio = new SalvaDati();
        salvataggio.Giocatore = Giocatore;

        string json = JsonUtility.ToJson(salvataggio);

        File.WriteAllText(Application.persistentDataPath + "/salvataggio.json", json);
    }

    public void Carica()
    {
        string percorso = Application.persistentDataPath + "/salvataggio.json";
        if (File.Exists(percorso))
        {
            string json = File.ReadAllText(percorso);
            SalvaDati dati = JsonUtility.FromJson<SalvaDati>(json);

            Giocatore = dati.Giocatore;
        }
    }
}
