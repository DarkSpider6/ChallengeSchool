using UnityEngine;

namespace UIController.Detail
{
    [System.Serializable]
    public class QuestionItem
    {
        [SerializeField]
        private string questionId;
        [SerializeField]
        private string question;
        [SerializeField]
        private string[] answers;
        [SerializeField]
        private int correctAnswerId;

        public string QuestionId
        {
            get { return questionId; }
        }

        public string Question
        {
            get { return question; }
        }

        public int CorrectAnswerId
        {
            get { return correctAnswerId; }
        }

        public string GetAnswer(int answerId)
        {
            if (answers.Length > answerId)
                return answers[answerId];
            return string.Empty;
        }
    }
}
