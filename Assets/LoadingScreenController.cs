using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreenController : MonoBehaviour
{
    //public string sceneToLoad; // Naziv scene koju želite uèitati
    //public Image progressBar;   // Referenca na Image komponentu koja predstavlja progress bar
    //public float fillSpeed = 0.1f; // Brzina punjenja slike (0.5f znaèi da æe se popuniti za 2 sekunde)

    //private float currentFill = 0f; // Trenutni napredak punjenja

    //void Start()
    //{
    //    StartCoroutine(LoadAsyncScene());
    //}

    //IEnumerator LoadAsyncScene()
    //{
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

    //    // Sprijeèite automatsko prelazak na novu scenu kada se uèitavanje završi
    //    asyncLoad.allowSceneActivation = false;

    //    while (!asyncLoad.isDone || currentFill < 1.0f)
    //    {
    //        // Ažurirajte UI elemente koji prikazuju napredak
    //        currentFill += Time.deltaTime * fillSpeed;
    //        progressBar.fillAmount = currentFill; // Postavite sliku na trenutni napredak

    //        // Aktivirajte novu scenu kada je uèitavanje gotovo
    //        if (currentFill >= 1.0f)
    //        {
    //            asyncLoad.allowSceneActivation = true;
    //        }

    //        yield return null;
    //    }
    //}

    ////////////

    //public string sceneToLoad; // Naziv scene koju želite uèitati
    //public Image[] progressBar; // Niz Image komponenata koje predstavljaju progress bar
    //public float fillSpeed = 0.5f; // Brzina punjenja slika (0.5f znaèi da æe se popuniti za 2 sekunde)

    //private float currentFill = 0f; // Trenutni napredak punjenja

    //void Start()
    //{
    //    StartCoroutine(LoadAsyncScene());
    //}

    //IEnumerator LoadAsyncScene()
    //{
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

    //    // Sprijeèite automatsko prelazak na novu scenu kada se uèitavanje završi
    //    asyncLoad.allowSceneActivation = false;

    //    while (!asyncLoad.isDone || currentFill < 1.0f)
    //    {
    //        // Ažurirajte UI elemente koji prikazuju napredak
    //        currentFill += Time.deltaTime * fillSpeed;

    //        foreach (Image img in progressBar)
    //        {
    //            img.fillAmount = currentFill; // Postavite svaku sliku na trenutni napredak
    //        }

    //        // Aktivirajte novu scenu kada je uèitavanje gotovo
    //        if (currentFill >= 1.0f)
    //        {
    //            asyncLoad.allowSceneActivation = true;
    //        }

    //        yield return null;
    //    }
    //}

    public string sceneToLoad; // Naziv scene koju želite uèitati
    public Image[] progressBar; // Niz Image komponenata koje predstavljaju progress bar
    public TextMeshProUGUI progressText; // Referenca na TextMeshProUGUI komponentu za prikaz procenta
    public float fillSpeed = 1f; // Brzina punjenja slika (0.5f znaèi da æe se popuniti za 2 sekunde)
    public Image background; // Referenca na Image komponentu za pozadinsku sliku

    private float currentFill = 0f; // Trenutni napredak punjenja

    private Color[] backgroundColors = {
        Color.blue, Color.green, Color.white, Color.yellow, Color.red, new Color(1.0f, 0.5f, 0f) // Narandžasta
    };

    private int currentColorIndex = 0; // Trenutni indeks boje

    void Start()
    {
        StartCoroutine(LoadAsyncScene());
        StartCoroutine(ChangeBackgroundColor());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Sprijeèite automatsko prelazak na novu scenu kada se uèitavanje završi
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone || currentFill < 1.0f)
        {
            // Ažurirajte UI elemente koji prikazuju napredak
            currentFill += Time.deltaTime * fillSpeed;

            foreach (Image img in progressBar)
            {
                img.fillAmount = currentFill; // Postavite svaku sliku na trenutni napredak
            }

            // Ažurirajte tekstualni prikaz procenta sa tri decimalna mesta
            string progressPercentage = (currentFill * 100).ToString("0.000") + " %";
            progressText.text = progressPercentage;

            // Aktivirajte novu scenu kada je uèitavanje gotovo
            if (currentFill >= 1.0f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    IEnumerator ChangeBackgroundColor()
    {
        while (true)
        {
            background.color = backgroundColors[currentColorIndex]; // Postavite trenutnu boju pozadinske slike
            currentColorIndex = (currentColorIndex + 1) % backgroundColors.Length; // Poveæajte indeks boje

            yield return new WaitForSeconds(1.8f); // Saèekajte 2 sekunde pre promene boje
        }
    }
}
