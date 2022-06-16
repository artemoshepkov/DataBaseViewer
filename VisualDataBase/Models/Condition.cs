using System;
using System.Collections.Generic;

namespace VisualDataBase.Models
{
    public class Condition
    {
        public ConditionTypes ConditionType { get; set; }
        public string Operator { get; set; }
        public string Field { get; set; }
        public string ConditionOperator { get; set; }
        public string Value { get; set; }

        public static List<string> Operators { get; } = new List<string> { "And", "Or" };
        public static List<string> ConditionOperators { get; } = new List<string> { "<", ">", "=", "<=", ">=" };
        public List<string> Fields { get; set; }

        public Condition(ConditionTypes conditionType, TableTypes? tableType)
        {
            ConditionType = conditionType;

            ChangedFields(tableType);
        }

        private void ChangedFields(TableTypes? tableType)
        {
            Type? classType = null;

            switch (tableType)
            {
                case TableTypes.Seasons:
                    classType = typeof(Season);
                    break;
                case TableTypes.Nations:
                    classType = typeof(Nation);
                    break;
                case TableTypes.Players:
                    classType = typeof(Player);
                    break;
                case TableTypes.PlayersSeasons:
                    classType = typeof(PlayersSeason);
                    break;
            }

            if (classType == null)
                return;

            Fields = new List<string>();

            foreach (var item in classType.GetProperties())
            {
                if (item.Name != "IdNationNavigation" && item.Name != "PlayersSeasons")
                    Fields.Add(item.Name);
            }
        }
    }
}
