using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomobileLibrary;
using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;

namespace AutomobileWinform
{
    public partial class frmCarDetails : Form
    {
        public ICarRepository CarRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Car CarInfo { get; set; }

        public frmCarDetails()
        {
            InitializeComponent();
        }

        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManufacturer.SelectedIndex = 0;
            txtCarId.Enabled = !InsertOrUpdate;
            if(InsertOrUpdate == true)
            {
                txtCarId.Text = CarInfo.CarId.ToString();
                txtCarName.Text = CarInfo.CarName.ToString();
                txtPrice.Text = CarInfo.Price.ToString();
                txtRelease.Text = CarInfo.Manufacturer.ToString();
                cboManufacturer.Text = CarInfo.Manufacturer.Trim();
            }    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarId = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Manufacturer = cboManufacturer.Text,
                    ReleaseYear = int.Parse(txtRelease.Text),
                };
                if(!InsertOrUpdate)
                {
                    CarRepository.InsertCar(car);
                }
                else
                {
                    CarRepository.UpdateCar(car);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, !InsertOrUpdate ? "Add new car" : "Update a car");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
