using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Filter;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    
    internal class ReportWorkspaceViewModel : ViewModelBase
    {
        private static readonly IEnumerable<ReportKind> ListReportKinds = new List<ReportKind>
        {
            new ReportKind
            {
                Name = "Отчет по источникам",
                TypeCode = TypeCodeReport.ReportOnSource,
                Description = "Отчет по общему количеству событий от выбранных источников",
                IsSelected = true,     
            },
            new ReportKind
            {
                Name = "Отчет по уведомлениям",
                TypeCode = TypeCodeReport.ReportOnNotify,
                Description = "Отчет по количеству событий для каждой из групп уведомлений",
            },
            new ReportKind
            {
                Name = "Отчет по IP-адресам",
                TypeCode = TypeCodeReport.ReportOnIp,
                Description = "Отчет по общему количеству событий от каждого IP-адреса",
            },
            //new ReportKind
            //{
            //    Name = "Графики <X,Y> событий",
            //    TypeCode = TypeCodeReport.ОтчетГрафик,
            //    Description = @"Графики вида ""Время(Ось X)-Количество событий(Ось Y)""",
            //},
        };

        private IReportFilter _currentReportKind;

        #region Init

        public ReportWorkspaceViewModel()
        {

            ReportKinds = InitReportKinds();
            CurrentReportKind = ReportKinds.FirstOrDefault();
            
            //Команда для формирования отчета
            CreateReportCommand = new DelegateCommand(o => CurrentReportKind.GetDataForReport(), o => CurrentReportKind != null);

            LoadContent = new DelegateCommand(
                o =>
                {
                    CurrentReportKind.GetContent();
                },
                o => CurrentReportKind != null);
        }

        private static ObservableCollection<IReportFilter> InitReportKinds()
        {
            var lst = new ObservableCollection<IReportFilter>();
            foreach (var rk in ListReportKinds)
            {
                FilterReportIntervalViewModel baseFiter = new FilterReportIntervalViewModel(null);
                switch (rk.TypeCode)
                {
                    case TypeCodeReport.ReportOnSource:
                        lst.Add(new FilterReportSourcesViewModel(rk, baseFiter));
                    break;

                    case TypeCodeReport.ReportOnNotify:
                        lst.Add(new FilterReportNotifyViewModel(rk, baseFiter));
                        break;

                    case TypeCodeReport.ReportOnIp:
                        lst.Add(new FilterReportIpViewModel(rk, baseFiter));
                        break;
                    default:
                        return lst;
                }
            }
            return lst;
        }
        #endregion

        #region Properties
        public ObservableCollection<IReportFilter> ReportKinds { get; }

        public IReportFilter CurrentReportKind
        {
            get => _currentReportKind;
            set
            {
                _currentReportKind = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command
        public ICommand CreateReportCommand { get; }
        public ICommand LoadContent { get; set; }
        #endregion
    }

}
