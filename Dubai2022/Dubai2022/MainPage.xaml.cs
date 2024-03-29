﻿using System;
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
using Xamarin.Essentials;
using System.Net.Http;
namespace Dubai2022
{
    


    public partial class MainPage : ContentPage
    {
        string input = "";

        bool before = false;
        bool dev = false;
        bool arabic = false;
     

        Int64 flighttime = 0;

        int co2 = 0;
        int hour = DateTime.Now.Hour;
        int errors = 0;
        int delpress = 0;
        int delpress2 = 0;

        APIClient Client = new APIClient();

        Stopwatch flight = new Stopwatch();
        Stopwatch deldouble = new Stopwatch();
        Stopwatch sleep = new Stopwatch(); double sleephours = 0;
        TimeSpan spWorkMin;
        string workHours;



        public MainPage()
        {
            InitializeComponent();
            Client.GetGBP();
            TimeFuntion();

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
                BackgroundColor = Color.SandyBrown;        
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
                BackgroundColor = Color.MediumPurple;               
            }

            
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
                if (!flight.IsRunning) { flight.Start(); if (arabic == false) { Box.Text = "Flight Started"; } else { Box.Text = "بدأت الرحلة"; } }
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
                    if (arabic == false) { Box.Text += "KG of CO2"; } else { Box.Text += "KG من CO2"; }
                    input = "";
                }
            }

            

        }

        private void SOSButton_Clicked(object sender, EventArgs e)
        {
            input = ""; Box.Text = "";

            try { PhoneDialer.Open("999"); }
            catch (Exception)
            {
                if (arabic == false) { Box.Text = "Police = 999\nAmbulance = 998\n CoastGuard = 996"; }
                else
                {
                    Box.Text = "الشرطة = 999\nالإسعاف = 998\nخفر السواحل = 996";
                }
            }
        }

        private void GBPButton_Clicked(object sender, EventArgs e)
        {
            try { Convert.ToDouble(input); }
            catch (Exception) { errors++; if (arabic == false) { Box.Text = "Number Too Big"; } else { Box.Text = "الرقم كبير جدًا"; } input = ""; return; }

            double dbu = Convert.ToDouble(input);
            if (Client.varsyr == null) { dbu = Convert.ToDouble(input) / 4.63; }
            else { dbu /= Convert.ToDouble(Client.varsyr); }
            dbu = Math.Round(dbu, 2);
                    
            if (arabic == false) { Box.Text = "That's About "; } else { Box.Text = "هذا حول "; } Box.Text += dbu + " AED";
            input = "";

        }

        private void TimeButton_Clicked(object sender, EventArgs e)
        {
            TimeFuntion();
        }

        public void TimeFuntion()
        {
            Box.Text = "";
            input = "";

            if (!arabic)
            {
                if (DateTime.UtcNow.Month > 10 || DateTime.UtcNow.Month < 3) { Box.Text = "London: " + DateTime.UtcNow.ToString("HH:mm") + "\n"; } else { Box.Text = "London: " + DateTime.UtcNow.AddHours(1).ToString("HH:mm") + "\n"; }
                if (DateTime.UtcNow.Month > 10 || DateTime.UtcNow.Month < 3) { Box.Text += "\nDubai: " + DateTime.UtcNow.ToString("HH:mm"); } else { Box.Text += "\nDubai: " + DateTime.UtcNow.AddHours(4).ToString("HH:mm"); }
            }
            else
            {
                Box.Text = DateTime.UtcNow.AddHours(4).ToString("HH:mm") + "دبي:";
                if (DateTime.UtcNow.Month > 10 || DateTime.UtcNow.Month < 3) { Box.Text += DateTime.UtcNow.ToString("HH:mm") + "لندن:"; } else { Box.Text += DateTime.UtcNow.AddHours(1).ToString("HH:mm") + "لندن:"; }
            }


            //if (arabic == false) { Box.Text += "Dubai:"; } else { Box.Text += "دبي:"; }
            //Box.Text += dubaihour + ":"; if (minstring == "") { Box.Text += min; } else { Box.Text += minstring; }

            //if (arabic == false) { Box.Text += "\nLondon:"; } else { Box.Text += "\nلندن:"; }
            //Box.Text += londonhour + ":"; if (minstring == "") { Box.Text += min; } else { Box.Text += minstring; } 
        }

        private void FlipButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            arabic = !arabic;

            if(arabic == false)
            {

                #region Buttonchange
                Button1.Text = "1";
                Button2.Text = "2";
                Button3.Text = "3";
                Button4.Text = "4";
                Button5.Text = "5";
                Button6.Text = "6";
                Button7.Text = "7";
                Button8.Text = "8";
                Button9.Text = "9";
                Button0.Text = "0";

                ButtonDel.Text = "Del";
                FlyDayButton.Text = "Flight";
                TimeButton.Text = "Time";
                SOSButton.Text = "SOS";
                GBPButton.Text = "GBP";
                SleepButton.Text = "Sleep";
                FlipButton.Text = "عربي";
                #endregion
            }
            else
            {
                #region Buttonchange
                Button1.Text = "واحد";
                Button2.Text = "اثنين";
                Button3.Text = "ثلاثة";
                Button4.Text = "أربعة";
                Button5.Text = "خمسة";
                Button6.Text = "ستة";
                Button7.Text = "سبعة";
                Button8.Text = "ثمانية";
                Button9.Text = "تسع";
                Button0.Text = "ض";
                ButtonDel.Text = "ديل";
                FlyDayButton.Text = "طيران";
                TimeButton.Text = "زمن";
                SOSButton.Text = "SOS";
                GBPButton.Text = "GBP";
                SleepButton.Text = "ينام";
                FlipButton.Text = "English";
                #endregion
            }
        }

        private void SleepButton_Clicked(object sender, EventArgs e)
        {
            input = "";
            if (!sleep.IsRunning) 
            {
                if (arabic == false) { Box.Text = "Goodnight"; } else { Box.Text = "تصبح على خير"; }
                if (arabic == false) { SleepButton.Text = "Stop"; } else { SleepButton.Text = "قف"; }
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
                if (arabic == false) { Box.Text = "Good Morning\n"; } else { Box.Text = "صباح الخير\n"; }
                sleephours = sleep.ElapsedMilliseconds / 1000; sleephours /= 60;

                TimeSpan spWorkMin = TimeSpan.FromMinutes(sleephours);
                string workHours = spWorkMin.ToString(@"hh\:mm");

                if (arabic == false) { Box.Text += "You Slept "; } else { Box.Text += "أنت نمت "; } Box.Text += workHours;

                sleephours = Convert.ToInt32(sleephours * 16);
                if(arabic == false) { Box.Text += "\nYou took " + sleephours + " Breaths"; } else { Box.Text += "\nلقد أخذت" + sleephours + " بري"; }

                if (arabic == false) { SleepButton.Text = "Sleep"; } else { SleepButton.Text = "ينام"; }

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
