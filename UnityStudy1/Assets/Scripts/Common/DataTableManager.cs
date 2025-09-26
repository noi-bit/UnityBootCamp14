using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    //가져올 데이터의 경로를 저장하는 변수
    private const string DATA_PATH = "DataTable";

    //데이터 테이블 실제 파일이름
    //챕터데이터
    private const string CHAPTER_DATA_TABLE = "ChapterDataTable";
    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    protected override void Init()
    {
        base.Init();

        LoadChapterDataTable();
    }

    private void LoadChapterDataTable()
    {
        //--> 이건 List형식임..근데 일단 var로 함 아무튼 -> 챕터 데이터파일 읽어오기
        List<Dictionary<string, object>> parseDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        foreach(Dictionary<string, object> data in parseDataTable)
        {
            ChapterData chapterData = new ChapterData() //만들자마자 초기화
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