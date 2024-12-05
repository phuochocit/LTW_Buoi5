using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap3
{
    public partial class frm_Soanthaovanban : Form
    {
        public frm_Soanthaovanban()
        {
            InitializeComponent();
        }

        private void tsm_Dinhdang_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                rtxt_Ghi.ForeColor = fontDlg.Color;
                rtxt_Ghi.Font = fontDlg.Font;
            }
        }

        private void frm_Soanthaovanban_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cmb_Font.Items.Add(font.Name);
            }
            cmb_Font.SelectedItem = "Tahoma"; // Giá trị mặc định

            // Thêm danh sách Size
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                cmb_Size.Items.Add(size);
            }
            cmb_Size.SelectedItem = 14; // Giá trị mặc định
        }

        private void btn_Taomoi_Click(object sender, EventArgs e)
        {
            rtxt_Ghi.Clear();
            cmb_Font.SelectedItem = "Tahoma";
            cmb_Size.SelectedItem = 14;
            rtxt_Ghi.Font = new Font("Tahoma", 14);
        }

        private void tsm_Taomoi_Click(object sender, EventArgs e)
        {
            rtxt_Ghi.Clear();
            cmb_Font.SelectedItem = "Tahoma";
            cmb_Size.SelectedItem = 14;
            rtxt_Ghi.Font = new Font("Tahoma", 14);
        }

        private void tsm_Mofile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Plain Text (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (filePath.EndsWith(".rtf"))
                    {
                        rtxt_Ghi.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        rtxt_Ghi.Text = File.ReadAllText(filePath);
                    }
                }
            }
        }

        private string currentFilePath = null;

        private void tsm_Luu_Click(object sender, EventArgs e)
        {
            if (currentFilePath == null) // Nếu chưa lưu
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        rtxt_Ghi.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                        MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo");
                    }
                }
            }
            else // Nếu đã lưu trước đó
            {
                rtxt_Ghi.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo");
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (currentFilePath == null) // Nếu chưa lưu
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        rtxt_Ghi.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                        MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo");
                    }
                }
            }
            else // Nếu đã lưu trước đó
            {
                rtxt_Ghi.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Văn bản đã được lưu thành công!", "Thông báo");
            }
        }

        private void btn_Dam_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu SelectionFont là null
            if (rtxt_Ghi.SelectionFont != null)
            {
                FontStyle style = rtxt_Ghi.SelectionFont.Style;
                // Chuyển đổi trạng thái Bold
                style = rtxt_Ghi.SelectionFont.Bold ? style & ~FontStyle.Bold : style | FontStyle.Bold;
                rtxt_Ghi.SelectionFont = new Font(rtxt_Ghi.SelectionFont, style);
            }
            else
            {
                MessageBox.Show("Không thể thay đổi kiểu chữ vì không có font hoặc vùng chọn không hợp lệ.", "Lỗi");
            }
        }

        private void btn_Nghieng_Click(object sender, EventArgs e)
        {
            if (rtxt_Ghi.SelectionFont != null)
            {
                FontStyle style = rtxt_Ghi.SelectionFont.Style;
                style = rtxt_Ghi.SelectionFont.Italic ? style & ~FontStyle.Italic : style | FontStyle.Italic;
                rtxt_Ghi.SelectionFont = new Font(rtxt_Ghi.SelectionFont, style);
            }
            else
            {
                MessageBox.Show("Không thể thay đổi kiểu chữ vì không có font hoặc vùng chọn không hợp lệ.", "Lỗi");
            }
        }

        private void btn_Gachchan_Click(object sender, EventArgs e)
        {
            if (rtxt_Ghi.SelectionFont != null)
            {
                FontStyle style = rtxt_Ghi.SelectionFont.Style;
                style = rtxt_Ghi.SelectionFont.Underline ? style & ~FontStyle.Underline : style | FontStyle.Underline;
                rtxt_Ghi.SelectionFont = new Font(rtxt_Ghi.SelectionFont, style);
            }
            else
            {
                MessageBox.Show("Không thể thay đổi kiểu chữ vì không có font hoặc vùng chọn không hợp lệ.", "Lỗi");
            }
        }

        private void cmb_Font_Click(object sender, EventArgs e)
        {
            if (rtxt_Ghi.SelectionFont != null)
            {
                // Lấy Font được chọn từ ComboBox
                string selectedFont = cmb_Font.SelectedItem.ToString();
                FontStyle currentStyle = rtxt_Ghi.SelectionFont.Style;
                float currentSize = rtxt_Ghi.SelectionFont.Size;

                // Áp dụng Font mới cho vùng văn bản được chọn
                rtxt_Ghi.SelectionFont = new Font(selectedFont, currentSize, currentStyle);
            }
            else
            {
                MessageBox.Show("Không thể thay đổi font. Vui lòng chọn văn bản trước!", "Thông báo");
            }
        }

        private void cmb_Size_Click(object sender, EventArgs e)
        {
            if (rtxt_Ghi.SelectionFont != null)
            {
                // Lấy kích thước chữ từ ComboBox
                float selectedSize = Convert.ToSingle(cmb_Size.SelectedItem);
                string currentFont = rtxt_Ghi.SelectionFont.FontFamily.Name;
                FontStyle currentStyle = rtxt_Ghi.SelectionFont.Style;

                // Áp dụng kích thước mới cho vùng văn bản được chọn
                rtxt_Ghi.SelectionFont = new Font(currentFont, selectedSize, currentStyle);
            }
            else
            {
                MessageBox.Show("Không thể thay đổi kích thước. Vui lòng chọn văn bản trước!", "Thông báo");
            }
        }
    }
}

