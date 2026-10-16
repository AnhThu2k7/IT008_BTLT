using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTLT01.Command;
using BTLT01.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BTLT01.ViewModel{
    public class StudentEditorViewModel : INotifyPropertyChanged{
        private Student _formStudent;
        public Student FormStudent{
            get => _formStudent;
            set{
                _formStudent = value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveCommand { get; }
        public ICommand ClearCommand { get; }
        public StudentEditorViewModel(MainViewModel mainVM){
            FormStudent = new Student();
            SaveCommand = new RelayCommand(
                p =>{
                    mainVM.SaveStudent(FormStudent);
                    ClearForm();
                },
                p => FormStudent != null
                     && !string.IsNullOrWhiteSpace(FormStudent.StudentId)
                     && !string.IsNullOrWhiteSpace(FormStudent.FullName)
            );
            ClearCommand = new RelayCommand(p => ClearForm());
        }

        public void ClearForm(){
            FormStudent = new Student();
        }
        public void SetFormStudent(Student student){
            if (student != null){FormStudent = student.Clone();}
            else{ClearForm();}
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}