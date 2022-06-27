using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SDA.UI
{
    public class GameView : BaseView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        public void UpdateScore(int points)
        {
            _scoreText.text = $"{points}";
        }
    }
}
