using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private float _score = 0.0f;
    private float _minMultiplier = 1.0f;
    private float _multiplier = 1f;
    private float _maxMultiplier = 5.0f;
    private float _scoreForEnemy = 100f;
    
    [SerializeField] private TextMeshProUGUI _multiplierText = null;
    [SerializeField] private TextMeshProUGUI _scoreText = null;
    [SerializeField] private Image _multiplierFillImage = null;

    private void OnEnable()
    {
        EnemyDie.OnEnemyDeath += ScoreInscrease;
        EnemyDie.OnEnemyDeath += MultiplierInscrease;
        EnemyDie.OnEnemyDeath += ScoreOnUIUpdate;
    }

    private void OnDisable()
    {
        EnemyDie.OnEnemyDeath -= ScoreInscrease;
        EnemyDie.OnEnemyDeath -= MultiplierInscrease;
        EnemyDie.OnEnemyDeath -= ScoreOnUIUpdate;
    }

    private void Update()
    {
        if (_multiplier > _minMultiplier)
        {
            float decreaser = Time.deltaTime * 0.1f;
            _multiplier -= decreaser;
            _multiplierFillImage.fillAmount -= decreaser;
            _multiplierText.text = _multiplier.ToString("F1");
        }
    }

    private void ScoreInscrease()
    {
        float roundedMultiplier = (float)Math.Round(_multiplier, 1);
        _score += _scoreForEnemy * roundedMultiplier;
    }

    private void MultiplierInscrease()
    {
        _multiplier += _scoreForEnemy / 300;
        HandleFill();
        _multiplier = Mathf.Clamp(_multiplier, _minMultiplier, _maxMultiplier);
    }

    private void ScoreOnUIUpdate()
    {
        _scoreText.text = "SCORE\n" + _score.ToString("F0");
    }

    private void HandleFill()
    {
        if (_multiplierFillImage)
        {
            _multiplierFillImage.fillAmount += _scoreForEnemy / 300;
        }
    }
}
