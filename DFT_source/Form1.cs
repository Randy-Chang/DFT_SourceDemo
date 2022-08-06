using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace DFT_SourceDemo
{
    public partial class Form1 : Form
    {
        delegate void dgSetText(Control cntr, string text);
        delegate void dgSetColor(Control cntr, Color color);
        delegate void dgSetEnable(Control cntr, bool b);

        public ZedGraphControl graphDFT_amp_lambda, graphDFT_amp_freq, graphDFT_lambda, graphDFT_freq, graphTimeStep, graphTimeStepMovie;

        enum enUnit { mm = -3, um = -6, nm = -9 }
        enum enMmode { CutFrequency, CutWavelength }
        double[,] rd, snorm;
        double[] snorm_amp, snorm_pha, esource_record, sourceProfile_record, lambda, frequency, omega, lambda_nm;

        double pi, cc, tpi, dx, dt, lambda_center, freq_center, omega_center, nmax, PowUnit,
               lambda_start, lambda_end, omega_start, omega_end, period, ndelay, gwidth;
        
        int nfreq;
        bool First = true;

        public Form1()
        {
            InitializeComponent();

            InitComboboxUnit(cmbUnit1);
            InitComboboxUnit(cmbUnit2);
            InitComboboxUnit(cmbUnit3);
            InitComboboxUnit(cmbUnit4);

            InitComboboxUnitForMode(cmbMode);

            InitFileCompare_oneY(out graphDFT_amp_lambda, plDFTamp_lambda, "Spectrum", "wavelength (m)", "Amplitude (m^2)");
            InitFileCompare_oneY(out graphDFT_amp_freq, plDFTamp_freq, "Spectrum", "frequency (Hz)", "Amplitude (m^2)");
            InitFileCompare_twoY(out graphDFT_lambda, plDFT_lambda, "Spectrum", "wavelength (m)", "Amplitude (m^2)", "Phase(radian)");
            InitFileCompare_twoY(out graphDFT_freq, plDFT_freq, "Spectrum", "frequency (Hz)", "Amplitude (m^2)", "Phase(radian)");

            InitFileCompare_twoY(out graphTimeStep, plTimeStep, "Time Step", "Step", "Source", "Source Profile");
            InitFileCompare_twoY(out graphTimeStepMovie, plTimeStepMovie, "Time Step Movie", "Step", "Source", "Source Profile");

            UI_AssignEvent();
        }

        #region  Init UI
        private void InitComboboxUnit(ComboBox cmb)
        {
            foreach (enUnit item in Enum.GetValues(typeof(enUnit)))
            {
                cmb.Items.Add(item);
            }
            cmb.SelectedIndex = 0;
        }

        private void InitComboboxUnitForMode(ComboBox cmb)
        {
            foreach (enMmode item in Enum.GetValues(typeof(enMmode)))
            {
                cmb.Items.Add(item);
            }
            cmb.SelectedIndex = (int)enMmode.CutFrequency;
        }
        #endregion

        #region  Init and Build Chart
        private void InitFileCompare_oneY(out ZedGraphControl graph, Panel pl, string Title, string XTitle, string YTitle)
        {
            graph = new ZedGraphControl();
            graph.Parent = pl;
            graph.Dock = DockStyle.Fill;

            // Init_Graph_oneY
            GraphPane pane = graph.GraphPane;

            //pane.Title.IsVisible = false;
            pane.Legend.IsVisible = false;
            pane.YAxisList.Clear();
            pane.Y2AxisList.Clear();

            // Set the Titles
            pane.Title.Text = Title;  //Graph Title
            pane.Title.FontSpec.Size = 25;

            pane.XAxis.Title.Text = XTitle;
            pane.XAxis.Title.FontSpec.Size = 20;

            // Show the x axis grid
            pane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis scale red
            YAxis yAxis1 = new YAxis("value");
            pane.YAxisList.Add(yAxis1);

            pane.YAxis.Title.Text = YTitle;
            pane.YAxis.Title.FontSpec.Size = 20;
            //pane.YAxis.Title.Text = "Vf (V)";
            pane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Color = Color.Blue;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            pane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            pane.YAxis.Scale.Align = AlignP.Inside;
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 10;

            graph.Invalidate();
        }

        private void InitFileCompare_twoY(out ZedGraphControl graph, Panel pl, string Title, string XTitle, string YTitle1, string YTitle2)
        {
            graph = new ZedGraphControl();
            graph.Parent = pl;
            graph.Dock = DockStyle.Fill;

            // Init_Graph_oneY
            GraphPane pane = graph.GraphPane;

            //pane.Title.IsVisible = false;
            pane.Legend.IsVisible = false;
            pane.YAxisList.Clear();
            pane.Y2AxisList.Clear();

            // Set the Titles
            pane.Title.Text = Title;  //Graph Title
            pane.Title.FontSpec.Size = 25;

            pane.XAxis.Title.Text = XTitle;
            pane.XAxis.Title.FontSpec.Size = 20;

            // Show the x axis grid
            pane.XAxis.MajorGrid.IsVisible = true;

            // Make the Y axis scale red
            YAxis yAxis1 = new YAxis("Amplitude");
            pane.YAxisList.Add(yAxis1);

            pane.YAxis.Title.Text = YTitle1;
            pane.YAxis.Title.FontSpec.Size = 20;
            pane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Title.FontSpec.FontColor = Color.Blue;
            pane.YAxis.Color = Color.Blue;

            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            pane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            pane.YAxis.Scale.Align = AlignP.Inside;
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 10;

            // Enable the Y2 axis display
            Y2Axis y2Axis1 = new Y2Axis("Phase");
            pane.Y2AxisList.Add(y2Axis1);
            pane.Y2Axis.IsVisible = true;
            pane.Y2Axis.Title.Text = YTitle2;
            pane.Y2Axis.Title.FontSpec.Size = 20;
            pane.Y2Axis.Scale.FontSpec.FontColor = Color.Green;
            pane.Y2Axis.Title.FontSpec.FontColor = Color.Green;
            pane.Y2Axis.Color = Color.Green;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            pane.Y2Axis.MajorTic.IsOpposite = false;
            pane.Y2Axis.MinorTic.IsOpposite = false;
            // Don't display the Y2 zero line
            pane.Y2Axis.MajorGrid.IsZeroLine = false;
            // Display the Y2 axis grid lines
            pane.Y2Axis.MajorGrid.IsVisible = false;
            // Align the Y2 axis labels so they are flush to the axis
            pane.Y2Axis.Scale.Align = AlignP.Inside;
            pane.Y2Axis.Scale.Min = 0;
            pane.Y2Axis.Scale.Max = 6;

            graph.Invalidate();
        }

        public void BuildGraphDeviation_oneFile(ZedGraphControl graph, double n, double[] Y)
        {
            //清空曲線            
            GraphPane pane = graph.GraphPane;
            pane.CurveList.Clear();

            //載入資料
            PointPairList PointPairs = new PointPairList();

            for (int i = 0; i < n; i++)
            {
                PointPairs.Add(i+1, Y[i]);
            }
            
            LineItem myCurve = pane.AddCurve("File1", PointPairs, Color.Blue, SymbolType.Circle);
            myCurve.Symbol.Size = 6;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.IsVisible = true;
            myCurve.Symbol.Border.IsAntiAlias = true;
            myCurve.Line.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Blue);

            pane.YAxis.Title.IsVisible = true;

            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 1000;

            pane.YAxis.Scale.Min = Y.Min() * 1.2;
            pane.YAxis.Scale.Max = Y.Max() * 1.2;

            graph.AxisChange();
            graph.Invalidate();
        }

        public void BuildGraphDeviation_twoFile(ZedGraphControl graph, double n, double[] Y1, double[] Y2)
        {
            //清空曲線            
            GraphPane pane = graph.GraphPane;
            pane.CurveList.Clear();

            //載入資料
            PointPairList PointPairs1 = new PointPairList();
            PointPairList PointPairs2 = new PointPairList();
            LineItem myCurve;
            for (int i = 0; i < n; i++)
            {
                PointPairs1.Add(i + 1, Y1[i]);
                PointPairs2.Add(i + 1, Y2[i]);
            }


            myCurve = pane.AddCurve("File1", PointPairs1, Color.Blue, SymbolType.Circle);
            myCurve.IsY2Axis = false;
            myCurve.YAxisIndex = 0;
            myCurve.Symbol.Size = 6;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.IsVisible = true;
            myCurve.Symbol.Border.IsAntiAlias = true;
            myCurve.Line.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Blue);

            myCurve = pane.AddCurve("File2", PointPairs2, Color.Green, SymbolType.Circle);
            myCurve.IsY2Axis = true;
            myCurve.YAxisIndex = 0;
            myCurve.Symbol.Size = 6;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.IsVisible = true;
            myCurve.Symbol.Border.IsAntiAlias = true;
            myCurve.Line.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Green);

            //pane.YAxis.Title.IsVisible = true;
            //pane.Y2Axis.Title.IsVisible = true;

            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = n;

            //pane.YAxis.Scale.Min = Y1.Min();
            //pane.YAxis.Scale.Max = Y1.Max() * 1.2;

            //pane.Y2Axis.Scale.Min = Y2.Min() * 1.2;
            //pane.Y2Axis.Scale.Max = Y2.Max() * 1.2;

            pane.YAxis.Scale.Min = -1;
            pane.YAxis.Scale.Max = 1;

            pane.Y2Axis.Scale.Min = 0;
            pane.Y2Axis.Scale.Max = 1;

            graph.AxisChange();
            graph.Invalidate();
        }

        public void BuildGraphDeviation_oneFile(ZedGraphControl graph, double[] X, double[] Y)
        {
            //清空曲線            
            GraphPane pane = graph.GraphPane;
            pane.CurveList.Clear();

            //載入資料
            PointPairList PointPairs = new PointPairList();

            PointPairs.Add( X, Y);

            LineItem myCurve = pane.AddCurve("File1", PointPairs, Color.Blue, SymbolType.Circle);
            myCurve.Symbol.Size = 6;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.IsVisible = true;
            myCurve.Symbol.Border.IsAntiAlias = true;
            myCurve.Line.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Blue);

            pane.YAxis.Title.IsVisible = true;

            pane.XAxis.Scale.Min = X.Min()*0.09;
            pane.XAxis.Scale.Max = X.Max()*1.1;

            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = Y.Max()*1.2;

            graph.AxisChange();
            graph.Invalidate();
        }

        public void BuildGraphDeviation_twoFile(ZedGraphControl graph, double[] X, double[] Y1, double[] Y2)
        {
            //清空曲線            
            GraphPane pane = graph.GraphPane;
            pane.CurveList.Clear();

            //載入資料
            PointPairList PointPairs1 = new PointPairList();
            PointPairList PointPairs2 = new PointPairList();
            LineItem myCurve;
            PointPairs1.Add(X, Y1);
            PointPairs2.Add(X, Y2);

            myCurve = pane.AddCurve("File1", PointPairs1, Color.Blue, SymbolType.Circle);
            myCurve.IsY2Axis = false;
            myCurve.YAxisIndex = 0;
            myCurve.Symbol.Size = 6;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.IsVisible = true;
            myCurve.Symbol.Border.IsAntiAlias = true;
            myCurve.Line.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Blue);

            myCurve = pane.AddCurve("File2", PointPairs2, Color.Green, SymbolType.Circle);
            myCurve.IsY2Axis = true;
            myCurve.YAxisIndex = 0;
            myCurve.Symbol.Size = 6;
            myCurve.Symbol.Border.IsVisible = true;
            myCurve.Symbol.IsVisible = true;
            myCurve.Symbol.Border.IsAntiAlias = true;
            myCurve.Line.IsVisible = true;
            myCurve.Symbol.Fill = new Fill(Color.Green);

            //pane.YAxis.Title.IsVisible = true;
            //pane.Y2Axis.Title.IsVisible = true;

            pane.XAxis.Scale.Min = X.Min() * 0.09;
            pane.XAxis.Scale.Max = X.Max() * 1.1;

            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = Y1.Max() * 1.2;

            pane.Y2Axis.Scale.Min = Y2.Min()*1.2;
            pane.Y2Axis.Scale.Max = Y2.Max()*1.2;

            graph.AxisChange();
            graph.Invalidate();
        }
        
        public void ClearGraphPane(ZedGraphControl z1)
        {
            z1.GraphPane.CurveList.Clear();
            z1.GraphPane.GraphObjList.Clear();
            z1.GraphPane.XAxis.Type = AxisType.Linear;
            z1.GraphPane.XAxis.Scale.TextLabels = null;
            z1.Invalidate();
        }
        #endregion

        #region Ui 指派
        void UI_AssignEvent()
        {
            btnCalculate.Click += btnCalculate_Click;
            btnSetStrpX.Click += btnSetStrpX_Click;
            cmbUnit1.SelectedIndexChanged += cmbUnit1_SelectedIndexChanged;
            cmbUnit2.SelectedIndexChanged += cmbUnit2_SelectedIndexChanged;
            cmbUnit3.SelectedIndexChanged += cmbUnit3_SelectedIndexChanged;
            cmbUnit4.SelectedIndexChanged += cmbUnit4_SelectedIndexChanged;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (First)
            {
                First = !First;
            }
            else if (!First)
            {
                ClearGraphPane(graphDFT_amp_lambda);
                ClearGraphPane(graphDFT_amp_freq);
                ClearGraphPane(graphDFT_lambda);
                ClearGraphPane(graphDFT_freq);
                ClearGraphPane(graphTimeStep);
            }

            if (cmbUnit1.Text == null || cmbUnit1.Text == "")
            {
                MessageBox.Show("請選擇單位\n\rPlease select unit");
                return;
            }
            else if (cmbMode.Text == null || cmbMode.Text == "")
            {
                MessageBox.Show("請選擇模式\n\rPlease select Mode");
                return;
            }

            lbState.Text = "Processing";
            lbState.ForeColor = Color.Red;

            SetParameter();

            Thread thread = new Thread(Run);
            thread.Start();
            SetEnable(btnCalculate, false);
        }

        private void btnSetStrpX_Click(object sender, EventArgs e)
        {
            graphTimeStep.GraphPane.XAxis.Scale.Min = Convert.ToDouble(lbStepXmin.Text);
            graphTimeStep.GraphPane.XAxis.Scale.Max = Convert.ToDouble(lbStepXmax.Text);
            graphTimeStep.AxisChange();
            graphTimeStep.Invalidate();
        }

        private void cmbUnit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbUnit2.Text = cmbUnit1.Text;
            cmbUnit3.Text = cmbUnit1.Text;
            cmbUnit4.Text = cmbUnit1.Text;
        }

        private void cmbUnit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbUnit1.Text = cmbUnit2.Text;
            cmbUnit3.Text = cmbUnit2.Text;
            cmbUnit4.Text = cmbUnit2.Text;
        }

        private void cmbUnit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbUnit1.Text = cmbUnit3.Text;
            cmbUnit2.Text = cmbUnit3.Text;
            cmbUnit4.Text = cmbUnit3.Text;
        }

        private void cmbUnit4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbUnit1.Text = cmbUnit4.Text;
            cmbUnit2.Text = cmbUnit4.Text;
            cmbUnit3.Text = cmbUnit4.Text;

        }
        #endregion

        #region DFT 相關函式
        void Run()
        {
            Thread.Sleep(10);
            TimeLoop();

            for (int i = 0; i < nfreq; i++)
            {
                lambda_nm[i] = lambda[i] * Math.Pow(10, 9);
                frequency[i] = omega[i] / tpi;
            }

            BuildGraphDeviation_oneFile(graphDFT_amp_lambda, lambda, snorm_amp);
            BuildGraphDeviation_oneFile(graphDFT_amp_freq, frequency, snorm_amp);

            BuildGraphDeviation_twoFile(graphDFT_lambda, lambda, snorm_amp, snorm_pha);
            BuildGraphDeviation_twoFile(graphDFT_freq, frequency, snorm_amp, snorm_pha);

            BuildGraphDeviation_twoFile(graphTimeStep, nmax, esource_record, sourceProfile_record);

            SetColor(lbState, Color.Green);
            SetText(lbState, "Finished");
            SetEnable(btnCalculate, true);
        }

        void TimeLoop()
        {
            for (int i = 1; i < nmax; i++)
            {
                double t2 = (i + 1) * dt;
                double tt2 = (i + 1 - ndelay) * dt;

                // source 
                double sinusoid = Math.Sin(omega_center * tt2);

                double sourceProfile = Math.Exp(-Math.Pow(i + 1 - ndelay, 2) / gwidth);

                double esource = sinusoid * sourceProfile;

                // DFT Updating
                DFT(i, t2, esource, sourceProfile);

                esource_record[i] = esource;
                sourceProfile_record[i] = sourceProfile;

                BuildGraphDeviation_twoFile(graphTimeStepMovie, nmax, esource_record, sourceProfile_record);
            }

            for (int i_freq = 0; i_freq < nfreq; i_freq++)
            {
                snorm_amp[i_freq] = Math.Pow(snorm[i_freq, 0], 2) + Math.Pow(snorm[i_freq, 1], 2);
                snorm_pha[i_freq] = Math.Atan2(snorm[i_freq, 1], snorm[i_freq, 0]);
            }

            double Amp_Max = snorm_amp.Max();
            double esource_record_Max = 1;// esource_record.Max();
            double sourceProfile_record_Max = 1;// sourceProfile_record.Max();
            // Normalized
            for (int i_freq = 0; i_freq < nfreq; i_freq++)
            {
                snorm_amp[i_freq] = snorm_amp[i_freq] / Amp_Max;
                esource_record[i_freq] = esource_record[i_freq] / esource_record_Max;
                sourceProfile_record[i_freq] = sourceProfile_record[i_freq] / sourceProfile_record_Max;
            }

        }

        void DFT(int i, double t2, double esource, double sourceProfile)
        {
            for (int i_freq = 0; i_freq < nfreq; i_freq++)
            {
                rd[i_freq, 0] = Math.Cos(omega[i_freq] * t2);
                rd[i_freq, 1] = Math.Sin(omega[i_freq] * t2);
            }

            for (int i_freq = 0; i_freq < nfreq; i_freq++)
            {
                for (int i_12 = 0; i_12 < 2; i_12++)
                {
                    snorm[i_freq, i_12] = snorm[i_freq, i_12] + esource * rd[i_freq, i_12];
                }
            }
            esource_record[i] = esource;
            sourceProfile_record[i] = sourceProfile;
        }

        public void SetParameter()
        {
            if (cmbUnit1.Text == "nm")
                PowUnit = -9;
            else if (cmbUnit1.Text == "um")
                PowUnit = -6;
            else if (cmbUnit1.Text == "mm")
                PowUnit = -3;

            //===== Fundamental constants =====

            pi = Math.PI;
            cc = 3 * Math.Pow(10, 8);
            tpi = 2.0 * pi;
            dx = Convert.ToDouble(tbDx.Text) * Math.Pow(10, PowUnit);
            dt = dx / (2.0 * cc);

            lambda_center = Convert.ToDouble(tbLambdaCenter.Text) * Math.Pow(10, PowUnit);
            freq_center = cc / lambda_center;
            omega_center = tpi * freq_center;

            //int nmax = Convert.ToInt32( 2 * Math.Pow(10, 14) );
            //nmax = 2 * Math.Pow(10, 4);
            double Exponential;
            JudgeExponential(tbNmax.Text, out Exponential);
            nmax = Exponential;

            // ===== DFT parameter =====
            lambda_start = Convert.ToDouble(tbLambdaStart.Text) * Math.Pow(10, PowUnit);
            lambda_end = Convert.ToDouble(tbLambdaEnd.Text) * Math.Pow(10, PowUnit);

            omega_start = tpi * cc / lambda_end;
            omega_end = tpi * cc / lambda_start;

            nfreq = Convert.ToInt32(tbNfreq.Text);
            period = 1 / freq_center / dt;
            ndelay = 2 * period;

            gwidth = Math.Pow(ndelay, 2) / 40;

            InitArray();
        }

        public void InitArray()
        {
            rd = new double[nfreq, 2];
            snorm = new double[nfreq, 2];
            lambda = new double[nfreq];
            lambda_nm = new double[nfreq];

            omega = new double[nfreq];
            frequency = new double[nfreq];


            snorm_amp = new double[nfreq];
            snorm_pha = new double[nfreq];

            esource_record = new double[(int)nmax];
            sourceProfile_record = new double[(int)nmax];

            if (cmbMode.Text == enMmode.CutWavelength.ToString())
            {
                double span = lambda_end - lambda_start;
                for (int i = 0; i < nfreq; i++)
                {
                    lambda[i] = lambda_start + span * (i) / (nfreq - 1);
                    omega[i] = tpi * cc / lambda[i];
                }
            }
            else if (cmbMode.Text == enMmode.CutFrequency.ToString())
            {
                double span = omega_end - omega_start;
                for (int i = 0; i < nfreq; i++)
                {
                    omega[i] = omega_start + span * (i) / (nfreq - 1);
                    lambda[i] = cc / (omega[i] * tpi);
                }
            }
        }

        void JudgeExponential(string Numeric, out double Exponential)
        {
            double Num, Base, Index;
            int indB, indI;
            if (Numeric.Contains("^") && Numeric.Contains("*"))
            {
                indB = Numeric.IndexOf("*");
                indI = Numeric.IndexOf("^");

                Num = Convert.ToDouble(Numeric.Substring(0, indB));
                Base = Convert.ToDouble(Numeric.Substring(indB + 1, indI - indB - 1));
                Index = Convert.ToDouble(Numeric.Substring(indI + 1));

                Exponential = Num * Math.Pow(Base, Index);
            }
            else if (Numeric.Contains("^"))
            {
                indI = Numeric.IndexOf("^");

                Base = Convert.ToDouble(Numeric.Substring(0, indI));
                Index = Convert.ToDouble(Numeric.Substring(indI + 1));

                Exponential = Math.Pow(Base, Index);
            }
            else
            {
                Num = Convert.ToDouble(Numeric);
                Exponential = Num;
            }
        }
        #endregion

        void SetText(Control cntr, string text)
        {
            if (cntr.InvokeRequired)
            {
                dgSetText d = new dgSetText(SetText);
                Invoke(d, new object[] { cntr, text });
            }
            else
                cntr.Text = text;
        }

        void SetColor(Control cntr, Color color)
        {
            if (cntr.InvokeRequired)
            {
                dgSetColor d = new dgSetColor(SetColor);
                Invoke(d, new object[] { cntr, color });
            }
            else
                cntr.ForeColor = color;
        }

        void SetEnable(Control cntr, bool b)
        {
            if (cntr.InvokeRequired)
            {
                dgSetEnable d = new dgSetEnable(SetEnable);
                Invoke(d, new object[] { cntr, b });
            }
            else
                cntr.Enabled = b;
        }
    }
}
