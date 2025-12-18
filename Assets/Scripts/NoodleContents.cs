using UnityEngine;

public class NoodleContents : MonoBehaviour
{
    public SauceType sauce = SauceType.None;
    public ToppingFlags toppings = ToppingFlags.None;

    public void SetSauce(SauceType newSauce)
    {
        sauce = newSauce;
    }

    public void ToggleTopping(ToppingFlags topping)
    {
        if ((toppings & topping) == topping)
        {
            // Already on → remove
            toppings &= ~topping;
        }
        else
        {
            // Add
            toppings |= topping;
        }
    }
}
