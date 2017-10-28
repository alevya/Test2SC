using System.Collections.Generic;
using WpfApp.DbProvider.Models;

namespace WpfApp.ViewModel
{
    internal class ReportWorkspaceViewModel : ViewModelBase
    {
        public ReportWorkspaceViewModel()
        {
            ReportKinds = new List<ReportKind>
                          {
                              new ReportKind{Name = "Отчет по источникам", Description = "Отчет по общему количеству событий от выбранных источников", IsSelected = true},
                              new ReportKind{Name = "Отчет по уведомлениям", Description = "Отчет по количеству событий для каждой из групп уведомлений"},
                              new ReportKind{Name = "Отчет по IP-адресам", Description = "Отчет по общему количеству событий от каждого IP-адреса"},
                              new ReportKind{Name = "Графики <X,Y> событий", Description = @"Графики вида ""Время(Ось X)-Количество событий(Ось Y)"""},
                          };
        }

        #region Properties

        public IEnumerable<ReportKind> ReportKinds { get; }

        #endregion
    }
}
