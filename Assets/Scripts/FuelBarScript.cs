using UnityEngine;
using UnityEngine.UI;

public class FuelBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxFuelSlider (int amount)
    {
        //this is called when you buy a bigger canister to hold fuel
        slider.maxValue = amount;
        slider.value = amount;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetFuelSlider(int amount)
    {
        //this is the regular call function to update the "animation" of fuel
        slider.value = amount;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
