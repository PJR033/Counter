using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ClickTracker))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class Counter : MonoBehaviour
{
    private ClickTracker _clickTracker;
    private TextMeshProUGUI _text;
    private float _countValue;
    private float _countDelay = 0.5f;
    private bool _isCounting;

    private void Awake()
    {
        _clickTracker = GetComponent<ClickTracker>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _clickTracker.IsClicked += ChangeCountingStatus;
    }

    private void OnDisable()
    {
        _clickTracker.IsClicked -= ChangeCountingStatus;
    }

    private void ChangeCountingStatus()
    {
        if(_isCounting)
        {
            _isCounting = false;
        }
        else
        {
            _isCounting = true;
            StartCoroutine(Counting());
        }
    }

    private IEnumerator Counting()
    {
        WaitForSeconds delay = new WaitForSeconds(_countDelay);

        while (_isCounting)
        {
            _countValue++;
            _text.text = _countValue.ToString();
            yield return delay;
        }
    }
}
