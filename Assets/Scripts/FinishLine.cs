using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject PlayerUI;
    public GameObject FinishUI;
    public GameObject PlayerCar;

    public Text Status;

    private void Start()
    {
        StartCoroutine(StartFinishTimer());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FinishlineTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;

            Status.text = "You Won";
            Status.color = Color.black;
        }
        else if (other.gameObject.tag == "OpponentCar")
        {
            StartCoroutine(FinishlineTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;

            Status.text = "You Lose";
            Status.color = Color.red;
        }
    }

    IEnumerator StartFinishTimer()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    IEnumerator FinishlineTimer()
    {
        FinishUI.SetActive(true);
        PlayerUI.SetActive(false);
        PlayerCar.SetActive(false);
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }
}
