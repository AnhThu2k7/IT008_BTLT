using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTLT01.Command;
using BTLT01.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace BTLT01.ViewModel{
    public class StudentListViewModel : INotifyPropertyChanged{
        private Student _selectedStudent;
        public ObservableCollection<Student> dsSinhVien { get; set; }
        public Student SelectedStudent{
            get => _selectedStudent;
            set{
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand { get; }
        public StudentListViewModel(MainViewModel mainVM, ObservableCollection<Student> sharedList){
            dsSinhVien = sharedList;

            DeleteCommand = new RelayCommand(
                p =>{
                    if (SelectedStudent != null){
                        dsSinhVien.Remove(SelectedStudent);
                        SelectedStudent = null;
                        mainVM.Editor.ClearForm();
                    }
                },
                p => SelectedStudent != null
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}