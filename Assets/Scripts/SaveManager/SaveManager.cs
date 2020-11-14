using UnityEngine;

namespace SaveManager
{
    public class SaveManager : MonoBehaviour, ISaveManager
    {
        private const string MaxScorePrefName = "Max Score";

        #region DebugMsg

        private const string LoadMsg = "Loaded max score is {0}";
        private const string TryToUpdateMsg = "Trying to set new max score - {0}";
        private const string NewMaxMsg = "New max score is {0}";

        #endregion

        [SerializeField] private int maxScore;
        public int MaxScore => maxScore;

        private void Awake()
        {
            maxScore = PlayerPrefs.GetInt(MaxScorePrefName);
            Debug.Log(string.Format(LoadMsg, MaxScore));
        }

        public bool TrySaveNewMax(int score)
        {
            Debug.Log(string.Format(TryToUpdateMsg, score));
            if (score <= MaxScore)
            {
                return false;
            }

            SaveMax(score);
            return true;
        }

        private void SaveMax(int score)
        {
            maxScore = score;
            PlayerPrefs.SetInt(MaxScorePrefName, score);
            Debug.Log(string.Format(NewMaxMsg, score));
        }

#if UNITY_EDITOR
        public void ResetScore()
        {
            SaveMax(0);
        }

        public void UpdateMax()
        {
            SaveMax(maxScore);
        }
#endif
    }
}