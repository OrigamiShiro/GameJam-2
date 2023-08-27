using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private int _playerScore = 0;

    private void Update()
    {
        _score.text = _playerScore.ToString();
    }

    private void ResetScore()
    {
        _playerScore = 0;
    }
}
