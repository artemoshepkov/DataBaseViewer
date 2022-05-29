using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualDataBase.ViewModels
{
    public class Condition
    {
        public static List<string> Operators { get; } = new List<string> { "And", "Or" };
        public static List<string> OperatorCommands { get; } = new List<string> { "<", ">", "=", "<=", ">=" };

        public List<string> Fields { get; }

        public string? Operator { get; set; }
        public string? Field { get; set; }
        public string? OperatorCommand { get; set; }
        public string? Value { get; set; }

        public Condition(TableTypes? tableType)
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

            if (classType != null)
            {
                Fields = new List<string>();

                foreach (var item in classType.GetProperties())
                {
                    Fields.Add(item.Name);
                }
            }
        }
    }
}
