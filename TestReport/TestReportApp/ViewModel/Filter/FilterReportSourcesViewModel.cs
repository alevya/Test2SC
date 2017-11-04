﻿using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using TestReportApp.DbProvider;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel.Filter
{
    internal class FilterReportSourcesViewModel : ViewModelBase, IReportFilter
    {
        private SystemTableViewModel _currentSystemTableDetail;
        public FilterReportSourcesViewModel(ReportKind model, IReportFilter baseFilterReportViewModel)
        {
            Model = model;
            Name = "Выбор источников";
            FilterIntervalViewModel = baseFilterReportViewModel;
        }

        #region Properties
        public ReportKind Model { get; }

        public ObservableCollection<SystemTableViewModel> SystemTableDetails { get; set; }

        public SystemTableViewModel CurrentSystemTableDetail
        {
            get => _currentSystemTableDetail;
            set
            {
                _currentSystemTableDetail = value;
                OnPropertyChanged();
            }
        }

        public IReportFilter FilterIntervalViewModel { get; set; }
        
        #endregion
        #region IReportKind Implements

        public string Name { get; set; }

        public void GetContent()
        {
            using (var context = new ReportContext("system"))
            {
                context.SystemTables.Where(t => t.InnerName.StartsWith("db0_")).Load();
                SystemTableDetails = new ObservableCollection<SystemTableViewModel>();
                foreach (var st in context.SystemTables.Local)
                {
                    SystemTableDetails.Add(new SystemTableViewModel(st.Name));
                }
                _currentSystemTableDetail = SystemTableDetails.FirstOrDefault();
            }
        }

        public void GetDataForReport()
        {
            Debug.WriteLine("Получение данных из базы для отчета по источникам");

            var intervalViewModel = this.FilterIntervalViewModel as FilterReportIntervalViewModel;
            var dtFrom = intervalViewModel?.DateFrom;
            var dtTo = intervalViewModel?.DateTo;
        }

        #endregion
    }
}