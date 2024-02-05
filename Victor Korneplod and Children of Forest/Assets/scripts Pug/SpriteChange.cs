using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    
    public Button button; 
    public Image childImage; 
    public Sprite inactiveSprite; 
    public Sprite activeSprite; 
    public ButtonManager buttonManager; 

    void Start()
    {
        
        buttonManager.RegisterButton(button, childImage, inactiveSprite, activeSprite);

        
        button.onClick.AddListener(() => buttonManager.OnButtonClicked(button));
    }

}