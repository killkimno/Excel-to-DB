namespace ExcelReader
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cbTitanfall = new System.Windows.Forms.CheckBox();
            this.cbShowTrans = new System.Windows.Forms.CheckBox();
            this.tbGoogleTransIndex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSheetName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOriginal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTransIndex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "변환하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(126, 91);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(520, 291);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "울티마 usecode 변환기";
            // 
            // cbTitanfall
            // 
            this.cbTitanfall.AutoSize = true;
            this.cbTitanfall.Location = new System.Drawing.Point(117, 428);
            this.cbTitanfall.Name = "cbTitanfall";
            this.cbTitanfall.Size = new System.Drawing.Size(190, 16);
            this.cbTitanfall.TabIndex = 2;
            this.cbTitanfall.Text = "타이탄폴 전용 - 이름 가져오기";
            this.cbTitanfall.UseVisualStyleBackColor = true;
            // 
            // cbShowTrans
            // 
            this.cbShowTrans.AutoSize = true;
            this.cbShowTrans.Location = new System.Drawing.Point(313, 428);
            this.cbShowTrans.Name = "cbShowTrans";
            this.cbShowTrans.Size = new System.Drawing.Size(178, 16);
            this.cbShowTrans.TabIndex = 3;
            this.cbShowTrans.Text = "구글 번역기 - [미번역] 표시";
            this.cbShowTrans.UseVisualStyleBackColor = true;
            // 
            // tbGoogleTransIndex
            // 
            this.tbGoogleTransIndex.Location = new System.Drawing.Point(258, 541);
            this.tbGoogleTransIndex.Name = "tbGoogleTransIndex";
            this.tbGoogleTransIndex.Size = new System.Drawing.Size(100, 21);
            this.tbGoogleTransIndex.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "구글 번역기 칼럽 인덱스";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "번역문 시트 이름";
            // 
            // tbSheetName
            // 
            this.tbSheetName.Location = new System.Drawing.Point(480, 473);
            this.tbSheetName.Name = "tbSheetName";
            this.tbSheetName.Size = new System.Drawing.Size(129, 21);
            this.tbSheetName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "원문 칼럽 인덱스";
            // 
            // tbOriginal
            // 
            this.tbOriginal.Location = new System.Drawing.Point(258, 476);
            this.tbOriginal.Name = "tbOriginal";
            this.tbOriginal.Size = new System.Drawing.Size(100, 21);
            this.tbOriginal.TabIndex = 8;
            this.tbOriginal.Text = "4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 506);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "번역문 시작 칼럼 인덱스";
            // 
            // tbTransIndex
            // 
            this.tbTransIndex.Location = new System.Drawing.Point(258, 503);
            this.tbTransIndex.Name = "tbTransIndex";
            this.tbTransIndex.Size = new System.Drawing.Size(100, 21);
            this.tbTransIndex.TabIndex = 10;
            this.tbTransIndex.Text = "5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTransIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbOriginal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSheetName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGoogleTransIndex);
            this.Controls.Add(this.cbShowTrans);
            this.Controls.Add(this.cbTitanfall);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "울티마 USECODE 변환";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox cbTitanfall;
        private System.Windows.Forms.CheckBox cbShowTrans;
        private System.Windows.Forms.TextBox tbGoogleTransIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSheetName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTransIndex;
    }
}

