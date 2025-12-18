using UnityEngine;

public class PrepStation : MonoBehaviour
{
    public Prep prep;                     // existing Prep script
    public CustomerManager customerManager;

    private NoodleContents CurrentContents
    {
        get
        {
            if (prep == null || prep.currentNoodles == null) return null;
            return prep.currentNoodles.GetComponent<NoodleContents>();
        }
    }

    // Called by UI buttons to set sauce
    public void SelectSauce(int sauceIndex)
    {
        NoodleContents contents = CurrentContents;
        if (contents == null) return;

        contents.SetSauce((SauceType)sauceIndex);

    }

    // Called by UI buttons to toggle toppings
    public void ToggleTopping(int toppingIndex)
    {
        NoodleContents contents = CurrentContents;
        if (contents == null) return;

        ToppingFlags chosen = ToppingFlags.None;

        switch (toppingIndex)
        {
            case 0: chosen = ToppingFlags.Egg; break;
            case 1: chosen = ToppingFlags.Shrimp; break;
            case 2: chosen = ToppingFlags.Seaweed; break;
        }

        if (chosen != ToppingFlags.None)
        {
            contents.ToggleTopping(chosen);
        }
    }
}
