using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BTLT01
{
    public class Student : INotifyPropertyChanged
    {
        private string _studentId = string.Empty;
        private string _fullName = string.Empty;
        private DateTime? _dateOfBirth;
        private string _gender = "Nam";
        private string _email = string.Empty;
        private string _university = "UIT - VNUHCM";
        private string _avatar = "/Test.jpg";

        public string StudentId
        {
            get => _studentId;
            set
            {
                if (_studentId != value)
                {
                    _studentId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsMale));
                    OnPropertyChanged(nameof(IsFemale));
                }
            }
        }

        public bool IsMale
        {
            get => Gender == "Nam";
            set
            {
                if (value)
                {
                    Gender = "Nam";
                }
            }
        }

        public bool IsFemale
        {
            get => Gender == "Nữ";
            set
            {
                if (value)
                {
                    Gender = "Nữ";
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string University
        {
            get => _university;
            set
            {
                if (_university != value)
                {
                    _university = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Avatar
        {
            get => _avatar;
            set
            {
                if (_avatar != value)
                {
                    _avatar = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Student Clone()
        {
            return new Student
            {
                StudentId = this.StudentId,
                FullName = this.FullName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                Email = this.Email,
                University = this.University,
                Avatar = this.Avatar
            };
        }
    }

    // Lớp SinhVien kế thừa Student để tương thích ngược nếu cần
    public class SinhVien : Student
    {
    }
}
