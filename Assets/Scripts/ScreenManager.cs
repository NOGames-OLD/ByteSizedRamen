using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    public GameObject prepPanel;
    public GameObject frontScreen;
    public GameObject cookTop;
    public Cooker[] cookers;
    public GameObject prepScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchToFront()
    {
        cookTop.SetActive(false);
        for (int i = 0; i < cookers.Length; i++)
        {
            cookers[i].SetImages(false);
        }
        prepScreen.SetActive(false);
        frontScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("ScreenChange");
    }

    public void SwitchToCooker()
    {
        cookTop.SetActive(true);
        for (int i = 0; i < cookers.Length; i++)
        {
            cookers[i].SetImages(true);
        }
        prepScreen.SetActive(false);
        frontScreen.SetActive(false);
        FindObjectOfType<AudioManager>().Play("ScreenChange");
    }
    
    public void SwitchToPrep()
    {
        cookTop.SetActive(false);
        for (int i = 0; i < cookers.Length; i++)
        {
            cookers[i].SetImages(false);
        }
        prepScreen.SetActive(true);
        frontScreen.SetActive(false);
        //so toppings are reenabled 
        foreach (Transform child in prepPanel.transform)
    {
        child.gameObject.SetActive(true);
    }
        FindObjectOfType<AudioManager>().Play("ScreenChange");
    }
}
