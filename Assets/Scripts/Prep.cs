using UnityEngine;

public class Prep : MonoBehaviour
{

    public ScreenManager screenManager;
    public Noodles currentNoodles;
    public Front front;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddNoodles(Noodles newNoodles)
    {
        newNoodles.transform.SetParent(this.transform);
        newNoodles.transform.position = this.transform.position;
        currentNoodles = newNoodles;
    }
    
    public void FinishOrder()
    {
        if (front.currentNoodles == null)
        {
            front.SendNoodleToFront(currentNoodles);
            screenManager.SwitchToFront();
        }
    }
}
