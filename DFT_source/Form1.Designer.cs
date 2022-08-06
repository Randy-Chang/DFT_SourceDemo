namespace DFT_SourceDemo
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plDFTamp_lambda = new System.Windows.Forms.Panel();
            this.plDFTamp_freq = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNmax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.cmbUnit4 = new System.Windows.Forms.ComboBox();
            this.tbNfreq = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUnit3 = new System.Windows.Forms.ComboBox();
            this.cmbUnit2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLambdaEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLambdaStart = new System.Windows.Forms.TextBox();
            this.tbDx = new System.Windows.Forms.TextBox();
            this.tbLambdaCenter = new System.Windows.Forms.TextBox();
            this.cmbUnit1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plDFT_freq = new System.Windows.Forms.Panel();
            this.plDFT_lambda = new System.Windows.Forms.Panel();
            this.plTimeStep = new System.Windows.Forms.Panel();
            this.btnSetStrpX = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbStepXmin = new System.Windows.Forms.TextBox();
            this.lbStepXmax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.plTimeStepMovie = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plDFTamp_lambda
            // 
            this.plDFTamp_lambda.Location = new System.Drawing.Point(392, 5);
            this.plDFTamp_lambda.Name = "plDFTamp_lambda";
            this.plDFTamp_lambda.Size = new System.Drawing.Size(600, 300);
            this.plDFTamp_lambda.TabIndex = 0;
            // 
            // plDFTamp_freq
            // 
            this.plDFTamp_freq.Location = new System.Drawing.Point(392, 311);
            this.plDFTamp_freq.Name = "plDFTamp_freq";
            this.plDFTamp_freq.Size = new System.Drawing.Size(600, 300);
            this.plDFTamp_freq.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNmax);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbState);
            this.groupBox1.Controls.Add(this.cmbUnit4);
            this.groupBox1.Controls.Add(this.tbNfreq);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbUnit3);
            this.groupBox1.Controls.Add(this.cmbUnit2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLambdaEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCalculate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbMode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbLambdaStart);
            this.groupBox1.Controls.Add(this.tbDx);
            this.groupBox1.Controls.Add(this.tbLambdaCenter);
            this.groupBox1.Controls.Add(this.cmbUnit1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F);
            this.groupBox1.Location = new System.Drawing.Point(18, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 321);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // tbNmax
            // 
            this.tbNmax.Location = new System.Drawing.Point(141, 194);
            this.tbNmax.Name = "tbNmax";
            this.tbNmax.Size = new System.Drawing.Size(92, 27);
            this.tbNmax.TabIndex = 26;
            this.tbNmax.Text = "2^10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "n max：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 12F);
            this.label12.Location = new System.Drawing.Point(239, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "unit：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 12F);
            this.label11.Location = new System.Drawing.Point(239, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "unit：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 12F);
            this.label10.Location = new System.Drawing.Point(239, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "unit：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 12F);
            this.label9.Location = new System.Drawing.Point(239, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "unit：";
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbState.Location = new System.Drawing.Point(59, 285);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(28, 16);
            this.lbState.TabIndex = 14;
            this.lbState.Text = "....";
            // 
            // cmbUnit4
            // 
            this.cmbUnit4.FormattingEnabled = true;
            this.cmbUnit4.Location = new System.Drawing.Point(289, 133);
            this.cmbUnit4.Name = "cmbUnit4";
            this.cmbUnit4.Size = new System.Drawing.Size(58, 24);
            this.cmbUnit4.TabIndex = 13;
            // 
            // tbNfreq
            // 
            this.tbNfreq.Location = new System.Drawing.Point(141, 163);
            this.tbNfreq.Name = "tbNfreq";
            this.tbNfreq.Size = new System.Drawing.Size(92, 27);
            this.tbNfreq.TabIndex = 12;
            this.tbNfreq.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "dx：";
            // 
            // cmbUnit3
            // 
            this.cmbUnit3.FormattingEnabled = true;
            this.cmbUnit3.Location = new System.Drawing.Point(289, 100);
            this.cmbUnit3.Name = "cmbUnit3";
            this.cmbUnit3.Size = new System.Drawing.Size(58, 24);
            this.cmbUnit3.TabIndex = 10;
            // 
            // cmbUnit2
            // 
            this.cmbUnit2.FormattingEnabled = true;
            this.cmbUnit2.Location = new System.Drawing.Point(289, 67);
            this.cmbUnit2.Name = "cmbUnit2";
            this.cmbUnit2.Size = new System.Drawing.Size(58, 24);
            this.cmbUnit2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "n freq：";
            // 
            // tbLambdaEnd
            // 
            this.tbLambdaEnd.Location = new System.Drawing.Point(141, 97);
            this.tbLambdaEnd.Name = "tbLambdaEnd";
            this.tbLambdaEnd.Size = new System.Drawing.Size(92, 27);
            this.tbLambdaEnd.TabIndex = 8;
            this.tbLambdaEnd.Text = "2500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "wavelength end：";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(168, 273);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(105, 40);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F);
            this.label6.Location = new System.Drawing.Point(6, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "DFT Mode：";
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Location = new System.Drawing.Point(141, 227);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(156, 24);
            this.cmbMode.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "wavelength start：";
            // 
            // tbLambdaStart
            // 
            this.tbLambdaStart.Location = new System.Drawing.Point(141, 64);
            this.tbLambdaStart.Name = "tbLambdaStart";
            this.tbLambdaStart.Size = new System.Drawing.Size(92, 27);
            this.tbLambdaStart.TabIndex = 5;
            this.tbLambdaStart.Text = "100";
            // 
            // tbDx
            // 
            this.tbDx.Location = new System.Drawing.Point(141, 130);
            this.tbDx.Name = "tbDx";
            this.tbDx.Size = new System.Drawing.Size(92, 27);
            this.tbDx.TabIndex = 4;
            this.tbDx.Text = "5";
            // 
            // tbLambdaCenter
            // 
            this.tbLambdaCenter.Location = new System.Drawing.Point(141, 31);
            this.tbLambdaCenter.Name = "tbLambdaCenter";
            this.tbLambdaCenter.Size = new System.Drawing.Size(92, 27);
            this.tbLambdaCenter.TabIndex = 3;
            this.tbLambdaCenter.Text = "500";
            // 
            // cmbUnit1
            // 
            this.cmbUnit1.FormattingEnabled = true;
            this.cmbUnit1.Location = new System.Drawing.Point(289, 34);
            this.cmbUnit1.Name = "cmbUnit1";
            this.cmbUnit1.Size = new System.Drawing.Size(58, 24);
            this.cmbUnit1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "wavelength center：";
            // 
            // plDFT_freq
            // 
            this.plDFT_freq.Location = new System.Drawing.Point(998, 311);
            this.plDFT_freq.Name = "plDFT_freq";
            this.plDFT_freq.Size = new System.Drawing.Size(600, 300);
            this.plDFT_freq.TabIndex = 15;
            // 
            // plDFT_lambda
            // 
            this.plDFT_lambda.Location = new System.Drawing.Point(998, 5);
            this.plDFT_lambda.Name = "plDFT_lambda";
            this.plDFT_lambda.Size = new System.Drawing.Size(600, 300);
            this.plDFT_lambda.TabIndex = 14;
            // 
            // plTimeStep
            // 
            this.plTimeStep.Location = new System.Drawing.Point(392, 617);
            this.plTimeStep.Name = "plTimeStep";
            this.plTimeStep.Size = new System.Drawing.Size(600, 300);
            this.plTimeStep.TabIndex = 2;
            // 
            // btnSetStrpX
            // 
            this.btnSetStrpX.Location = new System.Drawing.Point(159, 811);
            this.btnSetStrpX.Name = "btnSetStrpX";
            this.btnSetStrpX.Size = new System.Drawing.Size(43, 28);
            this.btnSetStrpX.TabIndex = 16;
            this.btnSetStrpX.Text = "Set";
            this.btnSetStrpX.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F);
            this.label7.Location = new System.Drawing.Point(46, 746);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Step X min：";
            // 
            // lbStepXmin
            // 
            this.lbStepXmin.Location = new System.Drawing.Point(146, 746);
            this.lbStepXmin.Name = "lbStepXmin";
            this.lbStepXmin.Size = new System.Drawing.Size(92, 22);
            this.lbStepXmin.TabIndex = 19;
            this.lbStepXmin.Text = "0";
            // 
            // lbStepXmax
            // 
            this.lbStepXmax.Location = new System.Drawing.Point(146, 774);
            this.lbStepXmax.Name = "lbStepXmax";
            this.lbStepXmax.Size = new System.Drawing.Size(92, 22);
            this.lbStepXmax.TabIndex = 20;
            this.lbStepXmax.Text = "1000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 12F);
            this.label13.Location = new System.Drawing.Point(43, 774);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 16);
            this.label13.TabIndex = 21;
            this.label13.Text = "Step X max：";
            // 
            // plTimeStepMovie
            // 
            this.plTimeStepMovie.Location = new System.Drawing.Point(998, 617);
            this.plTimeStepMovie.Name = "plTimeStepMovie";
            this.plTimeStepMovie.Size = new System.Drawing.Size(600, 300);
            this.plTimeStepMovie.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1603, 924);
            this.Controls.Add(this.plTimeStepMovie);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbStepXmax);
            this.Controls.Add(this.lbStepXmin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSetStrpX);
            this.Controls.Add(this.plTimeStep);
            this.Controls.Add(this.plDFT_freq);
            this.Controls.Add(this.plDFT_lambda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.plDFTamp_freq);
            this.Controls.Add(this.plDFTamp_lambda);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plDFTamp_lambda;
        private System.Windows.Forms.Panel plDFTamp_freq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLambdaStart;
        private System.Windows.Forms.TextBox tbDx;
        private System.Windows.Forms.TextBox tbLambdaCenter;
        private System.Windows.Forms.ComboBox cmbUnit1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ComboBox cmbUnit3;
        private System.Windows.Forms.ComboBox cmbUnit2;
        private System.Windows.Forms.TextBox tbLambdaEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUnit4;
        private System.Windows.Forms.TextBox tbNfreq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Panel plDFT_freq;
        private System.Windows.Forms.Panel plDFT_lambda;
        private System.Windows.Forms.Panel plTimeStep;
        private System.Windows.Forms.Button btnSetStrpX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox lbStepXmin;
        private System.Windows.Forms.TextBox lbStepXmax;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbNmax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel plTimeStepMovie;
    }
}

