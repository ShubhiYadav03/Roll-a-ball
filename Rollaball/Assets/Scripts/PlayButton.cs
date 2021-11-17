
using UnityEngine;
using TMPro;


public class PlayButton : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TMP_InputField input;
    public TextMeshProUGUI winText;
    public GameObject canvas;
    public GameObject player;

    // Start is called before the first frame update
    public void getValue()
    {
        string user = username.text; //here the value is "a"
        winText.text = $"Congrats {user}!\n You Win!!";
        player.SetActive(true);
        canvas.SetActive(false);
    }
}
