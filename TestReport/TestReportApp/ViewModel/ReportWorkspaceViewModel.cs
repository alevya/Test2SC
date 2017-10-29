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
        public ReportWorkspaceViewModel()
        {
            ReportKinds = new List<ReportKind>
                          {
                              new ReportKind{Name = "Отчет по источникам", Description = "Отчет по общему количеству событий от выбранных источников", IsSelected = true},
                              new ReportKind{Name = "Отчет по уведомлениям", Description = "Отчет по количеству событий для каждой из групп уведомлений"},
                              new ReportKind{Name = "Отчет по IP-адресам", Description = "Отчет по общему количеству событий от каждого IP-адреса"},
                              new ReportKind{Name = "Графики <X,Y> событий", Description = @"Графики вида ""Время(Ось X)-Количество событий(Ось Y)"""},
                          };
            FilterReport = new FilterReportViewModel();
            CreateReportCommand = new DelegateCommand(o => _createReport());
            ChoiceReportCommand = new DelegateCommand(o=> _choiceReport());
        }
        #endregion

        #region Properties

        public IEnumerable<ReportKind> ReportKinds { get; }
        public FilterReportViewModel FilterReport { get; }
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
