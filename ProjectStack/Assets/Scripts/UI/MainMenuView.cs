using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SDA.UI
{
    public class MainMenuView : BaseView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _bestScoreText;

        public void UpdatePoints(int points)
        {
            _scoreText.text = $"{points}";
        }

        public void UpdateBestScore(int points)
        {

        }
    }
}