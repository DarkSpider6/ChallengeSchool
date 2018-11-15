using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIController.Detail
{
    public class QuestionWindow : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent ShownDelegate;
        [SerializeField]
        private UnityEvent HiddenDelegate;
        [SerializeField]
        private UnityEvent SuccessDelegate;
        [SerializeField]
        private UnityEvent FailedDelegate;

        [SerializeField]
        private Text questionLabel;
        [SerializeField]
        private Text answer1Label;
        [SerializeField]
        private Text answer2Label;
        [SerializeField]
        private Text answer3Label;
        [SerializeField]
        private QuestionWindowSettings settings;

        private QuestionItem currentItem;

        public void Show(string questionId)
        {
            currentItem = settings.GetQuestion(questionId);
            if (currentItem != null)
            {
                questionLabel.text = currentItem.Question;
                answer1Label.text = currentItem.GetAnswer(0);
                answer2Label.text = currentItem.GetAnswer(1);
                answer3Label.text = currentItem.GetAnswer(2);
                ShownDelegate.Invoke();
            }
        }

        public void SelectAnswer(int answerId)
        {
            if (currentItem.CorrectAnswerId == answerId)
                SuccessDelegate.Invoke();
            else
                FailedDelegate.Invoke();

            HiddenDelegate.Invoke();
        }

        private void Start()
        {
            HiddenDelegate.Invoke();
        }
    }
}
