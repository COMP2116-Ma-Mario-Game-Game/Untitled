using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class LevelUI : MonoBehaviour
    {
        private float _time;
        private long _score;

        private Label _lbTimerValue;
        private Label _lbScoreValue;

        // Start is called before the first frame update
        private void Start()
        {
            _time = 0;

            var uiDocument = GetComponent<UIDocument>();
            _lbTimerValue = uiDocument.rootVisualElement.Q<Label>("lbTimerValue");
            _lbScoreValue = uiDocument.rootVisualElement.Q<Label>("lbScoreValue");
        }

        // Update is called once per frame
        private void Update()
        {
            _time += Time.deltaTime;
            var minutes = Mathf.FloorToInt(_time / 60);
            var seconds = Mathf.FloorToInt(_time % 60);
            _lbTimerValue.text = $"{minutes:00}:{seconds:00}";

            _score = 1000 - seconds;
            _lbScoreValue.text = $"{_score:0000}";
        }
    }
}