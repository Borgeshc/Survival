using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerStates playerStates;

    private void Start()
    {
        playerStates = GetComponent<PlayerStates>();
    }

    private void Update()
    {
        SetPlayerStates();
    }

    void SetPlayerStates()
    {
        playerStates.moveHorizontal = controls.Move.X;
        playerStates.moveVertical = controls.Move.Y;
        playerStates.lookHorizontal = controls.Look.X;
        playerStates.lookVertical = controls.Look.Y;
        playerStates.isIdle = !controls.Move;
        playerStates.isMoving = controls.Move;

        if(!playerStates.isIdle)
            playerStates.isSprinting = controls.Sprint;
    }
    #region SetUpBindings

    Controls controls;
    string saveData;

    void OnEnable()
    {
        controls = Controls.CreateWithDefaultBindings();
    }

    void OnDisable()
    {
        controls.Destroy();
    }

    void SaveBindings()
    {
        saveData = controls.Save();
        PlayerPrefs.SetString("Bindings", saveData);
    }

    void LoadBindings()
    {
        if (PlayerPrefs.HasKey("Bindings"))
        {
            saveData = PlayerPrefs.GetString("Bindings");
            controls.Load(saveData);
        }
    }
    #endregion
}
