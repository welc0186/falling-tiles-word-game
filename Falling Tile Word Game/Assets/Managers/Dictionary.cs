using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public static Dictionary Instance;
    [SerializeField] private TextAsset wordFile;
    private List<string> wordList;


    void Awake()
    {
        Instance = this;
        wordList = FileToWords(wordFile);
    }

    public char GetRandomLetter()
    {
        string letters =
        "AAAAAAAAA" + 
        "BB" + 
        "CC" + 
        "DDDD" + 
        "EEEEEEEEEEEE" + 
        "FF" + 
        "GGG" + 
        "HH" + 
        "IIIIIIIII" + 
        "J" + 
        "K" + 
        "LLLL" + 
        "MM" + 
        "NNNNNN" +
        "OOOOOOOO" + 
        "PP" +
        "Q" +
        "RRRRRR" + 
        "SSSS" +
        "TTTTTT" +
        "UUUU" +
        "VV" + 
        "WW" +
        "X" +
        "YY" +
        "Z";
        return letters[Random.Range(0, letters.Length)];
    }

    public char GetRandomVowel()
    {
        string letters = "AEIOU";
        return letters[Random.Range(0, letters.Length)];
    }

    List<string> FileToWords(TextAsset file)
    {
        string text = file.text;
        string[] s = text.Split('\n');
        List<string> list = new List<string>();
        foreach(string word in s)
        {
            list.Add(word);
        }
        return list;
    }

    public bool IsValidWord(string word)
    {
        if(word.Length > 2 && wordList.Contains(word.ToLower()))
        {
            //Debug.Log(word + " is a valid word");
            return true;
        }
        return false;
    }

    public int GetLetterValue(char c)
    {        
        Dictionary<char, int> dic = new Dictionary<char,int>();
        dic.Add('A', 3);
        dic.Add('B', 2);
        dic.Add('C', 2);
        dic.Add('D', 2);
        dic.Add('E', 3);
        dic.Add('F', 2);
        dic.Add('G', 2);
        dic.Add('H', 2);
        dic.Add('I', 3);
        dic.Add('J', 2);
        dic.Add('K', 2);
        dic.Add('L', 2);
        dic.Add('M', 2);
        dic.Add('N', 3);
        dic.Add('O', 3);
        dic.Add('P', 2);
        dic.Add('Q', 1);
        dic.Add('R', 3);
        dic.Add('S', 3);
        dic.Add('T', 2);
        dic.Add('U', 2);
        dic.Add('V', 1);
        dic.Add('W', 1);
        dic.Add('X', 1);
        dic.Add('Y', 2);
        dic.Add('Z', 1);
        return dic[c];
    }
    
    
}
