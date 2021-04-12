using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonGradeCalculator : MonoBehaviour
{
    [SerializeField] private SongData scriptableSongData;
    [SerializeField] private Score scoreCounterObj;

    private int perfectScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        CalculateLessonGrade();
    }

    private void CalculateLessonGrade()
    {
        CalculatePerfectScore();
        Debug.Log("SS:" + perfectScore);
        Debug.Log("S:" + perfectScore * .95f);
        Debug.Log("A:" + perfectScore * .90f);
        Debug.Log("B:" + perfectScore * .85f);
        Debug.Log("C:" + perfectScore * .75f);
        Debug.Log("D:" + perfectScore * .65f);
    }

    private void CalculatePerfectScore()
    {
        int noteCount = scriptableSongData.beatNoteIndexes.Count;
        for (int i = 0; i < noteCount; i++)
        {
            perfectScore += (int)(scoreCounterObj.GetPerfectScoreValue + ((scoreCounterObj.GetPerfectScoreValue * (i) * 0.1) / 10));
        }

        for (int i = 0; i < noteCount; i++)
        {
            perfectScore += (int)(scoreCounterObj.GetPerfectScoreValue + ((scoreCounterObj.GetPerfectScoreValue * (i) * 0.1) / 10));
        }
    }
}
