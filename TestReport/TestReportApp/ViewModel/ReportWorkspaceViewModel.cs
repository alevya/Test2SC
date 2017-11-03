using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestReportApp.DbProvider.Models;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;
using TestReportApp.ViewModel;

namespace TestReportApp.ViewModel
{
    enum TypeReport
    {
        ОтчетПоИсточникам,
        ОтчетПоУведомлениям,
        ОтчетПоIpАдресам,
        ОтчетГрафик
    }
    internal class ReportWorkspaceViewModel : ViewModelBase
    {
        private static readonly IEnumerable<ReportKind> ListReportKinds = new List<ReportKind>
        {
            new ReportKind
            {
                Name = "Отчет по источникам",
                Description = "Отчет по общему количеству событий от выбранных источников",
                IsSelected = true,
            },
            new ReportKind
            {
                Name = "Отчет по уведомлениям",
                Description = "Отчет по количеству событий для каждой из групп уведомлений",
            },
            new ReportKind
            {
                Name = "Отчет по IP-адресам",
                Description = "Отчет по общему количеству событий от каждого IP-адреса",
            },
            new ReportKind
            {
                Name = "Графики <X,Y> событий",
                Description = @"Графики вида ""Время(Ось X)-Количество событий(Ось Y)""",
            },
        };
        private ViewModelBase _currentFilter;
        private IReportKind _currentReportKind;

        #region Init

        public ReportWorkspaceViewModel()
        {

            ReportKinds = _initReportKinds();
            CurrentReportKind = ReportKinds.FirstOrDefault();
            
            //Команда для формирования отчета
            CreateReportCommand = new DelegateCommand(o => _createReport());

            LoadContent = new DelegateCommand(
                o =>
                {
                    CurrentReportKind.GetContent();
                },
                o =>
                {
                    return CurrentReportKind != null;
                }
                );

        }

        private static ObservableCollection<IReportKind> _initReportKinds()
        {
            var lst = new ObservableCollection<IReportKind>();

            var baseFiter = new BaseFilterReportViewModel(null);
            lst.Add(new FilterAddReportViewModel(ListReportKinds.ElementAt(0), baseFiter, TypeReport.ОтчетПоИсточникам));
            lst.Add(new FilterAddReportViewModel(ListReportKinds.ElementAt(1), baseFiter, TypeReport.ОтчетПоУведомлениям));
            lst.Add(new BaseFilterReportViewModel(ListReportKinds.ElementAt(2)));
            lst.Add(new BaseFilterReportViewModel(ListReportKinds.ElementAt(3)));
            return lst;
        }
        #endregion

        #region Properties
        public ObservableCollection<IReportKind> ReportKinds { get; }

        public IReportKind CurrentReportKind
        {
            get => _currentReportKind;
            set
            {
                _currentReportKind = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase CurrentFilterViewModel
        {
            get => _currentFilter;
            set
            {
                _currentFilter = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command
        public ICommand CreateReportCommand { get; }
        public ICommand LoadContent { get; set; }

        private void _createReport()
        {
            MessageBox.Show("Требуется обработка фильтра и формирование для отчета");
        }
        #endregion
    }

}
