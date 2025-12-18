using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Cooker : MonoBehaviour
{

    public ScreenManager screenManager;
    public GameObject noodlesPrefab;
    Noodles myNoodles;
    public Prep prep;
    public GameObject offButton;
    public GameObject onButton;
    public GameObject prepButton;
    public GameObject wok;
    public GameObject addNoodlesButton;
    bool isNowCooking;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddNoodles()
    {
        myNoodles = Instantiate(noodlesPrefab, transform.position, quaternion.identity, this.transform).GetComponent<Noodles>();
    }

    public void SetNoodleCooking(bool isCooking)
    {
        if (myNoodles != null)
        {
            myNoodles.SetCooking(isCooking);
            isNowCooking = isCooking;
            if(myNoodles.isCooking==true)
            {
                FindObjectOfType<AudioManager>().Play("StoveNoise");
                FindObjectOfType<AudioManager>().PlayDelayed("BoilingWater",1f);
            }
            else
            {
                FindObjectOfType<AudioManager>().Stop("StoveNoise");
                FindObjectOfType<AudioManager>().Stop("BoilingWater");
            }
        }
    }
    
    public void SendNoodlesToPrep()
    {
        if (prep.currentNoodles == null)
        {
            myNoodles.isCooking = false;
            isNowCooking = false;
            prep.AddNoodles(myNoodles);
            myNoodles = null;
            //SetImages(true);
            screenManager.SwitchToPrep();
            FindObjectOfType<AudioManager>().Stop("StoveNoise");
            FindObjectOfType<AudioManager>().Stop("BoilingWater");
        }
    }

    public void SetImages(bool state)
    {
        if(myNoodles != null){
            myNoodles.GetComponent<Image>().enabled = state;
            if (isNowCooking)
            {
                offButton.SetActive(state);
            }
            else
            {
                onButton.SetActive(state);
            }
            wok.SetActive(state);
            prepButton.SetActive(state);
        }
        else
        {   
            addNoodlesButton.SetActive(state);
            if(state == false)
            {
                Debug.Log("Hello");
                offButton.SetActive(state);
                onButton.SetActive(state);
                prepButton.SetActive(state);
                wok.SetActive(false);
            }
        }
    }
}
