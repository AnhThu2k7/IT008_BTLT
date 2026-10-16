using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTLT01.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BTLT01.ViewModel {
    public class MainViewModel : INotifyPropertyChanged {
        public ObservableCollection<Student> dsSinhVien { get; set; }
        public StudentEditorViewModel Editor { get; set; }
        public StudentListViewModel StudentList { get; set; }
        public MainViewModel() {
            dsSinhVien = new ObservableCollection<Student>();
            Editor = new StudentEditorViewModel(this);
            StudentList = new StudentListViewModel(this, dsSinhVien);
            TaoDuLieuMau();
            StudentList.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(StudentList.SelectedStudent)){
                    Editor.SetFormStudent(StudentList.SelectedStudent);
                }
            };
        }
        public void SaveStudent(Student studentInput) {
            var existing = dsSinhVien.FirstOrDefault(s => s.StudentId == studentInput.StudentId);
            if (existing != null) {
                existing.FullName = studentInput.FullName;
                existing.DateOfBirth = studentInput.DateOfBirth;
                existing.Gender = studentInput.Gender;
                existing.Email = studentInput.Email;
                existing.University = studentInput.University;
                existing.Avatar = studentInput.Avatar;
            }
            else { dsSinhVien.Add(studentInput.Clone()); }
        }

        private void TaoDuLieuMau() {
            dsSinhVien.Add(new Student() { StudentId = "25520001", FullName = "Nguyễn Văn Anh", DateOfBirth = new DateTime(2007, 1, 1) });
            dsSinhVien.Add(new Student() { StudentId = "25520002", FullName = "Trần Thị Bé", DateOfBirth = new DateTime(2007, 2, 2) });
            dsSinhVien.Add(new Student() { StudentId = "25520003", FullName = "Lê Hoàng Cường", DateOfBirth = new DateTime(2007, 3, 3) });
            dsSinhVien.Add(new Student() { StudentId = "25234104", FullName = "Phạm Minh Đạt", DateOfBirth = new DateTime(2007, 4, 4) });
            dsSinhVien.Add(new Student() { StudentId = "25234105", FullName = "Vũ Hải Yến", DateOfBirth = new DateTime(2007, 5, 5) });
            dsSinhVien.Add(new Student() { StudentId = "25234106", FullName = "Đặng Trọng Đại", DateOfBirth = new DateTime(2007, 6, 6) });
            dsSinhVien.Add(new Student() { StudentId = "25234107", FullName = "Bùi Thu Thảo", DateOfBirth = new DateTime(2007, 7, 7) });
            dsSinhVien.Add(new Student() { StudentId = "25234108", FullName = "Hồ Quang Hiếu", DateOfBirth = new DateTime(2007, 8, 8) });
            dsSinhVien.Add(new Student() { StudentId = "25234109", FullName = "Ngô Thùy Trang", DateOfBirth = new DateTime(2007, 9, 9) });
            dsSinhVien.Add(new Student() { StudentId = "25234110", FullName = "Đinh Xuân Hinh", DateOfBirth = new DateTime(2007, 10, 10) });
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}