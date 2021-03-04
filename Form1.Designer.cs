
namespace RandomSens
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.box_Max_Sens = new System.Windows.Forms.TextBox();
            this.box_Min_Sens = new System.Windows.Forms.TextBox();
            this.box_Timestep = new System.Windows.Forms.TextBox();
            this.box_Spread = new System.Windows.Forms.TextBox();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_basesens = new System.Windows.Forms.Label();
            this.label_maxsens = new System.Windows.Forms.Label();
            this.label_minsens = new System.Windows.Forms.Label();
            this.label_timestep = new System.Windows.Forms.Label();
            this.label_spread = new System.Windows.Forms.Label();
            this.cbox_Type = new System.Windows.Forms.ComboBox();
            this.label_smoothing = new System.Windows.Forms.Label();
            this.box_Smoothing = new System.Windows.Forms.TextBox();
            this.btn_Regen_Curve = new System.Windows.Forms.Button();
            this.sensCurveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_mean = new System.Windows.Forms.Label();
            this.label_std = new System.Windows.Forms.Label();
            this.label_sensmultiplier = new System.Windows.Forms.Label();
            this.box_BaseSens = new System.Windows.Forms.TextBox();
            this.btn_Load_Defaults = new System.Windows.Forms.Button();
            this.btn_Save_Defaults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.box_Curve_Timestep = new System.Windows.Forms.TextBox();
            this.box_Mean = new System.Windows.Forms.TextBox();
            this.box_CurrentSens = new System.Windows.Forms.TextBox();
            this.box_Std = new System.Windows.Forms.TextBox();
            this.label_curve_completion = new System.Windows.Forms.Label();
            this.box_Curve_Completion = new System.Windows.Forms.TextBox();
            this.label_Pause_Toggle = new System.Windows.Forms.Label();
            this.box_Pause_Toggle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sensCurveChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(15, 430);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 50);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Enabled = false;
            this.btn_Pause.Location = new System.Drawing.Point(95, 430);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(75, 50);
            this.btn_Pause.TabIndex = 1;
            this.btn_Pause.Text = "Pause";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // box_Max_Sens
            // 
            this.box_Max_Sens.Location = new System.Drawing.Point(214, 64);
            this.box_Max_Sens.Name = "box_Max_Sens";
            this.box_Max_Sens.Size = new System.Drawing.Size(38, 20);
            this.box_Max_Sens.TabIndex = 4;
            this.box_Max_Sens.Validating += new System.ComponentModel.CancelEventHandler(this.box_Max_Sens_Validating);
            this.box_Max_Sens.Validated += new System.EventHandler(this.box_Validated);
            // 
            // box_Min_Sens
            // 
            this.box_Min_Sens.Location = new System.Drawing.Point(214, 90);
            this.box_Min_Sens.Name = "box_Min_Sens";
            this.box_Min_Sens.Size = new System.Drawing.Size(38, 20);
            this.box_Min_Sens.TabIndex = 5;
            this.box_Min_Sens.Validating += new System.ComponentModel.CancelEventHandler(this.box_Min_Sens_Validating);
            this.box_Min_Sens.Validated += new System.EventHandler(this.box_Validated);
            // 
            // box_Timestep
            // 
            this.box_Timestep.Location = new System.Drawing.Point(214, 116);
            this.box_Timestep.Name = "box_Timestep";
            this.box_Timestep.Size = new System.Drawing.Size(38, 20);
            this.box_Timestep.TabIndex = 6;
            this.box_Timestep.Validating += new System.ComponentModel.CancelEventHandler(this.box_Timestep_Validating);
            this.box_Timestep.Validated += new System.EventHandler(this.box_Validated);
            // 
            // box_Spread
            // 
            this.box_Spread.Location = new System.Drawing.Point(214, 170);
            this.box_Spread.Name = "box_Spread";
            this.box_Spread.Size = new System.Drawing.Size(38, 20);
            this.box_Spread.TabIndex = 7;
            this.box_Spread.Validating += new System.ComponentModel.CancelEventHandler(this.box_Spread_Validating);
            this.box_Spread.Validated += new System.EventHandler(this.box_Validated);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(12, 12);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(58, 13);
            this.label_Type.TabIndex = 8;
            this.label_Type.Text = "Curve type";
            // 
            // label_basesens
            // 
            this.label_basesens.AutoSize = true;
            this.label_basesens.Location = new System.Drawing.Point(12, 38);
            this.label_basesens.Name = "label_basesens";
            this.label_basesens.Size = new System.Drawing.Size(81, 13);
            this.label_basesens.TabIndex = 9;
            this.label_basesens.Text = "Base Sensitivity";
            // 
            // label_maxsens
            // 
            this.label_maxsens.AutoSize = true;
            this.label_maxsens.Location = new System.Drawing.Point(12, 64);
            this.label_maxsens.Name = "label_maxsens";
            this.label_maxsens.Size = new System.Drawing.Size(121, 13);
            this.label_maxsens.TabIndex = 10;
            this.label_maxsens.Text = "Max Sensitivity Multiplier";
            // 
            // label_minsens
            // 
            this.label_minsens.AutoSize = true;
            this.label_minsens.Location = new System.Drawing.Point(12, 90);
            this.label_minsens.Name = "label_minsens";
            this.label_minsens.Size = new System.Drawing.Size(118, 13);
            this.label_minsens.TabIndex = 11;
            this.label_minsens.Text = "Min Sensitivity Multiplier";
            // 
            // label_timestep
            // 
            this.label_timestep.AutoSize = true;
            this.label_timestep.Location = new System.Drawing.Point(12, 116);
            this.label_timestep.Name = "label_timestep";
            this.label_timestep.Size = new System.Drawing.Size(50, 13);
            this.label_timestep.TabIndex = 12;
            this.label_timestep.Text = "Timestep";
            // 
            // label_spread
            // 
            this.label_spread.AutoSize = true;
            this.label_spread.Location = new System.Drawing.Point(12, 170);
            this.label_spread.Name = "label_spread";
            this.label_spread.Size = new System.Drawing.Size(41, 13);
            this.label_spread.TabIndex = 13;
            this.label_spread.Text = "Spread";
            // 
            // cbox_Type
            // 
            this.cbox_Type.FormattingEnabled = true;
            this.cbox_Type.Items.AddRange(new object[] {
            "Aggressive Curve",
            "Log Normal Curve"});
            this.cbox_Type.Location = new System.Drawing.Point(95, 12);
            this.cbox_Type.Name = "cbox_Type";
            this.cbox_Type.Size = new System.Drawing.Size(156, 21);
            this.cbox_Type.TabIndex = 14;
            this.cbox_Type.SelectedIndexChanged += new System.EventHandler(this.cbox_Type_SelectedIndexChanged);
            // 
            // label_smoothing
            // 
            this.label_smoothing.AutoSize = true;
            this.label_smoothing.Location = new System.Drawing.Point(12, 196);
            this.label_smoothing.Name = "label_smoothing";
            this.label_smoothing.Size = new System.Drawing.Size(57, 13);
            this.label_smoothing.TabIndex = 16;
            this.label_smoothing.Text = "Smoothing";
            // 
            // box_Smoothing
            // 
            this.box_Smoothing.Location = new System.Drawing.Point(214, 196);
            this.box_Smoothing.Name = "box_Smoothing";
            this.box_Smoothing.Size = new System.Drawing.Size(38, 20);
            this.box_Smoothing.TabIndex = 15;
            this.box_Smoothing.Validating += new System.ComponentModel.CancelEventHandler(this.box_Smoothing_Validating);
            this.box_Smoothing.Validated += new System.EventHandler(this.box_Validated);
            // 
            // btn_Regen_Curve
            // 
            this.btn_Regen_Curve.Location = new System.Drawing.Point(176, 430);
            this.btn_Regen_Curve.Name = "btn_Regen_Curve";
            this.btn_Regen_Curve.Size = new System.Drawing.Size(75, 50);
            this.btn_Regen_Curve.TabIndex = 17;
            this.btn_Regen_Curve.Text = "Regenerate Curve";
            this.btn_Regen_Curve.UseVisualStyleBackColor = true;
            this.btn_Regen_Curve.Click += new System.EventHandler(this.btn_Regen_Curve_Click);
            // 
            // sensCurveChart
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.Title = "Time";
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.Title = "Sensitivity multiplier";
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.Name = "ChartArea1";
            this.sensCurveChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.sensCurveChart.Legends.Add(legend1);
            this.sensCurveChart.Location = new System.Drawing.Point(271, 12);
            this.sensCurveChart.Name = "sensCurveChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.sensCurveChart.Series.Add(series1);
            this.sensCurveChart.Size = new System.Drawing.Size(895, 468);
            this.sensCurveChart.TabIndex = 18;
            this.sensCurveChart.Text = "Sensitivity Curve";
            title1.Name = "Title1";
            title1.Text = "Sensitivity Curve";
            this.sensCurveChart.Titles.Add(title1);
            // 
            // label_mean
            // 
            this.label_mean.AutoSize = true;
            this.label_mean.Location = new System.Drawing.Point(12, 276);
            this.label_mean.Name = "label_mean";
            this.label_mean.Size = new System.Drawing.Size(119, 13);
            this.label_mean.TabIndex = 19;
            this.label_mean.Text = "Generated curve mean:";
            // 
            // label_std
            // 
            this.label_std.AutoSize = true;
            this.label_std.Location = new System.Drawing.Point(12, 303);
            this.label_std.Name = "label_std";
            this.label_std.Size = new System.Drawing.Size(110, 13);
            this.label_std.TabIndex = 20;
            this.label_std.Text = "Generated curve std: ";
            // 
            // label_sensmultiplier
            // 
            this.label_sensmultiplier.AutoSize = true;
            this.label_sensmultiplier.Location = new System.Drawing.Point(12, 354);
            this.label_sensmultiplier.Name = "label_sensmultiplier";
            this.label_sensmultiplier.Size = new System.Drawing.Size(112, 13);
            this.label_sensmultiplier.TabIndex = 21;
            this.label_sensmultiplier.Text = "Current sens multiplier:";
            // 
            // box_BaseSens
            // 
            this.box_BaseSens.Location = new System.Drawing.Point(214, 38);
            this.box_BaseSens.Name = "box_BaseSens";
            this.box_BaseSens.Size = new System.Drawing.Size(38, 20);
            this.box_BaseSens.TabIndex = 3;
            this.box_BaseSens.Validating += new System.ComponentModel.CancelEventHandler(this.box_Base_Sens_Validating);
            this.box_BaseSens.Validated += new System.EventHandler(this.box_Validated);
            // 
            // btn_Load_Defaults
            // 
            this.btn_Load_Defaults.Location = new System.Drawing.Point(133, 380);
            this.btn_Load_Defaults.Name = "btn_Load_Defaults";
            this.btn_Load_Defaults.Size = new System.Drawing.Size(118, 45);
            this.btn_Load_Defaults.TabIndex = 22;
            this.btn_Load_Defaults.Text = "Restore default settings";
            this.btn_Load_Defaults.UseVisualStyleBackColor = true;
            this.btn_Load_Defaults.Click += new System.EventHandler(this.btn_Load_Defaults_Click);
            // 
            // btn_Save_Defaults
            // 
            this.btn_Save_Defaults.Location = new System.Drawing.Point(15, 379);
            this.btn_Save_Defaults.Name = "btn_Save_Defaults";
            this.btn_Save_Defaults.Size = new System.Drawing.Size(112, 45);
            this.btn_Save_Defaults.TabIndex = 23;
            this.btn_Save_Defaults.Text = "Save default settings";
            this.btn_Save_Defaults.UseVisualStyleBackColor = true;
            this.btn_Save_Defaults.Click += new System.EventHandler(this.btn_Save_Defaults_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Curve Timestep";
            // 
            // box_Curve_Timestep
            // 
            this.box_Curve_Timestep.Location = new System.Drawing.Point(214, 144);
            this.box_Curve_Timestep.Name = "box_Curve_Timestep";
            this.box_Curve_Timestep.Size = new System.Drawing.Size(38, 20);
            this.box_Curve_Timestep.TabIndex = 25;
            // 
            // box_Mean
            // 
            this.box_Mean.Location = new System.Drawing.Point(198, 276);
            this.box_Mean.Name = "box_Mean";
            this.box_Mean.ReadOnly = true;
            this.box_Mean.Size = new System.Drawing.Size(53, 20);
            this.box_Mean.TabIndex = 26;
            this.box_Mean.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // box_CurrentSens
            // 
            this.box_CurrentSens.Location = new System.Drawing.Point(141, 354);
            this.box_CurrentSens.Name = "box_CurrentSens";
            this.box_CurrentSens.ReadOnly = true;
            this.box_CurrentSens.Size = new System.Drawing.Size(111, 20);
            this.box_CurrentSens.TabIndex = 27;
            this.box_CurrentSens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // box_Std
            // 
            this.box_Std.Location = new System.Drawing.Point(198, 302);
            this.box_Std.Name = "box_Std";
            this.box_Std.ReadOnly = true;
            this.box_Std.Size = new System.Drawing.Size(53, 20);
            this.box_Std.TabIndex = 28;
            this.box_Std.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_curve_completion
            // 
            this.label_curve_completion.AutoSize = true;
            this.label_curve_completion.Location = new System.Drawing.Point(12, 328);
            this.label_curve_completion.Name = "label_curve_completion";
            this.label_curve_completion.Size = new System.Drawing.Size(92, 13);
            this.label_curve_completion.TabIndex = 29;
            this.label_curve_completion.Text = "Curve completion:";
            // 
            // box_Curve_Completion
            // 
            this.box_Curve_Completion.Location = new System.Drawing.Point(214, 328);
            this.box_Curve_Completion.Name = "box_Curve_Completion";
            this.box_Curve_Completion.ReadOnly = true;
            this.box_Curve_Completion.Size = new System.Drawing.Size(37, 20);
            this.box_Curve_Completion.TabIndex = 30;
            this.box_Curve_Completion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Pause_Toggle
            // 
            this.label_Pause_Toggle.AutoSize = true;
            this.label_Pause_Toggle.Location = new System.Drawing.Point(12, 222);
            this.label_Pause_Toggle.Name = "label_Pause_Toggle";
            this.label_Pause_Toggle.Size = new System.Drawing.Size(115, 13);
            this.label_Pause_Toggle.TabIndex = 31;
            this.label_Pause_Toggle.Text = "Quick start/stop toggle";
            // 
            // box_Pause_Toggle
            // 
            this.box_Pause_Toggle.Location = new System.Drawing.Point(214, 222);
            this.box_Pause_Toggle.Name = "box_Pause_Toggle";
            this.box_Pause_Toggle.ReadOnly = true;
            this.box_Pause_Toggle.Size = new System.Drawing.Size(38, 20);
            this.box_Pause_Toggle.TabIndex = 32;
            this.box_Pause_Toggle.DoubleClick += new System.EventHandler(this.box_Pause_Toggle_DoubleClick);
            this.box_Pause_Toggle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.box_Pause_Toggle_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 493);
            this.Controls.Add(this.box_Pause_Toggle);
            this.Controls.Add(this.label_Pause_Toggle);
            this.Controls.Add(this.box_Curve_Completion);
            this.Controls.Add(this.label_curve_completion);
            this.Controls.Add(this.box_Std);
            this.Controls.Add(this.box_CurrentSens);
            this.Controls.Add(this.box_Mean);
            this.Controls.Add(this.box_Curve_Timestep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Save_Defaults);
            this.Controls.Add(this.btn_Load_Defaults);
            this.Controls.Add(this.label_sensmultiplier);
            this.Controls.Add(this.label_std);
            this.Controls.Add(this.label_mean);
            this.Controls.Add(this.sensCurveChart);
            this.Controls.Add(this.btn_Regen_Curve);
            this.Controls.Add(this.label_smoothing);
            this.Controls.Add(this.box_Smoothing);
            this.Controls.Add(this.cbox_Type);
            this.Controls.Add(this.label_spread);
            this.Controls.Add(this.label_timestep);
            this.Controls.Add(this.label_minsens);
            this.Controls.Add(this.label_maxsens);
            this.Controls.Add(this.label_basesens);
            this.Controls.Add(this.label_Type);
            this.Controls.Add(this.box_Spread);
            this.Controls.Add(this.box_Timestep);
            this.Controls.Add(this.box_Min_Sens);
            this.Controls.Add(this.box_Max_Sens);
            this.Controls.Add(this.box_BaseSens);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.btn_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Random-Sens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.sensCurveChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.TextBox box_BaseSens;
        private System.Windows.Forms.TextBox box_Max_Sens;
        private System.Windows.Forms.TextBox box_Min_Sens;
        private System.Windows.Forms.TextBox box_Timestep;
        private System.Windows.Forms.TextBox box_Spread;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.Label label_basesens;
        private System.Windows.Forms.Label label_maxsens;
        private System.Windows.Forms.Label label_minsens;
        private System.Windows.Forms.Label label_timestep;
        private System.Windows.Forms.Label label_spread;
        private System.Windows.Forms.ComboBox cbox_Type;
        private System.Windows.Forms.Label label_smoothing;
        private System.Windows.Forms.TextBox box_Smoothing;
        private System.Windows.Forms.Button btn_Regen_Curve;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensCurveChart;
        private System.Windows.Forms.Label label_mean;
        private System.Windows.Forms.Label label_std;
        private System.Windows.Forms.Label label_sensmultiplier;
        private System.Windows.Forms.Button btn_Load_Defaults;
        private System.Windows.Forms.Button btn_Save_Defaults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox box_Curve_Timestep;
        private System.Windows.Forms.TextBox box_Mean;
        private System.Windows.Forms.TextBox box_CurrentSens;
        private System.Windows.Forms.TextBox box_Std;
        private System.Windows.Forms.Label label_curve_completion;
        private System.Windows.Forms.TextBox box_Curve_Completion;
        private System.Windows.Forms.Label label_Pause_Toggle;
        private System.Windows.Forms.TextBox box_Pause_Toggle;
    }
}

