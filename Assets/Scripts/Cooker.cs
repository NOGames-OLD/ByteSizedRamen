using Unity.Mathematics;
using UnityEngine;

public class Cooker : MonoBehaviour
{

    public ScreenManager screenManager;
    public GameObject noodlesPrefab;
    Noodles myNoodles;
    public Prep prep;
    public GameObject[] buttonsToSetInactive;


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
        }
    }
    
    public void SendNoodlesToPrep()
    {
        if (prep.currentNoodles == null)
        {
            myNoodles.isCooking = false;
            prep.AddNoodles(myNoodles);
            myNoodles = null;
            screenManager.SwitchToPrep();
            for (int i = 0; i < buttonsToSetInactive.Length - 1; i++)
            {
                buttonsToSetInactive[i].SetActive(false);
            }
            buttonsToSetInactive[buttonsToSetInactive.Length - 1].SetActive(true);
        }
    }
}
