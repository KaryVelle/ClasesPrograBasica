using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Operadores : MonoBehaviour
{
    [SerializeField] private GameObject[] sonics;
    [SerializeField] private int currentSonic = 0; // empieza en 0

    [SerializeField] private TMP_InputField masInput;
    [SerializeField] private TMP_InputField menosInput;

    [SerializeField] public Image sonikBoolImg;
    [SerializeField] private Sprite siHaySoniks;
    [SerializeField] private Sprite noHaySoniks;
    [SerializeField] private bool haySoniks;
    [SerializeField] private TextMeshProUGUI tmpHaySoniks;

    [SerializeField] private TextMeshProUGUI tmpCuantos;

    /// <summary>
    /// Esta función sirve para usar el operador aritmético ++.
    /// Como puedes ver, suma de 1 en 1, sin requierir otro dato.
    /// </summary>
    public void MasMas()
    {
        //Operador logico < comprueba si la cantidad actual de sonics (current Sonic que es un int) o numero entero
        //es menor que la cantidad total de sonics (en este caso 12) que es sonics.Lenght (forma de acceder a la caja en la que guardamos a los sonics)
        
        if (currentSonic < sonics.Length)
        {
            // Esto apaga al sonic actual (si es el 1, apaga al 1, si es el 3 apaga al 3)
            sonics[currentSonic].SetActive(true);
            //Aquí se realiza la suma de 1 en 1.
            currentSonic++;
        }
        else
        {
            Debug.Log("<color=blue>Ya no cabe otro Sonic!!!</color>");
        }
        HaySoniks();
        Cuantos();
    }
   
    public void MenosMenos()
    {
        if (currentSonic > 0)
        {
            currentSonic--;
            sonics[currentSonic].SetActive(false);
        }
        else
        {
            Debug.Log("<color=red>No puedes quitar más Sonics!</color>");
        }
        HaySoniks();
        Cuantos();
    }

    public void Suma()
    {
        var cantidadDeSonics = int.Parse(masInput.text);

        for (var i = 0; i < cantidadDeSonics && currentSonic < sonics.Length; i++)
        {
            sonics[currentSonic].SetActive(true);
            currentSonic++; 
        }
        HaySoniks();
        Cuantos();
    }
   
    public void Resta()
    {
        var cantidadDeSonics = int.Parse(menosInput.text);

        for (var i = 0; i < cantidadDeSonics && currentSonic > 0; i++)
        {
            currentSonic--; 
            sonics[currentSonic].SetActive(false);
        }

        if (currentSonic == 0)
        {
            Debug.Log("<color=red>Ya apagaste todos los Sonics!!!</color>");
        }
        HaySoniks();
        Cuantos();
    }

    private void HaySoniks()
    {
        if (currentSonic > 0)
        {
            haySoniks = true;
            sonikBoolImg.sprite = siHaySoniks;
            tmpHaySoniks.text = "Zi";
        }

        if (currentSonic == 0)
        {
            haySoniks = false;
            sonikBoolImg.sprite = noHaySoniks;
            tmpHaySoniks.text = "No";
        }
    }

    private void Cuantos()
    {
        tmpCuantos.text = currentSonic.ToString();
    }
}