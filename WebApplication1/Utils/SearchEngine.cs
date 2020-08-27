using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public static class SearchEngine
    {
        static char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\0' };
        static int GetScore(String Item, String Input)
        {
            int score = 0;
            string[] ItemTokens = Item.ToLower().Split(delimiterChars);
            string[] InputTokens = Input.ToLower().Split(delimiterChars);
            foreach(var i in ItemTokens)
            {
                foreach (var j in InputTokens){

                    if (i.Equals(j))
                    {
                        score++;
                    }

                }
            }
            return score;
        }

        static Dictionary<int, int> GetRanking(List<Resturaunt> resturaunts, string Input, int day)
        {
            Dictionary<int, int> Ranking = new Dictionary<int, int>();
            
            foreach(var resturaunt in resturaunts)
            {
                int score = 0;

                if(resturaunt.Name != null)
                {
                    score += GetScore(resturaunt.Name, Input);
                }

                foreach(var d in resturaunt.ResturauntPage.Days[day].Deals)
                {
                    if(d.ItemName != null)
                    {
                        score += GetScore(d.ItemName, Input);
                    }

                    if (d.Desription != null)
                    {
                        score += GetScore(d.Desription, Input);
                    }

                    foreach (var t in d.TagsInter)
                    {
                        score += GetScore(t.Tag.TagName, Input);
                    }
                }

                Ranking.Add(resturaunt.id, score);
            }


            return Ranking;
        }
    }
}
