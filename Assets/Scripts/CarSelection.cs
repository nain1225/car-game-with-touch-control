using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    public Button NextButton;
    public Button PreviousButton;

    private int currentCar;
    public GameObject[] carList;

    [Header("Skip button variations")]
    public GameObject GarageCanvas;
    public GameObject playbutton;
    public GameObject skipButton;
    public GameObject cam1;
    //public Animator animator;
    public GameObject cam2;

    private void Awake()
    {
        cam2.SetActive(false);
        playbutton.SetActive(false);
        cam1.SetActive(true);
        skipButton.SetActive(true);
        GarageCanvas.SetActive(false);

        ChooseCar(0);
    }
    private void Start()
    {
        StartCoroutine(DeactiveButton());

        currentCar = PlayerPrefs.GetInt("CarSelected");
        carList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }
        foreach (var item in carList)
        {
            item.SetActive(false);
        }
        if (carList[currentCar])
        {
            carList[currentCar].SetActive(true);
        }
        
    }
    private void Update()
    {

    }
    public void ChooseCar(int index)
    {
        NextButton.interactable = (currentCar != transform.childCount - 1);
        PreviousButton.interactable = (currentCar != 0);

        for(int i = 0; i <= transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }
    public void SwitchCars(int switchCar)
    {
        currentCar += switchCar;
        ChooseCar(currentCar);
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("CarSelected", currentCar);
        SceneManager.LoadScene("scene_day");
    }
    public void onSkipButton()
    {
        cam2.SetActive(true);
        playbutton.SetActive(true);
        cam1.SetActive(false);
        skipButton.SetActive(false);
        GarageCanvas.SetActive(true);
    }
    IEnumerator DeactiveButton()
    {
        skipButton.SetActive(false);
        playbutton.SetActive(true);

        yield return new WaitForSeconds(3f);
    }
}
