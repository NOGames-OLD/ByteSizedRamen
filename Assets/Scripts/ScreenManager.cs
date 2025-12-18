using UnityEngine;

public class ScreenManager : MonoBehaviour
{


    public GameObject frontScreen;
    public GameObject cookerScreen;
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
        cookerScreen.SetActive(false);
        prepScreen.SetActive(false);
        frontScreen.SetActive(true);
    }

    public void SwitchToCooker()
    {
        cookerScreen.SetActive(true);
        prepScreen.SetActive(false);
        frontScreen.SetActive(false);
    }
    
    public void SwitchToPrep()
    {
        cookerScreen.SetActive(false);
        prepScreen.SetActive(true);
        frontScreen.SetActive(false);
    }
}
