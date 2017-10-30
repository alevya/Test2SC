using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TestReportApp.DbProvider.Models;
using TestReportApp.ViewModel.Helpers;

namespace TestReportApp.ViewModel
{
    internal class ReportWorkspaceViewModel : ViewModelBase
    {

        #region Init

        private FilterReportViewModel _currentFilter;
        public ReportWorkspaceViewModel()
        {
            ReportKinds = new List<ReportKind>
                          {
                              new ReportKind{Name = "Отчет по источникам", Description = "Отчет по общему количеству событий от выбранных источников", IsSelected = true},
                              new ReportKind{Name = "Отчет по уведомлениям", Description = "Отчет по количеству событий для каждой из групп уведомлений"},
                              new ReportKind{Name = "Отчет по IP-адресам", Description = "Отчет по общему количеству событий от каждого IP-адреса"},
                              new ReportKind{Name = "Графики <X,Y> событий", Description = @"Графики вида ""Время(Ось X)-Количество событий(Ось Y)"""},
                          };

            //Установка первого фильтра
            CurrentFilter = new FilterReportViewModel();


            //Команда для формирования отчета
            CreateReportCommand = new DelegateCommand(o => _createReport());

            //Команда от RadioButton для выбора отчета
            ChoiceReportCommand = new DelegateCommand(o=> _choiceReport());
        }
        #endregion

        #region Properties

        public IEnumerable<ReportKind> ReportKinds { get; }
      
        public FilterReportViewModel CurrentFilter
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
