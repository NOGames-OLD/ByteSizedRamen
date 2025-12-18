using UnityEngine;
using UnityEngine.UI;

public class Noodles : MonoBehaviour
{

    public Image myImage;
    public Color uncooked;
    public Color cooked;
    public Color burnt;
    public Vector2 cookingRange;
    public float maxCookingTime;
    public float maxBurningTime;
    public float cookingTime;
    public float burningTime;
    public bool isCooking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cookingTime = Random.Range(cookingRange.x, cookingRange.y);
        burningTime = cookingTime / 2f;
        maxCookingTime = cookingTime;
        maxBurningTime = burningTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking)
        {
            if (cookingTime <= 0)
            {
                burningTime -= Time.deltaTime;
                myImage.color = Color.Lerp(burnt, cooked, burningTime / maxBurningTime);
            }
            else
            {
                cookingTime -= Time.deltaTime;
                myImage.color = Color.Lerp(cooked, uncooked, cookingTime / maxCookingTime);
            }
        }
    }
    
    public void SetCooking(bool newIsCooking)
    {
        isCooking = newIsCooking;
    }

    public void SetCookingTime(float time)
    {
        if(time < cookingTime){
            myImage.color = Color.Lerp(uncooked, cooked, time / maxCookingTime);
        }
        else
        {
            myImage.color = Color.Lerp(burnt, cooked, (time - cookingTime) / maxBurningTime);
        }
    }
}
