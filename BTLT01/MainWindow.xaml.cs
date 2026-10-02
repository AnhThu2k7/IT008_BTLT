using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BTLT01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<SinhVien> dsSinhVien = new ObservableCollection<SinhVien>();
        public MainWindow()
        {
            InitializeComponent();

            lvDanhSachSV.ItemsSource = dsSinhVien;

            TaoDuLieuMau();
        }

        // Tạo dữ liệu mẫu cho danh sách sinh viên
        private void TaoDuLieuMau()
        {
            dsSinhVien.Add(new SinhVien() { StudentId = "25520001", FullName = "Nguyễn Văn Anh", DateOfBirth = new DateTime(2007, 3, 14), Gender = "Nam", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25520002", FullName = "Trần Thị Bé", DateOfBirth = new DateTime(2007, 8, 20), Gender = "Nữ", University = "USSH - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25520003", FullName = "Lê Hoàng Cường", DateOfBirth = new DateTime(2007, 12, 5), Gender = "Nam", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234104", FullName = "Phạm Minh Đạt", DateOfBirth = new DateTime(2007, 1, 15), Gender = "Nam", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234105", FullName = "Vũ Hải Yến", DateOfBirth = new DateTime(2007, 4, 22), Gender = "Nữ", University = "RMIT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234106", FullName = "Đặng Trọng Đại", DateOfBirth = new DateTime(2007, 7, 10), Gender = "Nam", University = "FPT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234107", FullName = "Bùi Thu Thảo", DateOfBirth = new DateTime(2007, 9, 30), Gender = "Nữ", University = "USSH - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234108", FullName = "Hồ Quang Hiếu", DateOfBirth = new DateTime(2007, 11, 2), Gender = "Nam", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234109", FullName = "Ngô Thùy Trang", DateOfBirth = new DateTime(2007, 5, 18), Gender = "Nữ", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234110", FullName = "Đinh Xuân Hinh", DateOfBirth = new DateTime(2007, 2, 28), Gender = "Nam", University = "RMIT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234111", FullName = "Lý Bích Ngọc", DateOfBirth = new DateTime(2007, 6, 14), Gender = "Nữ", University = "FPT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234112", FullName = "Phan Quốc Toản", DateOfBirth = new DateTime(2007, 8, 9), Gender = "Nam", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234113", FullName = "Trịnh Thảo Nguyên", DateOfBirth = new DateTime(2007, 10, 25), Gender = "Nữ", University = "USSH - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234114", FullName = "Lương Vỹ Minh", DateOfBirth = new DateTime(2007, 3, 11), Gender = "Nam", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234115", FullName = "Châu Tấn Phát", DateOfBirth = new DateTime(2007, 1, 5), Gender = "Nam", University = "RMIT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234116", FullName = "Vương Lệ Quân", DateOfBirth = new DateTime(2007, 7, 7), Gender = "Nữ", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234117", FullName = "Nguyễn Trọng Tấn", DateOfBirth = new DateTime(2007, 12, 19), Gender = "Nam", University = "FPT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234118", FullName = "Trần Ngọc Hà", DateOfBirth = new DateTime(2007, 2, 14), Gender = "Nữ", University = "USSH - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234119", FullName = "Lê Tuấn Kiệt", DateOfBirth = new DateTime(2007, 11, 11), Gender = "Nam", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234120", FullName = "Hoàng Nhã Kỳ", DateOfBirth = new DateTime(2007, 8, 3), Gender = "Nữ", University = "RMIT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234121", FullName = "Đoàn Gia Huy", DateOfBirth = new DateTime(2007, 5, 27), Gender = "Nam", University = "HCMUS - VNUHCM", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234122", FullName = "Đào Tuyết Mai", DateOfBirth = new DateTime(2007, 10, 8), Gender = "Nữ", University = "FPT University", Avatar = "/Test.jpg" });
            dsSinhVien.Add(new SinhVien() { StudentId = "25234123", FullName = "Võ Minh Trí", DateOfBirth = new DateTime(2007, 9, 16), Gender = "Nam", University = "UIT - VNUHCM", Avatar = "/Test.jpg" });
        }

        // Chọn ảnh đại diện cho sinh viên
        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            // Mở FileDialog
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";

            if (dialog.ShowDialog() == true)
            {
                imgAddAvatar.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        // Thêm sinh viên mới vào danh sách
        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!");
                return;
            }

            if (dpDateOfBirth.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh!");
                return;
            }

            if (rbMale.IsChecked != true && rbFemale.IsChecked != true)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }

            if (cboUniversity.SelectedIndex == 5)
            {
                MessageBox.Show("Vui lòng chọn trường!");
                return;
            }

            SinhVien newSinhVien = new SinhVien {
                StudentId = txtStudentId.Text,
                FullName = txtFullName.Text,
                DateOfBirth = dpDateOfBirth.SelectedDate,
                Gender = (rbMale.IsChecked == true) ? "Nam" : "Nữ",
                University = cboUniversity.Text,
                Avatar = (imgAddAvatar.Source != null) ? ((BitmapImage)imgAddAvatar.Source).UriSource.ToString() : null
            };
            
            dsSinhVien.Add(newSinhVien);
        }

        // Xoá sinh viên khỏi danh sách
        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            // Nếu chọn 1 sinh viên để xoá
            if (lvDanhSachSV.SelectedItems.Count == 1)
            {
                dsSinhVien.Remove((SinhVien)lvDanhSachSV.SelectedItem);
                return;
            }

            // Nếu chọn nhiều sinh viên để xoá
            List<SinhVien> selectedStudents = lvDanhSachSV.SelectedItems.Cast<SinhVien>().ToList();
            foreach (SinhVien x in selectedStudents)
            {
                dsSinhVien.Remove(x);
            }
        }

        // Lọc dữ liệu
        private void filterData()
        {
            if (lvDanhSachSV == null || dsSinhVien == null)
            {
                return;
            }

            string userSearched = txtSearch.Text.ToLower();
            string? filterUniversity = (cboFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            var results = dsSinhVien.Where(
                sv => (string.IsNullOrWhiteSpace(userSearched) || sv.StudentId.ToLower().Contains(userSearched) || sv.FullName.ToLower().Contains(userSearched)) 
                && (cboFilter.SelectedIndex == 5 || sv.University == filterUniversity))
                .ToList();

            lvDanhSachSV.ItemsSource = results;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterData();
        }

        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterData();
        }

        // Hiển thị thông tin chi tiết của sinh viên khi chọn trong danh sách
        private void lvDanhSachSV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucUserDetail.Visibility = lvDanhSachSV.SelectedItem != null ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}