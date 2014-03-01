using System.Windows.Forms;

namespace Xuannh.Ciphertext
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.frmRsaGenerator = new System.Windows.Forms.TabPage();
            this.btnCalcManual = new System.Windows.Forms.Button();
            this.btnExportKey = new System.Windows.Forms.Button();
            this.txtEuler = new System.Windows.Forms.TextBox();
            this.lblEuler = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cckEditable = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRandomGeneration = new System.Windows.Forms.Button();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.btnCalcN = new System.Windows.Forms.Button();
            this.btnCalcD = new System.Windows.Forms.Button();
            this.btnCalcE = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtE = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.lblModulu = new System.Windows.Forms.Label();
            this.lblQ = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cckFileEncryption = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEncMessage = new System.Windows.Forms.TextBox();
            this.txtEncCiphertext = new System.Windows.Forms.TextBox();
            this.btnEncLoadPublicKey = new System.Windows.Forms.Button();
            this.btnEncEncryption = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEncModulus = new System.Windows.Forms.TextBox();
            this.txtEncExponent = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cckFileDecryption = new System.Windows.Forms.CheckBox();
            this.lblFileDecryption = new System.Windows.Forms.Label();
            this.txtDecMessage = new System.Windows.Forms.TextBox();
            this.txtDecCipherText = new System.Windows.Forms.TextBox();
            this.btnDecLoadPrivateKey = new System.Windows.Forms.Button();
            this.btnDecDecryption = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDecModulus = new System.Windows.Forms.TextBox();
            this.txtDecExponent = new System.Windows.Forms.TextBox();
            this.ofdFileEncryption = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.frmRsaGenerator.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.frmRsaGenerator);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(652, 363);
            this.tabControl1.TabIndex = 11;
            // 
            // frmRsaGenerator
            // 
            this.frmRsaGenerator.Controls.Add(this.btnCalcManual);
            this.frmRsaGenerator.Controls.Add(this.btnExportKey);
            this.frmRsaGenerator.Controls.Add(this.txtEuler);
            this.frmRsaGenerator.Controls.Add(this.lblEuler);
            this.frmRsaGenerator.Controls.Add(this.groupBox1);
            this.frmRsaGenerator.Controls.Add(this.btnCalcN);
            this.frmRsaGenerator.Controls.Add(this.btnCalcD);
            this.frmRsaGenerator.Controls.Add(this.btnCalcE);
            this.frmRsaGenerator.Controls.Add(this.label7);
            this.frmRsaGenerator.Controls.Add(this.txtE);
            this.frmRsaGenerator.Controls.Add(this.label10);
            this.frmRsaGenerator.Controls.Add(this.txtD);
            this.frmRsaGenerator.Controls.Add(this.lblModulu);
            this.frmRsaGenerator.Controls.Add(this.lblQ);
            this.frmRsaGenerator.Controls.Add(this.lblP);
            this.frmRsaGenerator.Controls.Add(this.txtQ);
            this.frmRsaGenerator.Controls.Add(this.txtN);
            this.frmRsaGenerator.Controls.Add(this.txtP);
            this.frmRsaGenerator.Location = new System.Drawing.Point(4, 22);
            this.frmRsaGenerator.Name = "frmRsaGenerator";
            this.frmRsaGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.frmRsaGenerator.Size = new System.Drawing.Size(644, 337);
            this.frmRsaGenerator.TabIndex = 0;
            this.frmRsaGenerator.Text = "Rsa Key Generator";
            this.frmRsaGenerator.UseVisualStyleBackColor = true;
            // 
            // btnCalcManual
            // 
            this.btnCalcManual.Location = new System.Drawing.Point(13, 238);
            this.btnCalcManual.Name = "btnCalcManual";
            this.btnCalcManual.Size = new System.Drawing.Size(179, 23);
            this.btnCalcManual.TabIndex = 38;
            this.btnCalcManual.Text = "Tính toán";
            this.btnCalcManual.UseVisualStyleBackColor = true;
            this.btnCalcManual.Click += new System.EventHandler(this.btnCalcManual_Click);
            // 
            // btnExportKey
            // 
            this.btnExportKey.Location = new System.Drawing.Point(212, 238);
            this.btnExportKey.Name = "btnExportKey";
            this.btnExportKey.Size = new System.Drawing.Size(198, 23);
            this.btnExportKey.TabIndex = 36;
            this.btnExportKey.Text = "Tạo file key";
            this.btnExportKey.UseVisualStyleBackColor = true;
            this.btnExportKey.Click += new System.EventHandler(this.btnExportKey_Click);
            // 
            // txtEuler
            // 
            this.txtEuler.Location = new System.Drawing.Point(331, 109);
            this.txtEuler.Name = "txtEuler";
            this.txtEuler.ReadOnly = true;
            this.txtEuler.Size = new System.Drawing.Size(79, 20);
            this.txtEuler.TabIndex = 37;
            // 
            // lblEuler
            // 
            this.lblEuler.AutoSize = true;
            this.lblEuler.Location = new System.Drawing.Point(278, 111);
            this.lblEuler.Name = "lblEuler";
            this.lblEuler.Size = new System.Drawing.Size(52, 13);
            this.lblEuler.TabIndex = 36;
            this.lblEuler.Text = "Euler(n) =";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cckEditable);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnRandomGeneration);
            this.groupBox1.Controls.Add(this.txtMax);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Location = new System.Drawing.Point(426, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 274);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Random data generation";
            // 
            // cckEditable
            // 
            this.cckEditable.AutoSize = true;
            this.cckEditable.Location = new System.Drawing.Point(17, 169);
            this.cckEditable.Name = "cckEditable";
            this.cckEditable.Size = new System.Drawing.Size(64, 17);
            this.cckEditable.TabIndex = 35;
            this.cckEditable.Text = "Editable";
            this.cckEditable.UseVisualStyleBackColor = true;
            this.cckEditable.CheckedChanged += new System.EventHandler(this.cckEditable_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Phạm vi lưa chọn P,Q ( min )";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Phạm vi lưa chọn P,Q ( max )";
            // 
            // btnRandomGeneration
            // 
            this.btnRandomGeneration.Location = new System.Drawing.Point(17, 231);
            this.btnRandomGeneration.Name = "btnRandomGeneration";
            this.btnRandomGeneration.Size = new System.Drawing.Size(167, 23);
            this.btnRandomGeneration.TabIndex = 30;
            this.btnRandomGeneration.Text = "Tự động tính toán";
            this.btnRandomGeneration.UseVisualStyleBackColor = true;
            this.btnRandomGeneration.Click += new System.EventHandler(this.btnRandomGeneration_Click);
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(17, 134);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(167, 20);
            this.txtMax.TabIndex = 32;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(17, 67);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(167, 20);
            this.txtMin.TabIndex = 31;
            // 
            // btnCalcN
            // 
            this.btnCalcN.Location = new System.Drawing.Point(13, 206);
            this.btnCalcN.Name = "btnCalcN";
            this.btnCalcN.Size = new System.Drawing.Size(117, 23);
            this.btnCalcN.TabIndex = 29;
            this.btnCalcN.Text = "Tính N";
            this.btnCalcN.UseVisualStyleBackColor = true;
            this.btnCalcN.Visible = false;
            this.btnCalcN.Click += new System.EventHandler(this.btnCalcN_Click);
            // 
            // btnCalcD
            // 
            this.btnCalcD.Location = new System.Drawing.Point(293, 206);
            this.btnCalcD.Name = "btnCalcD";
            this.btnCalcD.Size = new System.Drawing.Size(117, 23);
            this.btnCalcD.TabIndex = 28;
            this.btnCalcD.Text = "Tính D";
            this.btnCalcD.UseVisualStyleBackColor = true;
            this.btnCalcD.Visible = false;
            this.btnCalcD.Click += new System.EventHandler(this.btnCalcD_Click);
            // 
            // btnCalcE
            // 
            this.btnCalcE.Location = new System.Drawing.Point(150, 206);
            this.btnCalcE.Name = "btnCalcE";
            this.btnCalcE.Size = new System.Drawing.Size(117, 23);
            this.btnCalcE.TabIndex = 27;
            this.btnCalcE.Text = "Tính E";
            this.btnCalcE.UseVisualStyleBackColor = true;
            this.btnCalcE.Visible = false;
            this.btnCalcE.Click += new System.EventHandler(this.btnCalcE_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Số mũ công khai ( E )";
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(149, 139);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(261, 20);
            this.txtE.TabIndex = 23;
            this.txtE.TextChanged += new System.EventHandler(this.txtE_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Số mũ bí mật ( D )";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(149, 172);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(261, 20);
            this.txtD.TabIndex = 21;
            // 
            // lblModulu
            // 
            this.lblModulu.AutoSize = true;
            this.lblModulu.Location = new System.Drawing.Point(10, 109);
            this.lblModulu.Name = "lblModulu";
            this.lblModulu.Size = new System.Drawing.Size(70, 13);
            this.lblModulu.TabIndex = 19;
            this.lblModulu.Text = "Modulus ( N )";
            // 
            // lblQ
            // 
            this.lblQ.AutoSize = true;
            this.lblQ.Location = new System.Drawing.Point(10, 75);
            this.lblQ.Name = "lblQ";
            this.lblQ.Size = new System.Drawing.Size(128, 13);
            this.lblQ.TabIndex = 18;
            this.lblQ.Text = "Số nguyên tố thứ hai ( Q )";
            this.lblQ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(10, 38);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(134, 13);
            this.lblP.TabIndex = 17;
            this.lblP.Text = "Số nguyên tố thứ nhất ( P )";
            // 
            // txtQ
            // 
            this.txtQ.Location = new System.Drawing.Point(149, 73);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(261, 20);
            this.txtQ.TabIndex = 16;
            this.txtQ.TextChanged += new System.EventHandler(this.txtQ_TextChanged);
            this.txtQ.LostFocus += new System.EventHandler(this.txtQ_LostFocus);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(149, 108);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(128, 20);
            this.txtN.TabIndex = 15;
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(149, 38);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(261, 20);
            this.txtP.TabIndex = 14;
            this.txtP.TextChanged += new System.EventHandler(this.txtP_TextChanged);
            this.txtP.LostFocus += new System.EventHandler(this.txtP_LostFocus);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cckFileEncryption);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtEncMessage);
            this.tabPage2.Controls.Add(this.txtEncCiphertext);
            this.tabPage2.Controls.Add(this.btnEncLoadPublicKey);
            this.tabPage2.Controls.Add(this.btnEncEncryption);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtEncModulus);
            this.tabPage2.Controls.Add(this.txtEncExponent);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(644, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Encrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cckFileEncryption
            // 
            this.cckFileEncryption.AutoSize = true;
            this.cckFileEncryption.Location = new System.Drawing.Point(105, 85);
            this.cckFileEncryption.Name = "cckFileEncryption";
            this.cckFileEncryption.Size = new System.Drawing.Size(15, 14);
            this.cckFileEncryption.TabIndex = 13;
            this.cckFileEncryption.UseVisualStyleBackColor = true;
            this.cckFileEncryption.CheckedChanged += new System.EventHandler(this.cckFileEncryption_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "File encryption:";
            // 
            // txtEncMessage
            // 
            this.txtEncMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtEncMessage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtEncMessage.Location = new System.Drawing.Point(98, 114);
            this.txtEncMessage.Multiline = true;
            this.txtEncMessage.Name = "txtEncMessage";
            this.txtEncMessage.Size = new System.Drawing.Size(517, 60);
            this.txtEncMessage.TabIndex = 11;
            this.txtEncMessage.TextChanged += new System.EventHandler(this.txtEncMessage_TextChanged);
            this.txtEncMessage.KeyDown += new KeyEventHandler(this.txtEncMessage_KeyDown);
            // 
            // txtEncCiphertext
            // 
            this.txtEncCiphertext.BackColor = System.Drawing.SystemColors.Window;
            this.txtEncCiphertext.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtEncCiphertext.Location = new System.Drawing.Point(98, 189);
            this.txtEncCiphertext.Multiline = true;
            this.txtEncCiphertext.Name = "txtEncCiphertext";
            this.txtEncCiphertext.ReadOnly = true;
            this.txtEncCiphertext.Size = new System.Drawing.Size(517, 60);
            this.txtEncCiphertext.TabIndex = 10;
            this.txtEncCiphertext.TextChanged += new System.EventHandler(this.txtEncCiphertext_TextChanged);
            this.txtEncCiphertext.KeyDown += new KeyEventHandler(this.txtEncCiphertext_KeyDown);
            // 
            // btnEncLoadPublicKey
            // 
            this.btnEncLoadPublicKey.Location = new System.Drawing.Point(98, 265);
            this.btnEncLoadPublicKey.Name = "btnEncLoadPublicKey";
            this.btnEncLoadPublicKey.Size = new System.Drawing.Size(147, 23);
            this.btnEncLoadPublicKey.TabIndex = 9;
            this.btnEncLoadPublicKey.Text = "Load Publickey";
            this.btnEncLoadPublicKey.UseVisualStyleBackColor = true;
            this.btnEncLoadPublicKey.Click += new System.EventHandler(this.btnEncLoadPublicKey_Click);
            // 
            // btnEncEncryption
            // 
            this.btnEncEncryption.Location = new System.Drawing.Point(288, 265);
            this.btnEncEncryption.Name = "btnEncEncryption";
            this.btnEncEncryption.Size = new System.Drawing.Size(147, 23);
            this.btnEncEncryption.TabIndex = 8;
            this.btnEncEncryption.Text = "Encryption";
            this.btnEncEncryption.UseVisualStyleBackColor = true;
            this.btnEncEncryption.Click += new System.EventHandler(this.btnEncEncryption_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Encryption: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Message: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modulus:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Exponent:";
            // 
            // txtEncModulus
            // 
            this.txtEncModulus.Location = new System.Drawing.Point(98, 52);
            this.txtEncModulus.Name = "txtEncModulus";
            this.txtEncModulus.Size = new System.Drawing.Size(517, 20);
            this.txtEncModulus.TabIndex = 1;
            this.txtEncModulus.TextChanged += new System.EventHandler(this.txtEncModulus_TextChanged);
            // 
            // txtEncExponent
            // 
            this.txtEncExponent.Location = new System.Drawing.Point(98, 19);
            this.txtEncExponent.Name = "txtEncExponent";
            this.txtEncExponent.Size = new System.Drawing.Size(517, 20);
            this.txtEncExponent.TabIndex = 0;
            this.txtEncExponent.TextChanged += new System.EventHandler(this.txtEncExponent_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cckFileDecryption);
            this.tabPage3.Controls.Add(this.lblFileDecryption);
            this.tabPage3.Controls.Add(this.txtDecMessage);
            this.tabPage3.Controls.Add(this.txtDecCipherText);
            this.tabPage3.Controls.Add(this.btnDecLoadPrivateKey);
            this.tabPage3.Controls.Add(this.btnDecDecryption);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.txtDecModulus);
            this.tabPage3.Controls.Add(this.txtDecExponent);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(644, 337);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Decrypt";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cckFileDecryption
            // 
            this.cckFileDecryption.AutoSize = true;
            this.cckFileDecryption.Location = new System.Drawing.Point(105, 89);
            this.cckFileDecryption.Name = "cckFileDecryption";
            this.cckFileDecryption.Size = new System.Drawing.Size(15, 14);
            this.cckFileDecryption.TabIndex = 23;
            this.cckFileDecryption.UseVisualStyleBackColor = true;
            this.cckFileDecryption.CheckedChanged += new System.EventHandler(this.cckFileDecryption_CheckedChanged);
            // 
            // lblFileDecryption
            // 
            this.lblFileDecryption.AutoSize = true;
            this.lblFileDecryption.Location = new System.Drawing.Point(20, 89);
            this.lblFileDecryption.Name = "lblFileDecryption";
            this.lblFileDecryption.Size = new System.Drawing.Size(78, 13);
            this.lblFileDecryption.TabIndex = 22;
            this.lblFileDecryption.Text = "File decryption:";
            // 
            // txtDecMessage
            // 
            this.txtDecMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtDecMessage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDecMessage.Location = new System.Drawing.Point(98, 197);
            this.txtDecMessage.Multiline = true;
            this.txtDecMessage.Name = "txtDecMessage";
            this.txtDecMessage.ReadOnly = true;
            this.txtDecMessage.Size = new System.Drawing.Size(517, 60);
            this.txtDecMessage.TabIndex = 21;
            this.txtDecMessage.TextChanged += new System.EventHandler(this.txtDecMessage_TextChanged);
            this.txtDecMessage.KeyDown += new KeyEventHandler(this.txtDecMessage_KeyDown);
            // 
            // txtDecCipherText
            // 
            this.txtDecCipherText.BackColor = System.Drawing.SystemColors.Window;
            this.txtDecCipherText.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDecCipherText.Location = new System.Drawing.Point(98, 117);
            this.txtDecCipherText.Multiline = true;
            this.txtDecCipherText.Name = "txtDecCipherText";
            this.txtDecCipherText.Size = new System.Drawing.Size(517, 60);
            this.txtDecCipherText.TabIndex = 20;
            this.txtDecCipherText.TextChanged += new System.EventHandler(this.txtDecCipherText_TextChanged);
            this.txtDecCipherText.KeyDown += new KeyEventHandler(this.txtDecCipherText_KeyDown);
            // 
            // btnDecLoadPrivateKey
            // 
            this.btnDecLoadPrivateKey.Location = new System.Drawing.Point(98, 276);
            this.btnDecLoadPrivateKey.Name = "btnDecLoadPrivateKey";
            this.btnDecLoadPrivateKey.Size = new System.Drawing.Size(147, 23);
            this.btnDecLoadPrivateKey.TabIndex = 19;
            this.btnDecLoadPrivateKey.Text = "Load Privatekey";
            this.btnDecLoadPrivateKey.UseVisualStyleBackColor = true;
            this.btnDecLoadPrivateKey.Click += new System.EventHandler(this.btnDecLoadPrivateKey_Click);
            // 
            // btnDecDecryption
            // 
            this.btnDecDecryption.Location = new System.Drawing.Point(288, 276);
            this.btnDecDecryption.Name = "btnDecDecryption";
            this.btnDecDecryption.Size = new System.Drawing.Size(147, 23);
            this.btnDecDecryption.TabIndex = 18;
            this.btnDecDecryption.Text = "Decryption";
            this.btnDecDecryption.UseVisualStyleBackColor = true;
            this.btnDecDecryption.Click += new System.EventHandler(this.btnDecDecryption_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Decryption: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Message: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Modulus:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Exponent:";
            // 
            // txtDecModulus
            // 
            this.txtDecModulus.Location = new System.Drawing.Point(98, 56);
            this.txtDecModulus.Name = "txtDecModulus";
            this.txtDecModulus.Size = new System.Drawing.Size(517, 20);
            this.txtDecModulus.TabIndex = 13;
            this.txtDecModulus.TextChanged += new System.EventHandler(this.txtDecModulus_TextChanged);
            // 
            // txtDecExponent
            // 
            this.txtDecExponent.Location = new System.Drawing.Point(98, 17);
            this.txtDecExponent.Name = "txtDecExponent";
            this.txtDecExponent.Size = new System.Drawing.Size(517, 20);
            this.txtDecExponent.TabIndex = 12;
            this.txtDecExponent.TextChanged += new System.EventHandler(this.txtDecExponent_TextChanged);
            // 
            // ofdFileEncryption
            // 
            this.ofdFileEncryption.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 375);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.frmRsaGenerator.ResumeLayout(false);
            this.frmRsaGenerator.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage frmRsaGenerator;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label lblModulu;
        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.Button btnCalcD;
        private System.Windows.Forms.Button btnCalcE;
        private System.Windows.Forms.Button btnCalcN;
        private System.Windows.Forms.Button btnRandomGeneration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cckEditable;
        private System.Windows.Forms.TextBox txtEuler;
        private System.Windows.Forms.Label lblEuler;
        private System.Windows.Forms.Button btnExportKey;
        private System.Windows.Forms.Button btnEncLoadPublicKey;
        private System.Windows.Forms.Button btnEncEncryption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEncModulus;
        private System.Windows.Forms.TextBox txtEncExponent;
        private System.Windows.Forms.TextBox txtEncMessage;
        private System.Windows.Forms.TextBox txtEncCiphertext;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtDecMessage;
        private System.Windows.Forms.TextBox txtDecCipherText;
        private System.Windows.Forms.Button btnDecLoadPrivateKey;
        private System.Windows.Forms.Button btnDecDecryption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDecModulus;
        private System.Windows.Forms.TextBox txtDecExponent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cckFileEncryption;
        private System.Windows.Forms.OpenFileDialog ofdFileEncryption;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.CheckBox cckFileDecryption;
        private System.Windows.Forms.Label lblFileDecryption;
        private System.Windows.Forms.Button btnCalcManual;
    }
}

