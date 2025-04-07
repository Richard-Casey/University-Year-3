
public class PlayerAssignment : MonoBehaviour
{
    public enum PlayerClass
    {
        Melee,
        Range,
        AOE
    }

    public enum PlayerRole
    {
        Rescuer,
        Terroriser,
        Hacker
    }

    public PlayerClass playerClass;
    public PlayerRole playerRole;

    public TextMeshProUGUI classText;
    public TextMeshProUGUI roleText;


    void Start()
    {
        if (!GameManager.Instance.isClassAndRoleAssigned)
        {
            // Randomly assign a class and role
            playerClass = (PlayerClass)Random.Range(0, System.Enum.GetValues(typeof(PlayerClass)).Length);
            playerRole = (PlayerRole)Random.Range(0, System.Enum.GetValues(typeof(PlayerRole)).Length);

            GameManager.Instance.AssignClassAndRole(playerClass, playerRole);
        }
        else
        {
            playerClass = GameManager.Instance.playerClass;
            playerRole = GameManager.Instance.playerRole;
        }

        classText.text = "Class: " + playerClass.ToString();
        roleText.text = "Role: " + playerRole.ToString();
    }

}