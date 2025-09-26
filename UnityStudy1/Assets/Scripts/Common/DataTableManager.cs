using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    //������ �������� ��θ� �����ϴ� ����
    private const string DATA_PATH = "DataTable";

    //������ ���̺� ���� �����̸�
    //é�͵�����
    private const string CHAPTER_DATA_TABLE = "ChapterDataTable";
    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    protected override void Init()
    {
        base.Init();

        LoadChapterDataTable();
    }

    private void LoadChapterDataTable()
    {
        //--> �̰� List������..�ٵ� �ϴ� var�� �� �ƹ�ư -> é�� ���������� �о����
        List<Dictionary<string, object>> parseDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        foreach(Dictionary<string, object> data in parseDataTable)
        {
            ChapterData chapterData = new ChapterData() //�����ڸ��� �ʱ�ȭ
            {
                ChapterNo = Convert.ToInt32(data["chapter_no"]),
                TotalStage = Convert.ToInt32(data["total_stages"]),
                ChapterRewordGem = Convert.ToInt32(data["chapter_reward_gem"]),
                ChapterRewordGold = Convert.ToInt32(data["chapter_reward_gold"]),
            };

            ChapterDataTable.Add(chapterData);
        }
    }

    public ChapterData GetChapterData(int chapterNo)
    {
        foreach(var item in ChapterDataTable)
        {
            if(item.ChapterNo == chapterNo)
            {
                return item;
            }
        }

        return null;

        //LINQ -->
        //ChapterDataTable.Where(item => item.ChapterNo == chapterNo).FirstOrDefault();
    }
}

public class ChapterData
{
    public int ChapterNo;
    public int TotalStage;
    public int ChapterRewordGem;
    public int ChapterRewordGold;
}