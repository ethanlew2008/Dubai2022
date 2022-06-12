using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Xamarin.Forms;

namespace Dubai2022
{



    public partial class MainPage : ContentPage
    {


        string input = "";

        bool before = false;
        bool after = false;
        bool dev = false;

        Int64 flighttime = 0;
        int co2 = 0;

        Stopwatch flight = new Stopwatch();
        TimeSpan spWorkMin;
        string workHours;


        public MainPage()
        {
            InitializeComponent();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (day < 20 && month == 8 && year == 2022 || month < 8 && year == 2022)
            {
                before = true;
                FlyDayButton.Text = "Days";

                DateTime futurDate = Convert.ToDateTime("20/08/2022");
                DateTime TodayDate = DateTime.Now;
                Box.Text += Convert.ToInt32((futurDate - TodayDate).TotalDays); Box.Text += " Days";
            }
            else { after = true; FlyDayButton.Text = "Flight"; }

            BackgroundColor = Color.White;
            Box.TextColor = Color.Black;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            input += "1";
            Box.Text = input;
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            input += "2";
            Box.Text = input;
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            input += "3";
            Box.Text = input;
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            input += "4";
            Box.Text = input;
        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            input += "5";
            Box.Text = input;
        }

        private void Button6_Clicked(object sender, EventArgs e)
        {
            input += "6";
            Box.Text = input;
        }

        private void Button7_Clicked(object sender, EventArgs e)
        {
            input += "7";
            Box.Text = input;
        }

        private void Button8_Clicked(object sender, EventArgs e)
        {
            input += "8";
            Box.Text = input;
        }

        private void Button9_Clicked(object sender, EventArgs e)
        {
            input += "9";
            Box.Text = input;
        }

        private void Dotbutton_Clicked(object sender, EventArgs e)
        {
            input += ".";
            Box.Text = input;
        }

        private void Button0_Clicked(object sender, EventArgs e)
        {
            input += "0";
            Box.Text = input;
        }

        private void ButtonDel_Clicked(object sender, EventArgs e)
        {
            string ostr = "";
            try { ostr = input.Remove(input.Length - 1, 1); } catch (Exception) { return; }
            input = ostr; Box.Text = input;
        }

        private void FlyDayButton_Clicked(object sender, EventArgs e)
        {
            input = "";

            if (Box.Text == "1622") { dev = true; FlyDayButton.Text = "Flight"; }


            if (before && dev == false)
            {
                DateTime futurDate = Convert.ToDateTime("20/08/2022");
                DateTime TodayDate = DateTime.Now;
                Box.Text += Convert.ToInt32((futurDate - TodayDate).TotalDays); Box.Text += " Days";
            }
            else
            {
                if (!flight.IsRunning) { flight.Start(); Box.Text = "Flight Started"; }
                else
                {
                    flighttime = 25800000 - flight.ElapsedMilliseconds;
                    flighttime /= 1000;
                    flighttime /= 60;
                    co2 = 21 * Convert.ToInt32(flight.ElapsedMilliseconds / 1000) / 60;

                    spWorkMin = TimeSpan.FromMinutes(flighttime);
                    workHours = spWorkMin.ToString(@"hh\:mm");
                    input = workHours;
                    Box.Text = input;
                    Box.Text += "\n" + co2;
                    Box.Text += "KG of CO2";
                    input = "";
                }
            }



        }

        private void SOSButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            Box.Text = "Police = 999\nAmbulance = 998\n CoastGuard = 996";
        }

        private void GBPButton_Clicked(object sender, EventArgs e)
        {
            double dbu = 0;
            string dbu2 = "";
            string inputclone = input;
            double rounding = 0;
            if(input == "452") { input = "451"; }
            try { dbu = Convert.ToDouble(input) / 4.52; } catch (Exception) { return; }
            Box.Text = "";
            input = "";
            try
            {
                dbu2 = Convert.ToString(dbu);
            }           
            catch (Exception) { Box.Text = "Number Too Big"; input = ""; }
            Box.Text = "That's About £";
            if(Convert.ToInt32(inputclone) < 45) { Box.Text += dbu2.Remove(4); }
            if(Convert.ToInt32(inputclone) > 46 && Convert.ToInt32(inputclone) < 452) { Box.Text += dbu2.Remove(5); }
            else if(Convert.ToInt32(inputclone) > 452){ rounding = Convert.ToDouble(dbu2); Box.Text += Math.Round(rounding); }         
        }


    }
}
