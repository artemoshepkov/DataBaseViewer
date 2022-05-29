using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reflection;
using VisualDataBase.Models;

namespace VisualDataBase.ViewModels
{
    public class ManagerSQLRequestsViewModel : ViewModelBase
    {
        private ObservableCollection<Request> _requests;
        private Request _currentRequest;
        private string _titleCurrentRequest;

        private TableTypes? _typeCurrentSelectTable;
        private ObservableCollection<TableField>? _fieldsSelectRequest;
        public ObservableCollection<Condition>? _currentSelectConditions;
        public Condition? _currentSelectCondition;

        private TableTypes? _typeCurrentJoinTable;
        private ObservableCollection<TableField>? _fieldsJoinRequest;
        public ObservableCollection<Condition>? _joinConditions;

        public static List<string> OperatorCommands { get; } = new List<string> { "<", ">", "=", "<=", ">=" };


        public ObservableCollection<Request> Requests
        {
            get { return _requests; }
            set { this.RaiseAndSetIfChanged(ref _requests, value); }
        }
        public Request CurrentRequest
        {
            get 
            {
                return _currentRequest;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _currentRequest, value);

                TypeCurrentSelectTable = _currentRequest.TypeSelectTable;
                TitleCurrentRequest = _currentRequest.Title;

                if (_currentRequest.SelectFields != null)
                    FieldsSelectRequest = new ObservableCollection<TableField>(_currentRequest.SelectFields);
                else
                    FieldsSelectRequest = null;

                if (_currentRequest.SelectConditions != null)
                    CurrentSelectConditions = new ObservableCollection<Condition>(_currentRequest.SelectConditions);
                else
                    CurrentSelectConditions = null;
            }
        }
        public string TitleCurrentRequest
        {
            get { return _titleCurrentRequest; }
            set
            {
                this.RaiseAndSetIfChanged(ref _titleCurrentRequest, value);
            }
        }


        public static List<TableTypes> AvailableSelectTables { get; } = new List<TableTypes> { TableTypes.Seasons, TableTypes.Nations, TableTypes.Players, TableTypes.PlayersSeasons };
        public TableTypes? TypeCurrentSelectTable
        {
            get 
            { 
                return _typeCurrentSelectTable;
            }
            set 
            { 
                this.RaiseAndSetIfChanged(ref _typeCurrentSelectTable, value);
                FieldsSelectRequest = UpdateFields(_typeCurrentSelectTable);
                if (CurrentSelectConditions != null)
                    CurrentSelectConditions = new ObservableCollection<Condition>();
            }
        }
        public ObservableCollection<TableField>? FieldsSelectRequest
        {
            get { return _fieldsSelectRequest; }
            set { this.RaiseAndSetIfChanged(ref _fieldsSelectRequest, value); }
        }
        public ObservableCollection<Condition>? CurrentSelectConditions
        {
            get { return _currentSelectConditions; }
            set { this.RaiseAndSetIfChanged(ref _currentSelectConditions, value); }
        }
        public Condition? CurrentSelectCondition
        {
            get { return _currentSelectCondition; }
            set { this.RaiseAndSetIfChanged(ref _currentSelectCondition, value); }
        } // For remove


        public ObservableCollection<Condition>? JoinConditions
        {
            get { return _joinConditions; }
            set { this.RaiseAndSetIfChanged(ref _joinConditions, value); }
        }
        public TableTypes? TypeCurrentJoinTable
        {
            get
            {
                return _typeCurrentJoinTable;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _typeCurrentJoinTable, value);
                FieldsJoinRequest = UpdateFields(_typeCurrentJoinTable);

                //if (CurrentSelectConditions != null)
                //    CurrentSelectConditions = new ObservableCollection<Condition>();

            }
        }
        public ObservableCollection<TableField>? FieldsJoinRequest
        {
            get { return _fieldsJoinRequest; }
            set { this.RaiseAndSetIfChanged(ref _fieldsJoinRequest, value); }
        }
        public string CurrentFirstJoinOnField { get; set; }
        public string CurrentCommandOperatorJoinOnField { get; set; }
        public string CurrentSecondJoinOnField { get; set; }



        public ReactiveCommand<Unit, List<object>?> ExecuteRequestCommand { get; }
        public ReactiveCommand<int, Unit> AddConditionCommand { get; }
        public ReactiveCommand<int, Unit> RemoveConditionCommand { get; }

        public ManagerSQLRequestsViewModel()
        {
            Requests = new ObservableCollection<Request> { new Request { Title = "Req0" } };
            CurrentRequest = Requests.First();

            TitleCurrentRequest = CurrentRequest.Title;

            ExecuteRequestCommand = ReactiveCommand.Create<List<object>?>(ExecuteRequest);
            AddConditionCommand = ReactiveCommand.Create<int>(AddCondition);
            RemoveConditionCommand = ReactiveCommand.Create<int>(RemoveCondition);
        }

        private List<object>? ExecuteRequest()
        {
            if (SaveRequest() != 0)
                return null;

            IQueryable<object>? result = null;

            switch (TypeCurrentSelectTable)
            {
                case TableTypes.Seasons:
                    result = from d in MyDataBaseContext.db.Seasons select d;
                    break;
                case TableTypes.Nations:
                    result = from d in MyDataBaseContext.db.Nations select d;
                    break;
                case TableTypes.Players:
                    result = from d in MyDataBaseContext.db.Players select d;
                    break;
                case TableTypes.PlayersSeasons:  
                    result = from d in MyDataBaseContext.db.PlayersSeasons select d;
                    break;
            }

            /*
             * Operator - And 
             * Field - Id
             * OperatorCommand - <
             * Value - 1
             */

            if (CurrentSelectConditions is not null)
            {

            }

            return result.ToList();
        }

        private void AddRequest()
        {
            string title = "Req" + Requests.Count.ToString();

            foreach (var req in Requests)
            {
                if (req.Title == title)
                {
                    title += Requests.Count.ToString();
                    break;
                }
            }

            Requests.Add(new Request { Title = title });
        }

        private void DeleteCurrentRequest()
        {
            Requests.Remove(CurrentRequest);

            if (Requests.Count < 1)
            {
                AddRequest();
            }

            CurrentRequest = Requests.First();
        }

        private int SaveRequest()
        {
            if (!VerifyTitleCurrentRequest())
                return -1;

            if (TypeCurrentSelectTable is null)
                return -1;

            if (FieldsSelectRequest is null)
                return -1;

            if (CurrentSelectConditions is not null)
            {
                foreach (var cond in CurrentSelectConditions)
                {
                    if (cond.Operator == null || cond.Field == null || cond.OperatorCommand == null || cond.Value == null)
                        return -1;
                }
            }
           

            foreach (var req in Requests)
            {
                if (req.Title == CurrentRequest.Title)
                {
                    req.Title = TitleCurrentRequest;
                    req.TypeSelectTable = TypeCurrentSelectTable;
                    req.SelectFields = new ObservableCollection<TableField>(FieldsSelectRequest);

                    if (CurrentSelectConditions != null)
                        req.SelectConditions = new ObservableCollection<Condition>(CurrentSelectConditions);

                    return 0;
                }
            }

            return -1;
        }

        private bool VerifyTitleCurrentRequest()
        {
            if (TitleCurrentRequest == string.Empty)
                return false;

            if (int.TryParse(TitleCurrentRequest, out var parsedNum))
                return false;

            if (_titleCurrentRequest != CurrentRequest.Title)
                foreach (var req in Requests)
                    if (req.Title == TitleCurrentRequest)
                        return false;

            return true;
        }

        private ObservableCollection<TableField> UpdateFields(TableTypes? tableType)
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

            ObservableCollection<TableField> fields;
            if (classType != null)
            {
                fields = new ObservableCollection<TableField>();

                fields.Add(new TableField("All"));
                foreach (var item in classType.GetProperties())
                {
                    fields.Add(new TableField(item.Name));
                }

                return fields;
            }

            return null;
        }

        private void AddCondition(int command)
        {
            if (TypeCurrentSelectTable == null)
                return;

            switch(command)
            {
                case 0: // Select
                    if (CurrentSelectConditions == null)
                        CurrentSelectConditions = new ObservableCollection<Condition>();

                    CurrentSelectConditions.Add(new Condition(TypeCurrentSelectTable));
                    break;
                case 1: // Join
                    if (JoinConditions == null)
                        JoinConditions = new ObservableCollection<Condition>();

                    JoinConditions.Add(new Condition(TypeCurrentSelectTable));
                    break;
            }
        }

        private void RemoveCondition(int command)
        {
            if (CurrentSelectConditions == null)
                return;

            switch (command)
            {
                case 0: // Select
                    CurrentSelectConditions.Remove(CurrentSelectCondition);
                    break;

            }
        }
    }
}
