using UnityEngine;
using UnityEngine.UI;

public class MuteMusicButton : MonoBehaviour
{
    public Button button;          // UI dugme
    public Sprite mutedSprite;     // slika kad je mute
    public Sprite unmutedSprite;   // slika kad je uključeno
    private Image buttonImage;
    
    private MusicManager musicManager;

    void Start()
    {
        musicManager = MusicManager.Instance;  // Singleton
        buttonImage = button.GetComponent<Image>();
        UpdateVisual();

        button.onClick.AddListener(ToggleMute);
    }

    void ToggleMute()
    {
        if (musicManager != null)
        {
            musicManager.audioSource.mute = !musicManager.audioSource.mute;
            UpdateVisual();
        }
    }

    void UpdateVisual()
    {
        if (musicManager.audioSource.mute)
            buttonImage.sprite = mutedSprite;
        else
            buttonImage.sprite = unmutedSprite;
    }
}
