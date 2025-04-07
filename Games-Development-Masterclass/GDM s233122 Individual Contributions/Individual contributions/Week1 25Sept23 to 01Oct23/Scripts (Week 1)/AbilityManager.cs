        }
    }

    private void Update()
{
    if (Input.GetKeyDown(KeyCode.U))
    {
        ActivateAbility(0, this.gameObject);
    }
    else if (Input.GetKeyDown(KeyCode.I))
    {
        ActivateAbility(1, this.gameObject);
    }
    else if (Input.GetKeyDown(KeyCode.O))
    {
        ActivateAbility(2, this.gameObject);
    }
    else if (Input.GetKeyDown(KeyCode.P))
    {
        ActivateAbility(3, this.gameObject);
    }
    else if (Input.GetKeyDown(KeyCode.H))
    {
        ActivateAbility(4, this.gameObject);
    }
    else if (Input.GetKeyDown(KeyCode.J))
    {
        ActivateAbility(5, this.gameObject);
    }
    else if (Input.GetKeyDown(KeyCode.K))
    {
        ActivateAbility(6, this.gameObject);
    }
    else if (Input.GetKeyDown(KeyCode.L))
    {
        ActivateAbility(7, this.gameObject);
    }
}

public void ActivateAbility(int index, GameObject user)
{
    if (abilities[index] != null)