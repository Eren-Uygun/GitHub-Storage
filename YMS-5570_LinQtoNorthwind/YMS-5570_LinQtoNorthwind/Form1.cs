﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YMS_5570_LinQtoNorthwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          

        }
        private void BtnGetData_Click(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();
            #region Region1
            //Employee Table, Worker's Name + Title + Birthdate

            dataGridView1.DataSource = db.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Title,
                x.BirthDate
            }).ToList();
            #endregion
            #region Region2
            dataGridView1.DataSource = db.Employees.Where(x => x.EmployeeID> 1 && x.EmployeeID < 4).OrderBy(x => x.EmployeeID).ToList();
            #endregion
            #region Region3
            //// Employees Table, 
            //dataGridView1.DataSource = db.Employees.Where(SqlFunctions.DateDiff("Year",x.BirthDate-DateTime.Now) > 40).Select(x => new
            //{
            //    x.FirstName,
            //    x.LastName,
            //    x.Title,
            //    x.BirthDate,
               
            //}).ToList();
            #endregion
            #region Region4
            var result = from p in db.Products
                         where p.UnitPrice >= 20 && p.UnitPrice <= 50
                         orderby p.UnitPrice ascending
                         select new
                         {
                             UrunID = p.ProductID,
                             UrunAdi = p.ProductName,
                             Fiyat = p.UnitPrice,
                             StokAdet = p.UnitsInStock,
                             KategoriAdi = p.Category.CategoryName
                         };

            dataGridView1.DataSource = result.ToList();
            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}