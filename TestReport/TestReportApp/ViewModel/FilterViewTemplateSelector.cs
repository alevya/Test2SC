using System;
using System.Windows;
using System.Windows.Controls;

namespace TestReportApp.ViewModel
{
      class FilterViewTemplateSelector : DataTemplateSelector
      {
            public DataTemplate BaseFilterViewTemplate { get; set; }
            public DataTemplate FilterViewTemplate { get; set; }

            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                base.SelectTemplate(item, container);
                var vm = item as BaseFilterReportViewModel;
                if (vm == null) return null;
               
                switch (vm.ViewType)
                {
                    case FilterViewType.BaseFilter:
                        return BaseFilterViewTemplate;
                    case FilterViewType.AddFilter:
                        return FilterViewTemplate;
                        
                }
                return null;
            }
      }
    
}
