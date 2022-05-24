using ReactiveUI;
using System.Collections.ObjectModel;

namespace VisualDataBase.ViewModels
{
    public class ManagerSQLRequestsViewModel : ViewModelBase
    {
        private ObservableCollection<Condition> selectConditions;
        public ObservableCollection<Condition> SelectConditions
        {
            get { return selectConditions; }
            set { this.RaiseAndSetIfChanged(ref selectConditions, value); }
        }

        private ObservableCollection<Condition> joinConditions;
        public ObservableCollection<Condition> JoinConditions
        {
            get { return joinConditions; }
            set { this.RaiseAndSetIfChanged(ref joinConditions, value); }
        }

        private ObservableCollection<Condition> groupByConditions;
        public ObservableCollection<Condition> GroupByConditions
        {
            get { return groupByConditions; }
            set { this.RaiseAndSetIfChanged(ref groupByConditions, value); }
        }

        public ManagerSQLRequestsViewModel()
        {
            SelectConditions = new ObservableCollection<Condition> { new Condition("123", "123", "123", 123), new Condition("123", "123", "123", 123) };
            JoinConditions = new ObservableCollection<Condition> { new Condition("123", "123", "123", 123), new Condition("123", "123", "123", 123) };
            GroupByConditions = new ObservableCollection<Condition> { new Condition("123", "123", "123", 123), new Condition("123", "123", "123", 123) };
        }
    }


    public class Condition
    {
        public string Oper { get; set; }
        public string Field { get; set; }
        public string Cond { get; set; }
        public int ValueCondition { get; set; }

        public Condition(string oper, string field, string cond, int value)
        {
            Oper = oper;
            Field = field;
            Cond = cond;
            ValueCondition = value;
        }
    }
}
