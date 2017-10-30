using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TestReportApp.DbProvider.Models;
using TestReportApp.DbProvider.Models.Filter;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class ReportWorkspaceViewModel : ViewModelBase
    {
        #region Init
        private BaseFilterReportViewModel _currentFilter;
        public ReportWorkspaceViewModel()
        {

            ReportKinds = _initReportKinds();
            //Установка первого фильтра
            CurrentFilter = ReportKinds[0].Filter;
         
            //Команда для формирования отчета
            CreateReportCommand = new DelegateCommand(o => _createReport());

            //Команда от RadioButton для выбора отчета
            ChoiceReportCommand = new DelegateCommand(o=> _choiceReport());
        }

        private ObservableCollection<ReportKindViewModel> _initReportKinds()
        {
            var lst = new ObservableCollection<ReportKindViewModel>();
  
            IEnumerable<ReportKind> lstReportKinds = new List<ReportKind>
            {
                new ReportKind
                {
                    Name = "Отчет по источникам",
                    Description = "Отчет по общему количеству событий от выбранных источников",
                    IsSelected = true,
                    Filter = new FilterReportAdd()
                },
                new ReportKind
                {
                    Name = "Отчет по уведомлениям",
                    Description = "Отчет по количеству событий для каждой из групп уведомлений",
                    Filter = new FilterReportAdd(),
                },
                new ReportKind
                {
                    Name = "Отчет по IP-адресам",
                    Description = "Отчет по общему количеству событий от каждого IP-адреса",
                    Filter = new FilterReport(),
                },
                new ReportKind
                {
                    Name = "Графики <X,Y> событий",
                    Description = @"Графики вида ""Время(Ось X)-Количество событий(Ось Y)""",
                    Filter = new FilterReportAdd(),
                },
            };
            foreach (var rk in lstReportKinds)
            {
               lst.Add(new ReportKindViewModel(rk));
            }

            return lst;
        }
        #endregion

        #region Properties

        //public IEnumerable<ReportKind> ReportKinds { get; }
        public ObservableCollection<ReportKindViewModel> ReportKinds { get; }

        public BaseFilterReportViewModel CurrentFilter
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
        public ICommand ChoiceReportCommand { get; }

        private void _createReport()
        {
            MessageBox.Show("Требуется обработка фильтра и формирование для отчета");
        }

        private void _choiceReport()
        {
            MessageBox.Show("Сделать выбор фильтра");

        }
        #endregion
    }
}
