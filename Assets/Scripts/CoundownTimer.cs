using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoundownTimer : MonoBehaviour
{
    public float Countdown = 5f;
    public Text text;
    public GameObject CountdownUI; 
    public PlayerCarController PlayerCar1;
    public PlayerCarController PlayerCar2;
    public PlayerCarController PlayerCar3;
    public OpponentCar opponentCar1;
    public OpponentCar opponentCar2;
    public OpponentCar opponentCar3;
    public OpponentCar opponentCar4;
    private void Start()
    {
        StartCoroutine(StartCountdown());
    }
    private void Update()
    {
        if(Countdown > 1)
        {
            PlayerCar1.GetComponent<PlayerCarController>().enabled = false;
            PlayerCar2.GetComponent<PlayerCarController>().enabled = false;
            PlayerCar3.GetComponent<PlayerCarController>().enabled = false;
            opponentCar1.GetComponent<OpponentCar>().enabled = false;
            opponentCar2.GetComponent<OpponentCar>().enabled = false;
            opponentCar3.GetComponent<OpponentCar>().enabled = false;
            opponentCar4.GetComponent<OpponentCar>().enabled = false;
        }
        else if(Countdown == 0)
        {
            PlayerCar1.GetComponent<PlayerCarController>().enabled = true;
            PlayerCar2.GetComponent<PlayerCarController>().enabled = true;
            PlayerCar3.GetComponent<PlayerCarController>().enabled = true;
            opponentCar1.GetComponent<OpponentCar>().enabled = true;
            opponentCar2.GetComponent<OpponentCar>().enabled = true;
            opponentCar3.GetComponent<OpponentCar>().enabled = true;
            opponentCar4.GetComponent<OpponentCar>().enabled = true;
        }
    }
    IEnumerator StartCountdown()
    {
        while (Countdown > 0)
        {
            text.text = Countdown.ToString();
            yield return new WaitForSeconds(1f);
            Countdown--;
        }
        if (Countdown == 0)
        {
            text.text = "GO";
            yield return new WaitForSeconds(2f);
            CountdownUI.SetActive(false);
            
        }
    }
}
