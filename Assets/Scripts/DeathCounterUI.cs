using UnityEngine;
using TMPro;

public class DeathCounterUI : MonoBehaviour
{
    public TextMeshProUGUI deathText;

    void Update()
    {
        if (DeathCounterManager.Instance != null)
        {
            deathText.text = "Deaths: " + DeathCounterManager.Instance.deathCount;
        }
    }
}
