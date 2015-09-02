using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace App1.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    ///     </para>
    ///     <para>
    ///         You can also use Blend to data bind with the tool's support.
    ///     </para>
    ///     <para>
    ///         See http://www.galasoft.ch/mvvm
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public const string ValidOption = "valid one";
        private RelayCommand _acceptCommand;
        private string _selectedOption;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            PropertyChanged += MainViewModel_PropertyChanged;
        }

        public List<string> Options { get; } = CreateList();

        public RelayCommand AcceptCommand => _acceptCommand ?? (_acceptCommand = new RelayCommand(() => { }, CanAccept))
            ;

        public bool IsValid => SelectedOption == ValidOption;

        public string SelectedOption
        {
            get { return _selectedOption; }
            set { Set(ref _selectedOption, value); }
        }

        private static List<string> CreateList()
        {
            var list = new List<string>(Enumerable.Repeat("option", 15).Select((s, i) => $"{s} {i}"));
            list.Insert(2, ValidOption);
            return list;
        }

        private void MainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            AcceptCommand.RaiseCanExecuteChanged();
        }

        private bool CanAccept()
        {
            return IsValid;
        }
    }
}