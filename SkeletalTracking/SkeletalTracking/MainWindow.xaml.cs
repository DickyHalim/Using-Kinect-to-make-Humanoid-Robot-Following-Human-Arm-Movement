// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;
using Coding4Fun.Kinect;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;


namespace SkeletalTracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();
            init();


        }



        bool closing = false;
        const int skeletonCount = 6;
        Skeleton[] allSkeletons = new Skeleton[skeletonCount];

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kinectSensorChooser1.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kinectSensorChooser1_KinectSensorChanged);


        }



        void kinectSensorChooser1_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            KinectSensor old = (KinectSensor)e.OldValue;

            StopKinect(old);

            KinectSensor sensor = (KinectSensor)e.NewValue;

            if (sensor == null)
            {
                return;
            }




            var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.3f,
                Correction = 0.0f,
                Prediction = 0.0f,
                JitterRadius = 1.0f,
                MaxDeviationRadius = 0.5f
            };
            sensor.SkeletonStream.Enable(parameters);

            sensor.SkeletonStream.Enable();

            sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(sensor_AllFramesReady);
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

            try
            {
                sensor.Start();
            }
            catch (System.IO.IOException)
            {
                kinectSensorChooser1.AppConflictOccurred();
            }
        }

        void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (closing)
            {
                return;
            }

            //Get a skeleton
            Skeleton first = GetFirstSkeleton(e);

            if (first == null)
            {
                return;
            }

            GetCameraPoint(first, e);

            //set scaled position
            ScalePosition(Head, first.Joints[JointType.Head]);
            
            ScalePosition(LeftHand, first.Joints[JointType.HandLeft]);
            ScalePosition(RightHand, first.Joints[JointType.HandRight]);


            ProcessGesture(first.Joints[JointType.ShoulderLeft], first.Joints[JointType.ElbowLeft], 
                 first.Joints[JointType.ShoulderRight], first.Joints[JointType.ElbowRight], first.Joints[JointType.HandLeft], first.Joints[JointType.HandRight], first.Joints[JointType.Head]
                );
                

        }
        private SerialPort myport;
   
        private void init()
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = "COM3";//port arduino
            myport.Open();
        }
        
        private void ProcessGesture(Joint shoulderleft, Joint elbowleft, Joint shoulderright, Joint elbowright, Joint handleft, Joint handright, Joint head)
        {   
            double a1, b1, c1, Xsl, Xel, Ysl, Yel, S1, S2;//parameter between left shoulder and left elbow
            double a2, a4, c2, c4, Zsl, Zel, Zsr, Zer, S5, S6;
            double a3, b3, c3, Xsr, Xer, Ysr, Yer, S3, S4;//parameter between right shoulder and right elbow

            Xsl = 100 * shoulderleft.Position.X; Xel = 100*elbowleft.Position.X; //convert cm to metre
            Ysl = 100 * shoulderleft.Position.Y; Yel = 100*elbowleft.Position.Y; 
            Xsr = 100 * shoulderright.Position.X; Xer = 100 * elbowright.Position.X; 
            Ysr = 100 * shoulderright.Position.Y; Yer = 100 * elbowright.Position.Y;
            Zsl = 100 * shoulderleft.Position.Z; Zsr = 100 * shoulderright.Position.Z;
            Zel = 100 * elbowleft.Position.Z; Zer = 100 * elbowright.Position.Z;

            a1 = (Ysl - Yel);
            b1 = (Xel - Xsl);
            c1 = Math.Sqrt(Math.Pow(a1, 2) + Math.Pow(b1, 2));

            a3 = (Ysr - Yer);
            b3 = (Xer - Xsr);
            c3 = Math.Sqrt(Math.Pow(a3, 2) + Math.Pow(b3, 2));

            a2 = (Zsr - Zer);
            a4 = (Zsl - Zel);
            c2 = Math.Sqrt(Math.Pow(a2, 2) + Math.Pow(b3, 2));//right hand
            c4 = Math.Sqrt(Math.Pow(a4, 2) + Math.Pow(b1, 2));//left hand

            S1 = Math.Round((Math.Acos(Math.Abs(a1/c1)))*(180/Math.PI));//angle between left shoulder and left elbow
            S2 = Math.Round((Math.Acos(Math.Abs(b1 / c1))) * (180 / Math.PI));//sudut bahu dan siku tangan kiri untuk >90
            S3 = Math.Round((Math.Acos(Math.Abs(a3 / c3))) * (180 / Math.PI));//angle between right shoulder and right elbow
            S4 = Math.Round((Math.Acos(Math.Abs(b3 / c3))) * (180 / Math.PI));
            S5 = Math.Round((Math.Acos(Math.Abs(b3 / c2))) * (180 / Math.PI));
            S6 = Math.Round((Math.Acos(Math.Abs(b1 / c4))) * (180 / Math.PI));


            if (handright.Position.Z < head.Position.Z - 0.45 && handleft.Position.Z < head.Position.Z - 0.45)
            {
                TextInstructions.Text = "straighten hands forward";
                myport.WriteLine("4"); //send data integer to arduino
                Thread.Sleep(1000);
            }
            else if (handright.Position.Y > head.Position.Y + 0.1 && (S2 > 0 && S2 < 18))
            {
                TextInstructions.Text = "raise right hand and stretching left hand";
                myport.WriteLine("8");
                Thread.Sleep(1000);
            }
            else if (handleft.Position.Y > head.Position.Y + 0.1 && (S4 > 0 && S4 < 18))
            {
                TextInstructions.Text = "raise left hand and stretching right hand";
                myport.WriteLine("9");
                Thread.Sleep(1000);
            }
            else if (((S5 > 35 && S5 < 72) && (S6 > 35 && S6 < 72))&& (handright.Position.Z < head.Position.Z - 0.25 && handleft.Position.Z < head.Position.Z - 0.25))
            {
                TextInstructions.Text = "straighten hands forward half";
                myport.WriteLine("7");
                Thread.Sleep(1000);
            }
            else if (handright.Position.Y > head.Position.Y + 0.1 && handleft.Position.Y > head.Position.Y + 0.1)
            {
                TextInstructions.Text = "raise hands up";
                myport.WriteLine("3");
                Thread.Sleep(1000);
            }
            else if ((S5 > 0 && S5 < 30) && (S6 > 0 && S6 < 30))
            {
                if (Yel > Ysl && Yer > Ysr)//if coordinate Y of elbow > shoulder
                {
                    
                    if ((S2 > 0 && S2 < 18) && (S4 > 0 && S4 < 18))
                    {
                        TextInstructions.Text = "stretching hands";
                        myport.WriteLine("2");
                        Thread.Sleep(1000);
                    }
                    else if ((S2 > 18 && S2 < 54) && (S4 > 18 && S4 < 54))
                    {
                        TextInstructions.Text = "raise hands up half";
                        myport.WriteLine("6");
                        Thread.Sleep(1000);
                    }
                }
                else if (Ysl >= Yel && Ysr >= Yer)//if coordinate Y of shoulder > elbow
                {
                    if ((S1 > 0 && S1 < 30) && (S3 > 0 && S3 < 30))
                    {
                        TextInstructions.Text = "put hands down";
                        myport.WriteLine("1");
                        Thread.Sleep(1000);
                    }
                    else if ((S1 > 30 && S1 < 72) && (S3 > 30 && S3 < 72))
                    {
                        TextInstructions.Text = "put hands down half";
                        myport.WriteLine("5");
                        Thread.Sleep(1000);
                    }
                    if ((S1 > 72 && S1 < 90) && (S3 > 72 && S3 < 90))
                    {
                        TextInstructions.Text = "stretching hands";
                        myport.WriteLine("2");
                        Thread.Sleep(1000);
                    }
                }
                

            }
        }

        void GetCameraPoint(Skeleton first, AllFramesReadyEventArgs e)
        {

            using (DepthImageFrame depth = e.OpenDepthImageFrame())
            {
                if (depth == null ||
                    kinectSensorChooser1.Kinect == null)
                {
                    return;
                }
                

                //Map a joint location to a point on the depth map
                //head
                DepthImagePoint headDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.Head].Position);
                //left shoulder
                DepthImagePoint leftshoulderDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ShoulderLeft].Position);
                //left elbow
                DepthImagePoint leftelbowDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ElbowLeft].Position);
                //left wrist
                DepthImagePoint leftwristDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.WristLeft].Position);
                //right shoulder
                DepthImagePoint rightshoulderDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ShoulderRight].Position);
                //left elbow
                DepthImagePoint rightelbowDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.ElbowRight].Position);
                //left wrist
                DepthImagePoint rightwristDepthPoint =
                    depth.MapFromSkeletonPoint(first.Joints[JointType.WristRight].Position);

                //Map a depth point to a point on the color image
                //head
                ColorImagePoint headColorPoint =
                    depth.MapToColorImagePoint(headDepthPoint.X, headDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //left shoulder
                ColorImagePoint leftshoulderColorPoint =
                    depth.MapToColorImagePoint(leftshoulderDepthPoint.X, leftshoulderDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //left elbow
                ColorImagePoint leftelbowColorPoint =
                    depth.MapToColorImagePoint(leftelbowDepthPoint.X, leftelbowDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //left wrist
                ColorImagePoint leftwristColorPoint =
                    depth.MapToColorImagePoint(leftwristDepthPoint.X, leftwristDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right shoulder
                ColorImagePoint rightshoulderColorPoint =
                    depth.MapToColorImagePoint(rightshoulderDepthPoint.X, rightshoulderDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right elbow
                ColorImagePoint rightelbowColorPoint =
                    depth.MapToColorImagePoint(rightelbowDepthPoint.X, rightelbowDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right wrist
                ColorImagePoint rightwristColorPoint =
                    depth.MapToColorImagePoint(rightwristDepthPoint.X, rightwristDepthPoint.Y,
                    ColorImageFormat.RgbResolution640x480Fps30);

                //Set location
                CameraPosition(Head, headColorPoint); 
                CameraPosition(LeftHand, leftshoulderColorPoint);
                CameraPosition(RightHand, leftelbowColorPoint);
                
            }        
        }


        Skeleton GetFirstSkeleton(AllFramesReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
            {
                if (skeletonFrameData == null)
                {
                    return null; 
                }

                
                skeletonFrameData.CopySkeletonDataTo(allSkeletons);

                //get the first tracked skeleton
                Skeleton first = (from s in allSkeletons
                                         where s.TrackingState == SkeletonTrackingState.Tracked
                                         select s).FirstOrDefault();

                return first;



            }
        }


        private void btnangle_Click(object sender, RoutedEventArgs e)
        {
            if (kinectSensorChooser1.Kinect.ElevationAngle != (int)slider1.Value)
            {
                kinectSensorChooser1.Kinect.ElevationAngle = (int)slider1.Value;
            }

            //if (runtime.NuiCamera.ElevationAngle != (int)slider1.Value)
            //{
            //    runtime.NuiCamera.ElevationAngle = (int)slider1.Value;
            //}

        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int n = (int)slider1.Value;

            Degree.Content = n.ToString();

        }

        private void StopKinect(KinectSensor sensor)
        {
            if (sensor != null)
            {
                if (sensor.IsRunning)
                {
                    //stop sensor 
                    sensor.Stop();

                    //stop audio if not null
                    if (sensor.AudioSource != null)
                    {
                        sensor.AudioSource.Stop();
                    }


                }
            }
        }

        private void CameraPosition(FrameworkElement element, ColorImagePoint point)
        {
            //Divide by 2 for width and height so point is right in the middle 
            // instead of in top/left corner
            Canvas.SetLeft(element, point.X - element.Width / 2);
            Canvas.SetTop(element, point.Y - element.Height / 2);

        }


        private void ScalePosition(FrameworkElement element, Joint joint)
        {
            //convert the value to X/Y
            Joint scaledJoint = joint.ScaleTo(1280, 720); 
            
            //convert & scale (.3 = means 1/3 of joint distance)
            //Joint scaledJoint = joint.ScaleTo(1280, 720, .3f, .3f);

            Canvas.SetLeft(element, scaledJoint.Position.X);
            Canvas.SetTop(element, scaledJoint.Position.Y); 
            
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closing = true; 
            StopKinect(kinectSensorChooser1.Kinect); 
        }



    }
}
