using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreTable : MonoBehaviour
{
    public Transform container;
    public Transform template;
    private List<HighscoreEntry> _highscoreEntries;
    private List<Transform> _highscoreTransforms;

    public float padding;

    // Start is called before the first frame update
    void Awake()
    {
        template.gameObject.SetActive(false);

        //AddHighscoreEntry(5000);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (highscores == null)
        {
            highscores = CreateNewJsonList();
        }

        SortHighscoreEntries(highscores);
        PopulateHighscoresUI(highscores);
    }

    private void PopulateHighscoresUI(Highscores highscores)
    {
        _highscoreTransforms = new List<Transform>();
        foreach (HighscoreEntry entry in highscores.highscoreEntries)
        {
            CreateHighscoreEntryTransform(entry, container, _highscoreTransforms);
        }
    }

    private Highscores CreateNewJsonList()
    {
        Highscores highscores;
        _highscoreEntries = new List<HighscoreEntry>() {
            new HighscoreEntry { score = 0 } };

        highscores = new Highscores { highscoreEntries = _highscoreEntries };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        return highscores;
    }

    public void ClearHighscores()
    {
        PlayerPrefs.DeleteKey("highscoreTable");
    }

    public void AddHighscoreEntry(float score)
    {
        //Create
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };

        //Load previous
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Add
        highscores.highscoreEntries.Add(highscoreEntry);

        //Save
        string jsonList = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", jsonList);
        PlayerPrefs.Save();
    }

    private void SortHighscoreEntries(Highscores highscores)
    {
        for (int i = 0; i < highscores.highscoreEntries.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntries.Count; j++)
            {
                if (highscores.highscoreEntries[j].score > highscores.highscoreEntries[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntries[i];
                    highscores.highscoreEntries[i] = highscores.highscoreEntries[j];
                    highscores.highscoreEntries[j] = tmp;
                }
            }

        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform containerTransform, List<Transform> transforms)
    {
        Transform entryTransform = Instantiate(template, containerTransform);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -padding * transforms.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transforms.Count + 1;
        entryTransform.Find("rankText").GetComponent<TextMeshProUGUI>().text = rank.ToString();

        float score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        transforms.Add(entryTransform);
    }
}
