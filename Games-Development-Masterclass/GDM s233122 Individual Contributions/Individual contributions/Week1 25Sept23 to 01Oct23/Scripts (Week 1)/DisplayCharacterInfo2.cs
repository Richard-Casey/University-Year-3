using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCharacterInfo : MonoBehaviour
{
    public TextMeshProUGUI classText;
    public TextMeshProUGUI roleText;
    // public Image characterImage;

    void Start()
    {
        // Retrieve the assigned role and class from the GameManager
        PlayerAssignment.PlayerClass assignedClass = GameManager.Instance.playerClass;
        PlayerAssignment.PlayerRole assignedRole = GameManager.Instance.playerRole;

        // Update the UI
        classText.text = "Class: " + assignedClass.ToString();
        roleText.text = "Role: " + assignedRole.ToString();

        // If we were to add an image of the character we could update that as well
        // characterImage.sprite = GetCharacterSprite(assignedClass, assignedRole);
    }

    //This function would retrieve the sprite based on the class and role
    // Sprite GetCharacterSprite(PlayerAssignment.PlayerClass pClass, PlayerAssignment.PlayerRole pRole)
    //{
    //}
}