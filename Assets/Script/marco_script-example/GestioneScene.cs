using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestioneScene : MonoBehaviour
{
    [SerializeField] private List<GestioneScene> SceneConnesse;

    public bool ScenaCaricata {  get; private set; }


    private void OnTriggerEnter2D(Collider2D collisione)
    {
        if (collisione.tag == "Player")
        {
            CaricaScena();
            GameController.Instance.ImpostaScenaAttuale(this);

            foreach (var scena in SceneConnesse)
            {
                scena.CaricaScena();
            }

            if (GameController.Instance.scenaPrecedente != null)
            {
                var sceneDaRimuovere = GameController.Instance.scenaPrecedente.SceneConnesse;
                foreach (var scena in sceneDaRimuovere)
                {
                    RimuoviScena();
                }
            }
        }
    }

    public void CaricaScena()
    {
        if (!ScenaCaricata)
        {
            SceneManager.LoadSceneAsync(gameObject.name,LoadSceneMode.Additive);
            ScenaCaricata = true;
        }
    }

    public void RimuoviScena()
    {
        if (ScenaCaricata)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            ScenaCaricata = false;
        }
    }
}
