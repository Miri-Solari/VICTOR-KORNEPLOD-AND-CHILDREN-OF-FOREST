using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    
    private Dictionary<Image, (Sprite inactive, Sprite active)> imageSprites = new Dictionary<Image, (Sprite, Sprite)>();

    
    private Dictionary<Button, Image> buttonToImage = new Dictionary<Button, Image>();

    public void RegisterButton(Button button, Image childImage, Sprite inactive, Sprite active)
    {
        buttonToImage[button] = childImage;
        imageSprites[childImage] = (inactive, active);
    }

    public void OnButtonClicked(Button clickedButton)
    {
        foreach (var pair in buttonToImage)
        {
            if (pair.Key == clickedButton)
            {
                
                pair.Value.sprite = imageSprites[pair.Value].active;
            }
            else
            {
                
                pair.Value.sprite = imageSprites[pair.Value].inactive;
            }
        }
    }
}