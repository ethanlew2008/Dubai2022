using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Xamarin.Forms;
using System.Globalization;
using Xamarin.Forms.PlatformConfiguration;
using Android.Media;

namespace Dubai2022
{
    


    public partial class MainPage : ContentPage
    {
        string input = "";

        bool before = false;
        bool dev = false;
        bool BST = false;
        

        Int64 flighttime = 0;

        int co2 = 0;
        int hour = DateTime.Now.Hour;
        int errors = 0;
        int delpress = 0;
        int delpress2 = 0;

        
        Stopwatch flight = new Stopwatch();
        Stopwatch deldouble = new Stopwatch();
        Stopwatch sleep = new Stopwatch(); double sleephours = 0;
        TimeSpan spWorkMin;
        string workHours;

        int min = DateTime.Now.Minute;
        int hours = DateTime.Now.Hour;
        int dubaihour = 0;
        int londonhour = 0;

        int day = 0;
        int month = 0;
        int year = 0;

        public MainPage()
        {
            InitializeComponent();

            if (hour > 7 && hour < 19)
            {       
                #region ButtonColor
                Button0.BackgroundColor = Color.Orange;
                Button1.BackgroundColor = Color.Orange;
                Button2.BackgroundColor = Color.Orange;
                Button3.BackgroundColor = Color.Orange;
                Button4.BackgroundColor = Color.Orange;
                Button5.BackgroundColor = Color.Orange;
                Button6.BackgroundColor = Color.Orange;
                Button7.BackgroundColor = Color.Orange;
                Button8.BackgroundColor = Color.Orange;
                Button9.BackgroundColor = Color.Orange;

                FlyDayButton.BackgroundColor = Color.Orange;
                GBPButton.BackgroundColor = Color.Orange;
                ButtonDel.BackgroundColor = Color.Orange;
                Dotbutton.BackgroundColor = Color.Orange;
                TimeButton.BackgroundColor = Color.Orange;
                FlipButton.BackgroundColor = Color.Orange;
                SleepButton.BackgroundColor = Color.Orange;
                #endregion
                BackgroundImageSource = "Backround4app1.png";               
            }
            else
            {
                #region ButtonColor
                Button0.BackgroundColor = Color.MediumPurple;
                Button1.BackgroundColor = Color.MediumPurple;
                Button2.BackgroundColor = Color.MediumPurple;
                Button3.BackgroundColor = Color.MediumPurple;
                Button4.BackgroundColor = Color.MediumPurple;
                Button5.BackgroundColor = Color.MediumPurple;
                Button6.BackgroundColor = Color.MediumPurple;
                Button7.BackgroundColor = Color.MediumPurple;
                Button8.BackgroundColor = Color.MediumPurple;
                Button9.BackgroundColor = Color.MediumPurple;

                FlyDayButton.BackgroundColor = Color.MediumPurple;
                GBPButton.BackgroundColor = Color.MediumPurple;
                ButtonDel.BackgroundColor = Color.MediumPurple;
                Dotbutton.BackgroundColor = Color.MediumPurple;
                TimeButton.BackgroundColor = Color.MediumPurple;
                FlipButton.BackgroundColor = Color.MediumPurple;
                SleepButton.BackgroundColor = Color.MediumPurple;
                #endregion
                BackgroundImageSource = "Backround4appnight.png";
            }



             day = DateTime.Now.Day;
             month = DateTime.Now.Month;
             year = DateTime.Now.Year;

            if (day < 20 && month == 8 && year == 2022 || month < 8 && year == 2022)
            {
                before = true; FlyDayButton.Text = "Days";
                DateTime futurDate = Convert.ToDateTime("20/08/2022");
                DateTime TodayDate = DateTime.Now;
                Box.Text += Convert.ToInt32((futurDate - TodayDate).TotalDays); Box.Text += " Days";
            }
            else if(month > 8 && day > 28) {FlyDayButton.Text = "Flight"; }
            else if(year == 2022 && month == 8 && day > 19 && day < 28) {FlyDayButton.Text = "Flight"; }
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
            if (deldouble.IsRunning)
            {
                if(deldouble.ElapsedMilliseconds - 220 < 0) 
                {
                    delpress++;

                    if(delpress >= 2)
                    {
                        Box.Text = "";
                        input = "";

                        delpress = 0;
                        deldouble.Stop();
                    }
                }
                else
                {
                    string ostr = "";
                    try { ostr = input.Remove(input.Length - 1, 1); } catch (Exception) { return; }
                    input = ostr; Box.Text = input;
                    deldouble.Restart();
                }
                
            }
            else
            {
                deldouble.Start();
                string ostr = "";
                try { ostr = input.Remove(input.Length - 1, 1); } catch (Exception) { return; }
                input = ostr; Box.Text = input;
                deldouble.Start();
            }
        }

        private void FlyDayButton_Clicked(object sender, EventArgs e)
        {           
            if (Box.Text == "1622") { dev = true; FlyDayButton.Text = "Flight"; }
            if(Box.Text == "7344") { Box.Text = ""; Box.Text += errors; input = ""; return; }
            input = ""; Box.Text = "";

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
                    flighttime /= 1000; flighttime /= 60;
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
            input = ""; Box.Text = "";
            Box.Text = "Police = 999\nAmbulance = 998\n CoastGuard = 996";
        }

        private void GBPButton_Clicked(object sender, EventArgs e)
        {
            try { Convert.ToDouble(input); }
            catch (Exception) { errors++; Box.Text = "Number Too Big"; input = ""; return; }
          
            double dbu = 0;

            dbu = Convert.ToDouble(input) / 4.41;
            string cultures = dbu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-GB"));
            Box.Text =  "That's About " + cultures;
            input = "";

        }

        private void TimeButton_Clicked(object sender, EventArgs e)
        {
            Box.Text = "";
            input = "";
            int min = DateTime.Now.Minute;
            string minstring = "";

            if (month >= 3 && month <= 10) { BST = true; }

            if (BST)
            {
                if (before) { londonhour = DateTime.Now.Hour; dubaihour = londonhour + 3; }
                else { dubaihour = DateTime.Now.Hour; londonhour = dubaihour - 3; }
            }
            else
            {
                if (before) { londonhour = DateTime.Now.Hour; dubaihour = londonhour + 4; }
                else { dubaihour = DateTime.Now.Hour; londonhour = dubaihour - 4; }
            }
            
            if(londonhour >= 24) { londonhour -= 24; }
            if(dubaihour >= 24) { dubaihour -= 24; }

            if (min.ToString().Length == 1 && min >= 10) { minstring = Convert.ToString(min) + "0"; }
            if (min.ToString().Length == 1 && min < 10) { minstring = "0" + Convert.ToString(min); }

            if (londonhour < 0) { londonhour *= -1; }
            if (dubaihour < 0) { dubaihour *= -1; }

            Box.Text += "Dubai:" + dubaihour + ":"; if (minstring == "") { Box.Text += min; } else { Box.Text += minstring; }
            Box.Text += "\nLondon:" + londonhour + ":"; if (minstring == "") { Box.Text += min; } else { Box.Text += minstring; }            
        }

        private void FlipButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            Random random = new Random(); int rng = random.Next(1, 3);
            if(rng == 1) { Box.Text = "Heads"; }
            else { Box.Text = "Tails"; }
        }

        private void SleepButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            if (!sleep.IsRunning) 
            {
                Box.Text = "Goodnight";
                SleepButton.Text = "Stop";
                BackgroundImageSource = "Backround4appnight.png";
                sleep.Start();
                #region ButtonColor
                Button0.BackgroundColor = Color.MediumPurple;
                Button1.BackgroundColor = Color.MediumPurple;
                Button2.BackgroundColor = Color.MediumPurple;
                Button3.BackgroundColor = Color.MediumPurple;
                Button4.BackgroundColor = Color.MediumPurple;
                Button5.BackgroundColor = Color.MediumPurple;
                Button6.BackgroundColor = Color.MediumPurple;
                Button7.BackgroundColor = Color.MediumPurple;
                Button8.BackgroundColor = Color.MediumPurple;
                Button9.BackgroundColor = Color.MediumPurple;

                FlyDayButton.BackgroundColor = Color.MediumPurple;
                GBPButton.BackgroundColor = Color.MediumPurple;
                ButtonDel.BackgroundColor = Color.MediumPurple;
                Dotbutton.BackgroundColor = Color.MediumPurple;
                TimeButton.BackgroundColor = Color.MediumPurple;
                FlipButton.BackgroundColor = Color.MediumPurple;
                SleepButton.BackgroundColor = Color.MediumPurple;
                #endregion
            }       
            
            else
            { 
                sleep.Stop();
                Box.Text = "Good Morning\n";
                sleephours = sleep.ElapsedMilliseconds / 1000; sleephours /= 60;

                TimeSpan spWorkMin = TimeSpan.FromMinutes(sleephours);
                string workHours = spWorkMin.ToString(@"hh\:mm");
                Box.Text += "You Slept " + workHours;
                Box.Text += "\nYou took " + Convert.ToInt32(sleephours * 16) + " Breaths";
                SleepButton.Text = "Sleep";

                int hour = DateTime.Now.Hour;


                if (hour > 7 && hour < 19)
                {
                    #region ButtonColor
                    Button0.BackgroundColor = Color.Orange;
                    Button1.BackgroundColor = Color.Orange;
                    Button2.BackgroundColor = Color.Orange;
                    Button3.BackgroundColor = Color.Orange;
                    Button4.BackgroundColor = Color.Orange;
                    Button5.BackgroundColor = Color.Orange;
                    Button6.BackgroundColor = Color.Orange;
                    Button7.BackgroundColor = Color.Orange;
                    Button8.BackgroundColor = Color.Orange;
                    Button9.BackgroundColor = Color.Orange;

                    FlyDayButton.BackgroundColor = Color.Orange;
                    GBPButton.BackgroundColor = Color.Orange;
                    ButtonDel.BackgroundColor = Color.Orange;
                    Dotbutton.BackgroundColor = Color.Orange;
                    TimeButton.BackgroundColor = Color.Orange;
                    FlipButton.BackgroundColor = Color.Orange;
                    SleepButton.BackgroundColor = Color.Orange;
                    #endregion
                    BackgroundImageSource = "Backround4app1.png";
                }
                else
                {
                    #region ButtonColor
                    Button0.BackgroundColor = Color.MediumPurple;
                    Button1.BackgroundColor = Color.MediumPurple;
                    Button2.BackgroundColor = Color.MediumPurple;
                    Button3.BackgroundColor = Color.MediumPurple;
                    Button4.BackgroundColor = Color.MediumPurple;
                    Button5.BackgroundColor = Color.MediumPurple;
                    Button6.BackgroundColor = Color.MediumPurple;
                    Button7.BackgroundColor = Color.MediumPurple;
                    Button8.BackgroundColor = Color.MediumPurple;
                    Button9.BackgroundColor = Color.MediumPurple;

                    FlyDayButton.BackgroundColor = Color.MediumPurple;
                    GBPButton.BackgroundColor = Color.MediumPurple;
                    ButtonDel.BackgroundColor = Color.MediumPurple;
                    Dotbutton.BackgroundColor = Color.MediumPurple;
                    TimeButton.BackgroundColor = Color.MediumPurple;
                    FlipButton.BackgroundColor = Color.MediumPurple;
                    SleepButton.BackgroundColor = Color.MediumPurple;
                    #endregion
                    BackgroundImageSource = "Backround4appnight.png";
                }
            }
        }
    }
}
