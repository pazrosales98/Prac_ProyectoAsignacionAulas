
namespace UNICAH.Formularios.Reportes
{
    partial class frmReporteClaseAula
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClasesAulasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReportes = new UNICAH.Formularios.Reportes.DsReportes();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAula = new System.Windows.Forms.TextBox();
            this.btnBuscarAula = new System.Windows.Forms.Button();
            this.btnBuscarPeriodo = new System.Windows.Forms.Button();
            this.ClasesAulasTableAdapter = new UNICAH.Formularios.Reportes.DsReportesTableAdapters.ClasesAulasTableAdapter();
            this.ClasesPeriodosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClasesPeriodosTableAdapter = new UNICAH.Formularios.Reportes.DsReportesTableAdapters.ClasesPeriodosTableAdapter();
            this.rpvClasesPorAula = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ClasesAulasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClasesPeriodosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ClasesAulasBindingSource
            // 
            this.ClasesAulasBindingSource.DataMember = "ClasesAulas";
            this.ClasesAulasBindingSource.DataSource = this.DsReportes;
            // 
            // DsReportes
            // 
            this.DsReportes.DataSetName = "DsReportes";
            this.DsReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 86;
            this.label4.Text = "Periodo";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.Location = new System.Drawing.Point(13, 62);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(177, 23);
            this.txtPeriodo.TabIndex = 85;
            this.txtPeriodo.TextChanged += new System.EventHandler(this.txtPeriodo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(257, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 90;
            this.label8.Text = "Aula";
            // 
            // txtAula
            // 
            this.txtAula.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAula.Location = new System.Drawing.Point(260, 62);
            this.txtAula.Name = "txtAula";
            this.txtAula.ReadOnly = true;
            this.txtAula.Size = new System.Drawing.Size(177, 23);
            this.txtAula.TabIndex = 89;
            this.txtAula.TextChanged += new System.EventHandler(this.txtAula_TextChanged);
            // 
            // btnBuscarAula
            // 
            this.btnBuscarAula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarAula.FlatAppearance.BorderSize = 0;
            this.btnBuscarAula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAula.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAula.Image = global::UNICAH.Properties.Resources.magnify;
            this.btnBuscarAula.Location = new System.Drawing.Point(443, 58);
            this.btnBuscarAula.Name = "btnBuscarAula";
            this.btnBuscarAula.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnBuscarAula.Size = new System.Drawing.Size(40, 30);
            this.btnBuscarAula.TabIndex = 91;
            this.btnBuscarAula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarAula.UseVisualStyleBackColor = false;
            this.btnBuscarAula.Click += new System.EventHandler(this.btnBuscarAula_Click);
            // 
            // btnBuscarPeriodo
            // 
            this.btnBuscarPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarPeriodo.FlatAppearance.BorderSize = 0;
            this.btnBuscarPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPeriodo.Image = global::UNICAH.Properties.Resources.magnify;
            this.btnBuscarPeriodo.Location = new System.Drawing.Point(196, 58);
            this.btnBuscarPeriodo.Name = "btnBuscarPeriodo";
            this.btnBuscarPeriodo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnBuscarPeriodo.Size = new System.Drawing.Size(40, 30);
            this.btnBuscarPeriodo.TabIndex = 87;
            this.btnBuscarPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarPeriodo.UseVisualStyleBackColor = false;
            this.btnBuscarPeriodo.Click += new System.EventHandler(this.btnBuscarPeriodo_Click);
            // 
            // ClasesAulasTableAdapter
            // 
            this.ClasesAulasTableAdapter.ClearBeforeFill = true;
            // 
            // ClasesPeriodosBindingSource
            // 
            this.ClasesPeriodosBindingSource.DataMember = "ClasesPeriodos";
            this.ClasesPeriodosBindingSource.DataSource = this.DsReportes;
            // 
            // ClasesPeriodosTableAdapter
            // 
            this.ClasesPeriodosTableAdapter.ClearBeforeFill = true;
            // 
            // rpvClasesPorAula
            // 
            this.rpvClasesPorAula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvClasesPorAula.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource2.Name = "ClasesAulas";
            reportDataSource2.Value = this.ClasesAulasBindingSource;
            this.rpvClasesPorAula.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvClasesPorAula.LocalReport.ReportEmbeddedResource = "UNICAH.Formularios.Reportes.rptClasesAula.rdlc";
            this.rpvClasesPorAula.Location = new System.Drawing.Point(13, 116);
            this.rpvClasesPorAula.Name = "rpvClasesPorAula";
            this.rpvClasesPorAula.ServerReport.BearerToken = null;
            this.rpvClasesPorAula.Size = new System.Drawing.Size(657, 509);
            this.rpvClasesPorAula.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 19);
            this.label1.TabIndex = 92;
            this.label1.Text = "Reporte de Clases por Aula";
            // 
            // frmReporteClaseAula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 651);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarAula);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAula);
            this.Controls.Add(this.rpvClasesPorAula);
            this.Controls.Add(this.btnBuscarPeriodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPeriodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReporteClaseAula";
            this.Text = "frmReporteClaseAula";
            this.Load += new System.EventHandler(this.frmReporteClaseAula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClasesAulasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClasesPeriodosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Button btnBuscarAula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAula;
        private System.Windows.Forms.BindingSource ClasesAulasBindingSource;
        private DsReportes DsReportes;
        private DsReportesTableAdapters.ClasesAulasTableAdapter ClasesAulasTableAdapter;
        private System.Windows.Forms.BindingSource ClasesPeriodosBindingSource;
        private DsReportesTableAdapters.ClasesPeriodosTableAdapter ClasesPeriodosTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rpvClasesPorAula;
        private System.Windows.Forms.Label label1;
    }
}