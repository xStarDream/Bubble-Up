using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpostazioniGlobali : MonoBehaviour
{
    [SerializeField] Color coloreSfondoSelezionato;
    [SerializeField] Color coloreTestoSelezionato;

    public Color ColoreSfondoSelezionato { get => coloreSfondoSelezionato; set => coloreSfondoSelezionato = value; }
    public Color ColoreTestoSelezionato { get => coloreTestoSelezionato; set => coloreTestoSelezionato = value; }

    public static ImpostazioniGlobali Istanza { get; private set; }

    private void Awake()
    {
        Istanza = this;
    }
}
