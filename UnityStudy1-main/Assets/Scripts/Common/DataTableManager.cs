using System;
using System.Collections.Generic;
using System.Linq;

public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    private const string DATA_PATH = "DataTable";
    private const string CHAPTER_DATA_TABLE = "ChapterDataTable";

    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    protected override void Init()
    {
        base.Init();

        LoadChapterDataTable();
    }

    private void LoadChapterDataTable()
    {
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        foreach (var data in parsedDataTable)
        {
            var chapterData = new ChapterData
            {
                ChapterNo = Convert.ToInt32(data["chapter_no"]),
                TotalStages = Convert.ToInt32(data["total_stages"]),
                ChapterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]),
                ChapterRewardGold = Convert.ToInt32(data["chapter_reward_gold"]),
            };

            ChapterDataTable.Add(chapterData);
        }
    }

    public ChapterData GetChapterData(int chapterNo)
    {
        foreach (var item in ChapterDataTable)
        {
            if (item.ChapterNo == chapterNo)
                return item;
        }

        return null;
    }
}

public class ChapterData
{
    public int ChapterNo;
    public int TotalStages;
    public int ChapterRewardGem;
    public int ChapterRewardGold;
}
