using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfotoMainText : MonoBehaviour
{
    public TMP_Dropdown playername;
    public TMP_Dropdown gender;
    public TMP_Dropdown type;
    public TMP_Dropdown style;
    //public List<TMP_Dropdown> dropdown_list;

    public TMP_Text nametext;
    public TMP_Text gendertext;
    public TMP_Text typetext;
    public TMP_Text styletext;

    private int a;
    private void Start()
    {
        nametext.text = "";
        gendertext.text = "";
        typetext.text = "";
        styletext.text = "";
    }

    private void Update()
    {
        all();

    }

    void all()
    {
        playername.onValueChanged.AddListener(namechange);
        gender.onValueChanged.AddListener(genderchange);
        type.onValueChanged.AddListener(typechange);
        style.onValueChanged.AddListener(stylechange);
    }
    void namechange(Int32 idx)
    {
        nametext.text = "name : " + playername.options[idx].text;
    }
    void genderchange(Int32 idx)
    {
        gendertext.text = "gender : " + gender.options[idx].text;
    }
    void typechange(Int32 idx)
    {
        typetext.text = "type : " + type.options[idx].text;
    }
    void stylechange(Int32 idx)
    {
        styletext.text = "style : " + style.options[idx].text;
    }

}
