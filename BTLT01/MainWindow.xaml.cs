using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BTLT01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 5. Sử dụng ObservableCollection<Student>
        public ObservableCollection<Student> dsSinhVien { get; set; } = new ObservableCollection<Student>();

        // 3. Đối tượng Student dùng cho Data Binding trên Form
        public Student FormStudent { get; set; } = new Student();

        private ICollectionView? _studentsView;

        public MainWindow()
        {
            InitializeComponent();

            TaoDuLieuMau();

            _studentsView = CollectionViewSource.GetDefaultView(dsSinhVien);
            _studentsView.Filter = FilterStudent;
            lvDanhSachSV.ItemsSource = _studentsView;

            // Thiết lập trạng thái ban đầu của Form
            ResetForm();
        }

        // Tạo dữ liệu mẫu cho danh sách sinh viên
        private void TaoDuLieuMau()
        {
            dsSinhVien.Add(new Student() { StudentId = "25520001", FullName = "Nguyễn Văn Anh", DateOfBirth = new DateTime(2007, 3, 14), Gender = "Nam", Email = "25520001@gm.uit.edu.vn", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25520002", FullName = "Trần Thị Bé", DateOfBirth = new DateTime(2007, 8, 20), Gender = "Nữ", Email = "25520002@ussh.edu.vn", University = "USSH - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25520003", FullName = "Lê Hoàng Cường", DateOfBirth = new DateTime(2007, 12, 5), Gender = "Nam", Email = "25520003@hcmus.edu.vn", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234104", FullName = "Phạm Minh Đạt", DateOfBirth = new DateTime(2007, 1, 15), Gender = "Nam", Email = "25234104@gm.uit.edu.vn", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234105", FullName = "Vũ Hải Yến", DateOfBirth = new DateTime(2007, 4, 22), Gender = "Nữ", Email = "haiyen.vu@rmit.edu.vn", University = "RMIT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234106", FullName = "Đặng Trọng Đại", DateOfBirth = new DateTime(2007, 7, 10), Gender = "Nam", Email = "daidt@fpt.edu.vn", University = "FPT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234107", FullName = "Bùi Thu Thảo", DateOfBirth = new DateTime(2007, 9, 30), Gender = "Nữ", Email = "25234107@ussh.edu.vn", University = "USSH - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234108", FullName = "Hồ Quang Hiếu", DateOfBirth = new DateTime(2007, 11, 2), Gender = "Nam", Email = "25234108@hcmus.edu.vn", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234109", FullName = "Ngô Thùy Trang", DateOfBirth = new DateTime(2007, 5, 18), Gender = "Nữ", Email = "25234109@gm.uit.edu.vn", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234110", FullName = "Đinh Xuân Hinh", DateOfBirth = new DateTime(2007, 2, 28), Gender = "Nam", Email = "xuanhinh.dinh@rmit.edu.vn", University = "RMIT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234111", FullName = "Lý Bích Ngọc", DateOfBirth = new DateTime(2007, 6, 14), Gender = "Nữ", Email = "ngoclb@fpt.edu.vn", University = "FPT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new Student() { StudentId = "25234112", FullName = "Phan Quốc Toản", DateOfBirth = new DateTime(2007, 8, 9), Gender = "Nam", Email = "25234112@hcmus.edu.vn", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
        }

        // Đặt lại Form về trạng thái nhập mới
        private void ResetForm()
        {
            lvDanhSachSV.SelectedItem = null;
            FormStudent = new Student
            {
                Gender = "Nam",
                University = "UIT - VNUHCM",
                Avatar = "/Test.jpg"
            };
            GetInfor.DataContext = FormStudent;

            ucStudentDetail.Visibility = Visibility.Collapsed;
            txtEmptyDetail.Visibility = Visibility.Visible;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        // Chọn ảnh đại diện cho sinh viên
        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (dialog.ShowDialog() == true)
            {
                // Cập nhật thông qua Data Binding trên đối tượng Student
                FormStudent.Avatar = dialog.FileName;
            }
        }

        // 3. Thêm sinh viên mới (sử dụng thông tin từ FormStudent thông qua Data Binding)
        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra dữ liệu trực tiếp trên đối tượng FormStudent
            if (string.IsNullOrWhiteSpace(FormStudent.StudentId))
            {
                MessageBox.Show("Vui lòng nhập MSSV!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(FormStudent.FullName))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(FormStudent.Email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (FormStudent.DateOfBirth == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(FormStudent.University) || FormStudent.University.Contains("Chọn trường"))
            {
                MessageBox.Show("Vui lòng chọn trường học!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra trùng MSSV với sinh viên khác trong danh sách
            if (dsSinhVien.Any(s => s != FormStudent && s.StudentId.Trim().Equals(FormStudent.StudentId.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("MSSV này đã tồn tại trong danh sách!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Nếu sinh viên này đã có trong danh sách
            if (dsSinhVien.Contains(FormStudent))
            {
                MessageBox.Show("Sinh viên này đã có trong danh sách. Khi bạn chỉnh sửa trên form, thông tin đã được tự động cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // 5. Thêm sinh viên mới vào ObservableCollection
            dsSinhVien.Add(FormStudent);
            lvDanhSachSV.SelectedItem = FormStudent;

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // 5. Xoá sinh viên khỏi danh sách
        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (lvDanhSachSV.SelectedItem is not Student selectedStudent)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên từ danh sách để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên {selectedStudent.FullName} (MSSV: {selectedStudent.StudentId}) không?",
                                         "Xác nhận xóa",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                dsSinhVien.Remove(selectedStudent);
                ResetForm();
            }
        }

        // 6. Chọn sinh viên: thông tin hiển thị trên Form và UserControl qua Binding
        // Khi chỉnh sửa trên Form, thông tin trên ListView và UserControl sẽ tự động cập nhật
        private void lvDanhSachSV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachSV.SelectedItem is Student selected)
            {
                FormStudent = selected;
                GetInfor.DataContext = FormStudent;
                ucStudentDetail.DataContext = FormStudent;

                ucStudentDetail.Visibility = Visibility.Visible;
                txtEmptyDetail.Visibility = Visibility.Collapsed;
            }
            else
            {
                ucStudentDetail.Visibility = Visibility.Collapsed;
                txtEmptyDetail.Visibility = Visibility.Visible;
            }
        }

        // Lọc và tìm kiếm sinh viên
        private bool FilterStudent(object obj)
        {
            if (obj is not Student sv) return false;

            string search = txtSearch?.Text?.Trim().ToLower() ?? "";
            string? filterUni = (cboFilter?.SelectedItem as ComboBoxItem)?.Content.ToString();

            bool matchSearch = string.IsNullOrWhiteSpace(search) ||
                               (!string.IsNullOrEmpty(sv.StudentId) && sv.StudentId.ToLower().Contains(search)) ||
                               (!string.IsNullOrEmpty(sv.FullName) && sv.FullName.ToLower().Contains(search)) ||
                               (!string.IsNullOrEmpty(sv.Email) && sv.Email.ToLower().Contains(search));

            bool matchUni = cboFilter == null ||
                            cboFilter.SelectedIndex == 5 ||
                            cboFilter.SelectedIndex == -1 ||
                            filterUni == "Tất cả trường" ||
                            filterUni == "Chọn trường học" ||
                            sv.University == filterUni;

            return matchSearch && matchUni;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _studentsView?.Refresh();
        }

        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _studentsView?.Refresh();
        }
    }
}