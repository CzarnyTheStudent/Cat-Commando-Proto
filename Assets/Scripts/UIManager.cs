using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject DeathScreen;

    public void ToogleDeathScreen()
    {
        DeathScreen.SetActive(!DeathScreen.activeSelf);
    }
}
