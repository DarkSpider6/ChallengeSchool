using UnityEngine;

namespace UIController.Detail
{
    public class QuestionWindowSettings : ScriptableObject
    {
        [SerializeField]
        private QuestionItem[] questions;

        public QuestionItem GetQuestion(string questionId)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i].QuestionId == questionId)
                    return questions[i];
            }
            return null;
        }
    }
}
