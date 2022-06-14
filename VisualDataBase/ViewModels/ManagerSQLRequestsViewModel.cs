using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

        public ObservableCollection<Request> Requests
        {
            get
            {
                return _requests;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _requests, value);
            }
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
            }
        }
        public Condition CurrentCondition { get; set; }



        public ReactiveCommand<Unit, List<object>?> ExecuteRequestCommand { get; }
        public ReactiveCommand<int, Unit> AddConditionCommand { get; }
        public ReactiveCommand<int, Unit> RemoveConditionCommand { get; }

        public ManagerSQLRequestsViewModel()
        {
            Requests = new ObservableCollection<Request>();
            AddRequest();

            CurrentRequest = (Request)Requests.First().Clone();

            ExecuteRequestCommand = ReactiveCommand.Create<List<object>?>(ExecuteRequest);
            //AddConditionCommand = ReactiveCommand.Create<int>(AddCondition);
            //RemoveConditionCommand = ReactiveCommand.Create<int>(RemoveCondition);
        }

        private List<object>? ExecuteRequest()
        {
            //if (SaveRequest() != 0)
            //    return null;

            IQueryable<object>? result = null;

            //switch (CurrentRequest.TypeSelectTable)
            //{
            //    case TableTypes.Seasons:
            //        result = from d in MyDataBaseContext.db.Seasons select d;
            //        break;
            //    case TableTypes.Nations:
            //        result = from d in MyDataBaseContext.db.Nations select d;
            //        break;
            //    case TableTypes.Players:
            //        result = from d in MyDataBaseContext.db.Players select d;
            //        break;
            //    case TableTypes.PlayersSeasons:  
            //        result = from d in MyDataBaseContext.db.PlayersSeasons select d;
            //        break;
            //}

            //    /*
            //     * Operator - And 
            //     * Field - Id
            //     * OperatorCommand - <
            //     * Value - 1
            //     */

            //if (CurrentSelectConditions is not null)
            //{

            //}

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

            Requests.Add(new Request (title));
        }

        //private void DeleteCurrentRequest()
        //{
        //    Requests.Remove(CurrentRequest);

        //    if (Requests.Count < 1)
        //    {
        //        AddRequest();
        //    }

        //    CurrentRequest = Requests.First();
        //}

        //private int SaveRequest()
        //{
        //    if (!VerifyTitleCurrentRequest())
        //        return -1;

        //    if (CurrentRequest.TypeSelectTable is null)
        //        return -1;

        //    if (CurrentRequest.SelectFields is null)
        //        return -1;

        //    if (CurrentRequest.SelectConditions is not null)
        //    {
        //        foreach (var cond in CurrentRequest.SelectConditions)
        //        {
        //            if (cond.Operator == null || cond.Field == null || cond.OperatorCommand == null || cond.Value == null)
        //                return -1;
        //        }
        //    }


        //    foreach (var req in Requests)
        //    {
        //        if (req.Title == CurrentRequest.Title)
        //        {
        //            req.Title = CurrentRequest.Title;
        //            //req.TypeSelectTable = CurrentRequest.TypeSelectTable;

        //            foreach (var item in AvailableSelectFields)
        //            {
        //                if (item.Title != "All" && item.IsSelected)
        //                {
        //                    req.SelectFields.Add(item.Title);
        //                }
        //            }
        //            req.SelectConditions.CopyTo(CurrentRequest.SelectConditions.ToArray(), 0);

        //            return 0;
        //        }
        //    }

        //    return -1;
        //}

        //private bool VerifyTitleCurrentRequest()
        //{
        //    if (CurrentRequest.Title == string.Empty)
        //        return false;

        //    if (int.TryParse(CurrentRequest.Title, out var parsedNum))
        //        return false;

        //    int countRepeatItems = 0;
        //    foreach (var req in Requests)
        //        if (req.Title == CurrentRequest.Title)
        //            countRepeatItems++;
        //    if (countRepeatItems > 1)
        //        return false;

        //    return true;
        //}

        //private void AddCondition(int command)
        //{
        //    if (CurrentRequest.TypeSelectTable == null)
        //        return;

        //    switch(command)
        //    {
        //        case 0: // Select
        //            if (CurrentRequest.SelectConditions == null)
        //                CurrentRequest.SelectConditions = new ObservableCollection<Condition>();

        //            CurrentRequest.SelectConditions.Add(new Condition(CurrentRequest.TypeSelectTable));
        //            break;
        //        case 1: // Join
        //            //if (JoinConditions == null)
        //            //    JoinConditions = new ObservableCollection<Condition>();

        //            //JoinConditions.Add(new Condition(CurrentRequest.TypeSelectTable));
        //            break;
        //    }
        //}

        //private void RemoveCondition(int command)
        //{
        //    if (CurrentRequest.SelectConditions == null)
        //        return;

        //    switch (command)
        //    {
        //        case 0: // Select
        //            CurrentRequest.SelectConditions.Remove(CurrentSelectCondition);
        //            break;

        //    }
        //}
    }
}
