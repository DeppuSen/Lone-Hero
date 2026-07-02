using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    // Variables untuk menyimpan data game
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    public int MaxItems = 4;

    // Referensi UI
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public Button WinButton;
    public TMP_Text ProgressText;

    void Start()
    {
        ItemText.text = "Items: " + _itemsCollected;
        HealthText.text = "Health: " + _playerHP;

        if (WinButton != null)
            WinButton.gameObject.SetActive(false);
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            ItemText.text = "Items: " + _itemsCollected;

            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";
                if (WinButton != null)
                    WinButton.gameObject.SetActive(true);
                Time.timeScale = 0f; // Pause game
            }
            else
            {
                int remaining = MaxItems - _itemsCollected;
                ProgressText.text = "Item found, only " + remaining + " more to go!";
            }
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: " + _playerHP;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}