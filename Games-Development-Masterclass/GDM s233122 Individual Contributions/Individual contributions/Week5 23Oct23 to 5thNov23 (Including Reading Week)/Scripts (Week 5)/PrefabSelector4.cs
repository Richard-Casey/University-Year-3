using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrefabSelector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Customisation customisationScript; // Reference to the Customisation script
    public int index; // This should be set in the Unity Editor for each prefab
    public Image prefabImage;

    public GameObject padlockOverlay;
    public static TextMeshProUGUI lockedText;

    private void Start()
    {
        customisationScript.OnPrefabSelected += UpdateAlphaBasedOnSelection;

        // Initialize the alpha based on whether this prefab is the currently selected one
        if (index == customisationScript.GetCurrentPlayerIndex())
        {
            SetAlpha(255);
        }
        else
        {
            SetAlpha(180);
        }

        if (customisationScript.IsPrefabUnlocked((index)))
        {
            SetAlpha(255);
            SetRGB(255);
        }
        else
        {
            SetAlpha(180);
            SetRGB(65);
        }

        if (lockedText == null)
        {
            lockedText = GameObject.Find("CustomisationCanvas/LockedText").GetComponent<TextMeshProUGUI>();
            if (lockedText == null)
            {
                Debug.LogError("LockedText GameObject not found. Make sure it exists and the name matches.");
            }
        }

        if (customisationScript == null)
        {
            Debug.LogError("Customisation script is not assigned!");
            return;
        }

        if (lockedText == null)
        {
            Debug.LogError("LockedText is not assigned!");
            return;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
            customisationScript.SelectPrefab(index);
            SetAlpha(255);
    AudioManager.instance.PlayUIClick();
            lockedText.gameObject.SetActive(false);
        }
        else
{
    Debug.Log("This prefab is locked.");
    lockedText.text = "Item is locked, find it in game to unlock";
    lockedText.gameObject.SetActive(true);
}
    }

        {
    SetAlpha(255);
    SetRGB(255);
    padlockOverlay.SetActive(false);
}
        else
{
    SetAlpha(180);
    SetRGB(65);
    padlockOverlay.SetActive(true);
}
    }
