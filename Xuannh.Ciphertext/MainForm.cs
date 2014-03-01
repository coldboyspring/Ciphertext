using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Xuannh.RSACore;

namespace Xuannh.Ciphertext
{
    public partial class MainForm : Form
    {
        private Rsa _rsaObject;
        private bool _isEditable = false;
        //private Int64 _q,_p,_exponent, _modulus, _euler;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "RSA";
            txtMin.Text = "1";
            txtMax.Text = "101";
            cckEditable.Checked = _isEditable;
            txtN.ReadOnly = true;
            txtD.ReadOnly = true;
            txtE.ReadOnly = true;
            btnCalcE.Enabled = false;
            btnCalcD.Enabled = false;
            btnCalcManual.Enabled = false;
            btnExportKey.Enabled = false;
            btnCalcN.Enabled = _isEditable;
            txtQ.ReadOnly = !_isEditable;
            txtP.ReadOnly = !_isEditable;
            txtEncCiphertext.ScrollBars = txtEncMessage.ScrollBars = txtDecCipherText.ScrollBars = txtDecMessage.ScrollBars = ScrollBars.Vertical;
            txtEncCiphertext.Multiline = txtEncMessage.Multiline = txtDecCipherText.Multiline = txtDecMessage.Multiline = true;

            ofdFileEncryption.Filter = "Text document (*.txt)|*.txt";
            ofdFileEncryption.RestoreDirectory = true;
            ofdFileEncryption.Title = "Hãy lựa chọn một file document để encrypt.";
            ofdFileEncryption.FileName = "input";

            sfdSaveFile.Filter = "Text document (*.txt)|*.txt";
            sfdSaveFile.RestoreDirectory = true;
            sfdSaveFile.Title = "Save file document đã được encrypt.";
            ofdFileEncryption.FileName = "output";

            //// convert string to bytes
            //var bytes = new UTF8Encoding().GetBytes("Xuannh");
            //// convert bytes to longs
            //long[] arrLongs = new long[bytes.Count()];
            //for (int i = 0; i < bytes.Count(); i++)
            //{
            //    arrLongs[i] = Convert.ToInt64(bytes[i]);
            //}
            //// convert longs to bytes
            //bool isLittleEndian = true;
            //byte[] data = new byte[arrLongs.Length * 8];
            //int offset = 0;
            //foreach (long value in arrLongs)
            //{
            //    byte[] buffer = BitConverter.GetBytes(value);
            //    if (BitConverter.IsLittleEndian != isLittleEndian)
            //    {
            //        Array.Reverse(buffer);
            //    }
            //    buffer.CopyTo(data, offset);
            //    offset += 8;
            //}
            //var byteResult = data.Where(b => b != 0).ToList();
            //string str = new UTF8Encoding().GetString(byteResult.ToArray());
        }

        private RsaKey loadFileKey(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File không tồn tại: " + filePath);

            try
            {
                List<RsaKey> objs = new List<RsaKey>();
                XDocument xmlDoc = XDocument.Load(filePath);
                objs = (from value in xmlDoc.Descendants("RSAKeyValue")
                        where
                            value.Element("Modulus") != null && value.Element("Exponent") != null
                        select new RsaKey
                        {
                            Exponent = Int64.Parse(value.Element("Exponent").Value),
                            Modulus = Int64.Parse(value.Element("Modulus").Value)
                        }).ToList();
                return objs.Any() ? objs.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc file hoặc file không hợp lệ.", "Lỗi khi load file key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private byte[] readFileToBytes(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("File không tồn tại: " + filePath);
                return File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc file." + ex.Message, "Lỗi khi load file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        #region Tab 1

        private void txtP_TextChanged(object sender, EventArgs e)
        {
            txtE.Text = txtN.Text = txtD.Text = txtEuler.Text = "";
            btnExportKey.Enabled = false;
        }

        private void txtP_LostFocus(object sender, EventArgs e)
        {

        }

        private void txtQ_TextChanged(object sender, EventArgs e)
        {
            txtE.Text = txtN.Text = txtD.Text = txtEuler.Text = "";
            btnExportKey.Enabled = false;
        }

        private void txtQ_LostFocus(object sender, EventArgs e)
        {

        }

        private void txtE_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnCalcN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQ.Text) || string.IsNullOrEmpty(txtP.Text))
            {
                MessageBox.Show("Giá trị Q và P không được bỏ trống ", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int64 numberP = 0, numberQ = 0;
            string inputP = txtP.Text, inputQ = txtQ.Text;
            if (!Int64.TryParse(inputP, out numberP) || numberP <= 0 || !Rsa.IsPrimeNumber(numberP))
            {
                MessageBox.Show("Giá trị P không hợp lệ. P phải là số nguyên tố.", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if (!Int64.TryParse(inputQ, out numberQ) || numberQ <= 0 || !Rsa.IsPrimeNumber(numberQ))
            {
                MessageBox.Show("Giá trị Q không hợp lệ. Q phải là số nguyên tố.", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if (numberP == numberQ)
            {
                MessageBox.Show("Giá trị Q và P không được trùng nhau.", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

            var numberN = Rsa.CalculatePublicModule(numberP, numberQ);
            if (numberN <= 0)
            {
                MessageBox.Show("Giá trị tính toán quá lớn hoặc thông sô đầu vào không hợp lệ.", "Lỗi trong quá trình tính toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtEuler.Text = Rsa.CalculateEuler(Convert.ToInt64(txtP.Text), Convert.ToInt64(txtQ.Text)).ToString();
            txtN.Text = numberN.ToString();
            btnCalcE.Enabled = true;
            btnCalcD.Enabled = false;
        }

        private void btnCalcE_Click(object sender, EventArgs e)
        {
            var euler = Convert.ToInt64(txtEuler.Text);
            if (euler <= 0)
            {
                MessageBox.Show("Giá trị tính toán quá lớn hoặc thông sô đầu vào không hợp lệ.", "Lỗi trong quá trình tính toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtE.Text = Rsa.GeneralPublicExponent(euler, int.Parse(txtMin.Text)).ToString();
            btnCalcD.Enabled = true;
        }

        private void cckEditable_CheckedChanged(object sender, EventArgs e)
        {
            _isEditable = ((CheckBox)sender).Checked;
            btnCalcN.Enabled = _isEditable;
            txtQ.ReadOnly = !_isEditable;
            txtP.ReadOnly = !_isEditable;
            btnCalcManual.Enabled = _isEditable;
        }

        private void btnRandomGeneration_Click(object sender, EventArgs e)
        {
            var maxValue = int.Parse(txtMax.Text);
            var minValue = int.Parse(txtMin.Text);
            if (0 < minValue && minValue < maxValue && maxValue - minValue >= 100)
            {
                _rsaObject = new Rsa(minValue, maxValue);
              
            }
            else
            {
                MessageBox.Show("Giá trị Max - Min không hợp lệ hoặc khoảng cách giữu Min-Max < 100, xin mời nhập lại.", "Sự cố trong quá trình tính toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtP.Text = _rsaObject.FistPrime.ToString();
            txtQ.Text = _rsaObject.SecondPrime.ToString();
            txtN.Text = _rsaObject.Modulus.ToString();
            txtE.Text = _rsaObject.PublicExponent.ToString();
            txtD.Text = _rsaObject.PrivateExponent.ToString();
            txtEuler.Text = _rsaObject.Euler.ToString();
            btnExportKey.Enabled = true;
        }

        private void btnCalcD_Click(object sender, EventArgs e)
        {
            var publicExponent = Convert.ToInt64(txtE.Text);
            var euler = Convert.ToInt64(txtEuler.Text);
            var result = Rsa.CalculatePrivateExponent(publicExponent, euler);
            var i = 0;
            while ((result <= 0 || result == publicExponent) && i < 5000)
            {
                publicExponent = Rsa.GeneralPublicExponent(Convert.ToInt64(txtEuler.Text), int.Parse(txtMin.Text));
                if (publicExponent > 1) result = Rsa.CalculatePrivateExponent(publicExponent, euler);
                i++;
            }
            if (result > 0)
            {
                txtE.Text = publicExponent.ToString();
                txtD.Text = result.ToString();
                if (i > 0)
                {
                    MessageBox.Show("Giá trị publicExponent ( số mũ công khai ) ban đầu không phù hợp nên đã được tính lại.", "Sự cố trong quá trình tính toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Không tính được giá trị publicExponent ( số mũ công khai ). Hãy chọn lại 2 số nguyên tố ban đầu", "Lỗi trong quá trình tính toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQ.Text = txtP.Text = "";
                btnCalcD.Enabled = btnCalcE.Enabled = false;
            }

        }

        private void btnExportKey_Click(object sender, EventArgs e)
        {
            if (_rsaObject.PrivateKey == null || _rsaObject.PublicKey == null)
                _rsaObject.GeneralKeys();
            string privateKey = _rsaObject.ToXmlString(false);
            string publicKey = _rsaObject.ToXmlString(true);
            if (string.IsNullOrEmpty(privateKey) || string.IsNullOrEmpty(publicKey))
            {
                MessageBox.Show("Không thể xuất file key, xin hay thữ lại.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            var folderPath = fbd.SelectedPath;
            File.WriteAllText(folderPath + "\\privatekey.pvk", privateKey);
            File.WriteAllText(folderPath + "\\publickey.pbk", publicKey);
            MessageBox.Show("Cặp key 'privatekey.pvk','publickey.pbk' được lưu với đường dẫn thư mục:\n" + folderPath);
            Process.Start(folderPath);
        }

        private void btnCalcManual_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtQ.Text) || string.IsNullOrEmpty(txtP.Text))
            {
                MessageBox.Show("Giá trị Q và P không được bỏ trống ", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Int64 numberP = 0, numberQ = 0;
            string inputP = txtP.Text, inputQ = txtQ.Text;
            if (!Int64.TryParse(inputP, out numberP) || numberP <= 0 || !Rsa.IsPrimeNumber(numberP))
            {
                MessageBox.Show("Giá trị P không hợp lệ. P phải là số nguyên tố.", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if (!Int64.TryParse(inputQ, out numberQ) || numberQ <= 0 || !Rsa.IsPrimeNumber(numberQ))
            {
                MessageBox.Show("Giá trị Q không hợp lệ. Q phải là số nguyên tố.", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if (numberP == numberQ)
            {
                MessageBox.Show("Giá trị Q và P không được trùng nhau.", "Lỗi nhập tham sô đầu vào", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }
            try
            {


                _rsaObject = new Rsa(numberP, numberQ);
                _rsaObject.GeneralKeys();

                //txtP.Text = _rsaObject.FistPrime.ToString();
                //txtQ.Text = _rsaObject.SecondPrime.ToString();
                txtN.Text = _rsaObject.Modulus.ToString();
                txtE.Text = _rsaObject.PublicExponent.ToString();
                txtD.Text = _rsaObject.PrivateExponent.ToString();
                txtEuler.Text = _rsaObject.Euler.ToString();
                btnExportKey.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Giá trị tính toán quá lớn hoặc thông sô đầu vào không hợp lệ. " + ex.Message, "Lỗi trong quá trình tính toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Tab 2

        private void txtEncExponent_TextChanged(object sender, EventArgs e)
        {
            txtEncCiphertext.Text = txtEncMessage.Text = "";
        }

        private void txtEncModulus_TextChanged(object sender, EventArgs e)
        {
            txtEncCiphertext.Text = txtEncMessage.Text = "";
        }

        private void txtEncMessage_TextChanged(object sender, EventArgs e)
        {
            txtEncCiphertext.Text = "";
            //txtEncMessage.SelectionStart = txtEncMessage.Text.Length;
            //txtEncMessage.ScrollToCaret();
        }

        private void btnEncLoadPublicKey_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "PublicKey files (*.pbk)|*.pbk",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            openFileDialog1.FileName = "publickey.pbk";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var publicKey = loadFileKey(openFileDialog1.FileName);
                    txtEncModulus.Text = publicKey.Modulus.ToString();
                    txtEncExponent.Text = publicKey.Exponent.ToString();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnEncEncryption_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtEncModulus.Text) || string.IsNullOrEmpty(txtEncExponent.Text))
            {
                MessageBox.Show("Yêu cầu nhập đủ các thông số đầu vào.", "Thiếu thông số đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                RsaKey publicKey = new RsaKey
                {
                    Modulus = Convert.ToInt64(txtEncModulus.Text),
                    Exponent = Convert.ToInt64(txtEncExponent.Text)

                };
                if (cckFileEncryption.Checked)
                {
                    ofdFileEncryption.FileName = "input.txt";
                    if (ofdFileEncryption.ShowDialog() == DialogResult.OK)
                    {
                        var input = readFileToBytes(ofdFileEncryption.FileName);
                        var output = Rsa.Encrypt(input, publicKey);
                        var fileExtention = Path.GetExtension(ofdFileEncryption.FileName);
                        switch (fileExtention)
                        {
                            case ".txt":
                                sfdSaveFile.Filter = "Text document (*.txt)|*.txt ";
                                sfdSaveFile.FileName = "Encrypt.txt";
                                break;
                            case ".doc":
                                sfdSaveFile.Filter = "Word document (*.doc)|*.doc ";
                                sfdSaveFile.FileName = "Encrypt.doc";
                                break;
                        }
                        if (sfdSaveFile.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(sfdSaveFile.FileName, output);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtEncMessage.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập nội dung muốn mã hóa.", "Thiếu thông số đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtEncCiphertext.Text = Rsa.Encrypt(txtEncMessage.Text, publicKey);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi trong quá trình xử lý." + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region tap 3
        private void btnDecLoadPrivateKey_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "privatekey files (*.pvk)|*.pvk",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            openFileDialog1.FileName = "privatekey.pvk";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var privateKey = loadFileKey(openFileDialog1.FileName);
                    txtDecModulus.Text = privateKey.Modulus.ToString();
                    txtDecExponent.Text = privateKey.Exponent.ToString();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnDecDecryption_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDecModulus.Text) || string.IsNullOrEmpty(txtDecExponent.Text))
            {
                MessageBox.Show("Yêu cầu nhập đủ các thông số đầu vào.", "Thiếu thông số đầu vào", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                RsaKey privateKey = new RsaKey
                                    {
                                        Modulus = Convert.ToInt64(txtDecModulus.Text),
                                        Exponent = Convert.ToInt64(txtDecExponent.Text)
                                    };
                if (cckFileDecryption.Checked)
                {
                    ofdFileEncryption.FileName = "Encrypt";
                    if (ofdFileEncryption.ShowDialog() == DialogResult.OK)
                    {
                        var input = readFileToBytes(ofdFileEncryption.FileName);
                        var output = Rsa.Decrypt(input, privateKey);
                        var fileExtention = Path.GetExtension(ofdFileEncryption.FileName);
                        switch (fileExtention)
                        {
                            case ".txt":
                                sfdSaveFile.Filter = "Text document (*.txt)|*.txt ";
                                sfdSaveFile.FileName = "Decrypt.txt";
                                break;
                            case ".doc":
                                sfdSaveFile.Filter = "Word document (*.doc)|*.doc ";
                                sfdSaveFile.FileName = "Decrypt.doc";
                                break;
                        }
                        if (sfdSaveFile.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(sfdSaveFile.FileName, output);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtDecCipherText.Text))
                    {
                        MessageBox.Show("Bạn chưa nhập thông điệp cần giải mã hóa.", "Thiếu thông số đầu vào",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    txtDecMessage.Text = Rsa.Decrypt(txtDecCipherText.Text, privateKey);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi trong quá trình xử lý." + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtDecExponent_TextChanged(object sender, EventArgs e)
        {
            txtDecCipherText.Text = txtDecMessage.Text = "";
        }

        private void txtDecModulus_TextChanged(object sender, EventArgs e)
        {
            txtDecCipherText.Text = txtDecMessage.Text = "";
        }

        private void txtDecCipherText_TextChanged(object sender, EventArgs e)
        {
            txtDecMessage.Text = "";
            //txtDecCipherText.SelectionStart = txtDecCipherText.Text.Length;
            //txtDecCipherText.ScrollToCaret();
        }
        #endregion

        private void cckFileEncryption_CheckedChanged(object sender, EventArgs e)
        {
            var isFileEncryption = ((CheckBox)sender).Checked;
            txtEncMessage.Enabled = txtEncCiphertext.Enabled = !isFileEncryption;

        }

        private void cckFileDecryption_CheckedChanged(object sender, EventArgs e)
        {
            var isFileEncryption = ((CheckBox)sender).Checked;
            txtDecMessage.Enabled = txtDecCipherText.Enabled = !isFileEncryption;
        }

        private void txtEncCiphertext_TextChanged(object sender, EventArgs e)
        {
            //txtEncCiphertext.SelectionStart = txtEncCiphertext.Text.Length;
            //txtEncCiphertext.ScrollToCaret();
        }

        private void txtDecMessage_TextChanged(object sender, EventArgs e)
        {
            //txtDecMessage.SelectionStart = txtDecMessage.Text.Length;
            //txtDecMessage.ScrollToCaret();
        }

        private void txtDecMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
              var textbox = (TextBox) sender;
                if (textbox != null)
                {
                    textbox.SelectAll();
                }
            }
        }


        private void txtEncMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                var textbox = (TextBox)sender;
                if (textbox != null)
                {
                    textbox.SelectAll();
                }
            }
        }

        private void txtEncCiphertext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                var textbox = (TextBox)sender;
                if (textbox != null)
                {
                    textbox.SelectAll();
                }
            }
        }

        private void txtDecCipherText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                var textbox = (TextBox)sender;
                if (textbox != null)
                {
                    textbox.SelectAll();
                }
            }
        }
    }
}
