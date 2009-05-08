/********************************************************************************
* File:Listcs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Web;

using Microsoft.Office.Interop.Excel;

namespace FT.Commons.Com.Excels
{
    public class ListExcel : SimpleExcel
    {
        private System.Data.DataTable dt;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListExcel"/> class.
        /// </summary>
        /// <param name="begin">The begin.</param>
        /// <param name="end">The end.</param>
        /// <param name="filename">The filename.</param>
        /// deadshot123 modify at 2007-4-10 13:55
        public ListExcel(string filename, System.Data.DataTable dt)
            : base(filename)
        {
            this.Title = "Ĭ�ϳ��򵼳�����";
            this.HeaderHeight = 40;
            this.ColLength = dt.Columns.Count;
            this.dt = dt;
            this.Bottom = "Create at {0} by FtSystem.";

        }

        /// <summary>
        /// Draws the data row.
        /// </summary>
        /// <param name="rowindex">The rowindex.</param>
        /// <param name="dr">The dr.</param>
        /// deadshot123 modify at 2007-4-10 13:55
        private void DrawDataRow(int rowindex, DataRow dr)
        {
            //System.Diagnostics.Debug.WriteLine("rowindex:" + rowindex.ToString());
            //if (rowindex == 1000)
            //{
            //    System.Diagnostics.Debug.WriteLine("10000");
            //}
            for (int i = 1; i <= this.ColLength; i++)
            {
                Range rang = this.GetRange(rowindex, i);
                string temp = dr[i - 1].ToString();
                if (temp.StartsWith("=") || temp.StartsWith("0"))
                {
                    temp = "'" + temp;
                }
                else
                {
                    temp = "'" + temp;
                }

                this.SetRangeText(rang, temp);
            }
        }

        /// <summary>
        /// ��Excel������
        /// </summary>
        /// deadshot123 modify at 2007-4-10 13:55
        protected override void DrawContent()
        {
            System.Data.DataTable dt = this.dt;
            if (dt != null)
            {
                int rowcount = dt.Rows.Count;
                int colcount = dt.Columns.Count;
                // ������������
                object[,] objData = new object[rowcount, colcount];
                // ��ȡ�б���datagrid��
                //foreach(DataGridColumnStyle cs in ts.GridColumnStyles)
                //{
                //     objData[RowIndex,colIndex++] = cs.HeaderText;    
                // }            
                // ��ȡ����
                for (int row = 0; row < rowcount; row++)
                {
                    for (int col = 0; col < colcount; col++)
                    {
                        if (dt.Columns[col].Caption.IndexOf("��������") != -1 || dt.Columns[col].Caption.IndexOf("����") != -1)
                        {
                            try
                            {
                                objData[row, col] = "'" + Convert.ToDateTime(dt.Rows[row][col]).ToString("yyyy-MM-dd");
                            }
                            catch
                            {
                            }

                        }
                        else
                        {

                            objData[row, col] = dt.Rows[row][col] == null ? string.Empty : "'" + dt.Rows[row][col].ToString();
                        }
                        //objData[row, col] = dt[row, col];
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                this.CurrentRowIndex++;
                // д��Excel
                Range range = this.GetRange(this.CurrentRowIndex, 1, this.CurrentRowIndex + rowcount, this.ColLength);
                range.Value2 = objData;
                this.CurrentRowIndex += rowcount - 1;
                /*�ٶ���*/
                //foreach (DataRow dr in dt.Rows)
                //{
                //    this.CurrentRowIndex++;
                //    this.DrawDataRow(this.CurrentRowIndex, dr);
                //}
                /*�ٶ���*/
            }
            //base.DrawContent();
        }
        /// <summary>
        /// ��excel�ĵײ�
        /// </summary>
        /// deadshot123 modify at 2007-4-10 13:55
        protected override void DrawFooter()
        {
            //��������excel��ĸ�ʽ
            Range body = this.GetRange(3, 1, this.CurrentRowIndex, this.ColLength);
            this.SetFont(body, BodyFont);
            this.SetRangAlign(body, ExcelAlign.Center);
            this.SetRangBorderDefault(body);
            this.CurrentRowIndex++;
            base.DrawFooter();
        }

        /// <summary>
        /// ��Excel��ͷ��
        /// </summary>
        /// deadshot123 modify at 2007-4-10 13:55
        protected override void DrawHeader()
        {
            base.DrawHeader();
            //Range rang = this.GetRange(3, 1, 3, 5);
            //this.MergeCells(rang);
            //this.SetRangBorderDefault(rang);
            //this.SetFont(rang, SimpleSecondTitle);
            //this.SetRangAlign(rang, ExcelAlign.Left);

            for (int i = 1; i <= this.ColLength; i++)
            {
                Range rangTemp = this.GetRange(2, i);
                this.SetRangeText(rangTemp, this.dt.Columns[i - 1].ColumnName);

                if (this.HeaderWidth != null)
                {
                    this.SetColumnWidth(i, this.HeaderWidth[i-1]);
                }
                else
                {
                    this.SetColumnWidth(i, 12);
                }

            }

            //Ĭ��ͷ��ʽ
            Range rangHeader = this.GetRange(2, 1, 2, this.ColLength);
            this.SetFont(rangHeader, ThirdTitle);
            this.SetRangBorderDefault(rangHeader);
            this.SetRangAlign(rangHeader, ExcelAlign.Center);
            this.SetRangBackColor(rangHeader, 40);
            this.CurrentRowIndex = 2;


        }
    }
}