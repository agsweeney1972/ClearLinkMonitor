using Sres.Net.EEIP;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using WinRT;
using System.Diagnostics;
using System.Security.Policy;

namespace WinUI_ClearCore
{

    public partial class Form1 : Form
    {

        int myCount { get; set; } = 0;
        int myInstance { get; set; } = 1;
        int myDelay { get; set; } = 250;

        uint bitOne = 0;
        uint bitTwo = 0;
        uint bitThree = 0;
        uint bitFour = 0;
        uint bitFive = 0;
        uint bitSix = 0;
        uint bitSeven = 0;
        uint bitEight = 0;


        bool SessionStarted { get; set; } = false;


        bool M0Bit = false;
        bool M1Bit = false;
        bool M2Bit = false;
        bool M3Bit = false;



        EEIPClient eeipClient = new EEIPClient();
        DispatcherTimer ThisTimer = new DispatcherTimer();

        public Form1()
        {
            InitializeComponent();

        }

        private void
            Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Checked = false;
            checkBox2.Enabled = false;
            ThisTimer.Tick += new EventHandler(ThisTimer_Tick);
            ThisTimer.Interval = TimeSpan.FromMilliseconds(myDelay);
        }

        private void ThisTimer_Tick(object? sender, EventArgs e)
        {
            /* Start DispatcherTimer Called Code */
            if (M0Bit) { myInstance = 1; }
            if (M1Bit) { myInstance = 2; }
            if (M2Bit) { myInstance = 3; }
            if (M3Bit) { myInstance = 4; }

            /* Change the Digital Input Value Radio Buttons */
            byte[] MyData = eeipClient.GetAttributeSingle(4, 100, 3);
            var InputArray = new BitArray(MyData);
            rdoDip0.Checked = InputArray[0];
            rdoDip1.Checked = InputArray[1];
            rdoDip2.Checked = InputArray[2];
            rdoDip3.Checked = InputArray[3];
            rdoDip4.Checked = InputArray[4];
            rdoDip5.Checked = InputArray[5];
            rdoDip6.Checked = InputArray[6];
            rdoDip7.Checked = InputArray[7];
            rdoDip8.Checked = InputArray[8];
            rdoDip9.Checked = InputArray[9];
            rdoDip10.Checked = InputArray[10];
            rdoDip11.Checked = InputArray[11];
            rdoDip12.Checked = InputArray[12];

            /* CCIO Data */
            byte[] CCIOIOStatus = eeipClient.GetAttributeSingle(0x68, 1, 2);
            var myCCIOIOStatus = new BitArray(CCIOIOStatus);

            /* CCIO BOARD 1 */
            rdoCCIO1_0.Checked = myCCIOIOStatus[0];
            rdoCCIO1_1.Checked = myCCIOIOStatus[1];
            rdoCCIO1_2.Checked = myCCIOIOStatus[2];
            rdoCCIO1_3.Checked = myCCIOIOStatus[3];
            rdoCCIO1_4.Checked = myCCIOIOStatus[4];
            rdoCCIO1_5.Checked = myCCIOIOStatus[5];
            rdoCCIO1_6.Checked = myCCIOIOStatus[6];
            rdoCCIO1_7.Checked = myCCIOIOStatus[7];
            /* CCIO BOARD 2 */
            rdoCCIO2_0.Checked = myCCIOIOStatus[8];
            rdoCCIO2_1.Checked = myCCIOIOStatus[9];
            rdoCCIO2_2.Checked = myCCIOIOStatus[10];
            rdoCCIO2_3.Checked = myCCIOIOStatus[11];
            rdoCCIO2_4.Checked = myCCIOIOStatus[12];
            rdoCCIO2_5.Checked = myCCIOIOStatus[13];
            rdoCCIO2_6.Checked = myCCIOIOStatus[14];
            rdoCCIO2_7.Checked = myCCIOIOStatus[15];
            /* CCIO BOARD 3 */
            rdoCCIO3_0.Checked = myCCIOIOStatus[16];
            rdoCCIO3_1.Checked = myCCIOIOStatus[17];
            rdoCCIO3_2.Checked = myCCIOIOStatus[18];
            rdoCCIO3_3.Checked = myCCIOIOStatus[19];
            rdoCCIO3_4.Checked = myCCIOIOStatus[20];
            rdoCCIO3_5.Checked = myCCIOIOStatus[21];
            rdoCCIO3_6.Checked = myCCIOIOStatus[22];
            rdoCCIO3_7.Checked = myCCIOIOStatus[23];
            /* CCIO BOARD 4 */
            rdoCCIO4_0.Checked = myCCIOIOStatus[24];
            rdoCCIO4_1.Checked = myCCIOIOStatus[25];
            rdoCCIO4_2.Checked = myCCIOIOStatus[26];
            rdoCCIO4_3.Checked = myCCIOIOStatus[27];
            rdoCCIO4_4.Checked = myCCIOIOStatus[28];
            rdoCCIO4_5.Checked = myCCIOIOStatus[29];
            rdoCCIO4_6.Checked = myCCIOIOStatus[30];
            rdoCCIO4_7.Checked = myCCIOIOStatus[31];
            /* CCIO BOARD 5 */
            rdoCCIO5_0.Checked = myCCIOIOStatus[32];
            rdoCCIO5_1.Checked = myCCIOIOStatus[33];
            rdoCCIO5_2.Checked = myCCIOIOStatus[34];
            rdoCCIO5_3.Checked = myCCIOIOStatus[35];
            rdoCCIO5_4.Checked = myCCIOIOStatus[36];
            rdoCCIO5_5.Checked = myCCIOIOStatus[37];
            rdoCCIO5_6.Checked = myCCIOIOStatus[38];
            rdoCCIO5_7.Checked = myCCIOIOStatus[39];
            /* CCIO BOARD 6 */
            rdoCCIO6_0.Checked = myCCIOIOStatus[40];
            rdoCCIO6_1.Checked = myCCIOIOStatus[41];
            rdoCCIO6_2.Checked = myCCIOIOStatus[42];
            rdoCCIO6_3.Checked = myCCIOIOStatus[43];
            rdoCCIO6_4.Checked = myCCIOIOStatus[44];
            rdoCCIO6_5.Checked = myCCIOIOStatus[45];
            rdoCCIO6_6.Checked = myCCIOIOStatus[46];
            rdoCCIO6_7.Checked = myCCIOIOStatus[47];
            /* CCIO BOARD 7 */
            rdoCCIO7_0.Checked = myCCIOIOStatus[48];
            rdoCCIO7_1.Checked = myCCIOIOStatus[49];
            rdoCCIO7_2.Checked = myCCIOIOStatus[50];
            rdoCCIO7_3.Checked = myCCIOIOStatus[51];
            rdoCCIO7_4.Checked = myCCIOIOStatus[52];
            rdoCCIO7_5.Checked = myCCIOIOStatus[53];
            rdoCCIO7_6.Checked = myCCIOIOStatus[54];
            rdoCCIO7_7.Checked = myCCIOIOStatus[55];
            /* CCIO BOARD 8 */
            rdoCCIO8_0.Checked = myCCIOIOStatus[56];
            rdoCCIO8_1.Checked = myCCIOIOStatus[57];
            rdoCCIO8_2.Checked = myCCIOIOStatus[58];
            rdoCCIO8_3.Checked = myCCIOIOStatus[59];
            rdoCCIO8_4.Checked = myCCIOIOStatus[60];
            rdoCCIO8_5.Checked = myCCIOIOStatus[61];
            rdoCCIO8_6.Checked = myCCIOIOStatus[62];
            rdoCCIO8_7.Checked = myCCIOIOStatus[63];

            if (rdoLoadVelocityMoveAck.Checked)
            {
                checkBox7.Checked = false;
            };

            if (rdoClearMotorFaultAct.Checked)
            {
                checkBox10.Checked = false;
            };

            if (rdoAddToPosACK.Checked)
            {
                byte[] intZero = BitConverter.GetBytes(0);
                eeipClient.SetAttributeSingle(0x66, myInstance, 7, intZero);

            }



            byte[] CCIOBoardCount = eeipClient.GetAttributeSingle(0x68, 1, 4);

            string boardCount = CCIOBoardCount[0].ToString();
            lblCCIOBoardCount.Text = boardCount;

            /*
            if (string.CompareOrdinal(boardCount, "1") == 0)
            {
                label3.ForeColor = Color.Green;
                label3.Font = new Font(label3.Font, FontStyle.Underline| FontStyle.Bold |FontStyle.Italic);
                
            }
            */


            byte[] CCIOEnabled = eeipClient.GetAttributeSingle(0x68, 1, 6);
            var myCCIOEnabled = new BitArray(CCIOEnabled);
            rdoCCIOEnabled.Checked = myCCIOEnabled[0];
            if (rdoCCIOEnabled.Checked)
            {
                grpCCIOIOStatus.Enabled = true;
            }
            else
            {
                grpCCIOIOStatus.Enabled = false;
            }


            /* Change the StatusReg Radio Buttons */
            byte[] StatusReg = eeipClient.GetAttributeSingle(0x65, myInstance, 7);
            var StatusBits = new BitArray(StatusReg);
            rdoAtTargetPos.Checked = StatusBits[0];
            rdoStepsActive.Checked = StatusBits[1];
            rdoAtVelocity.Checked = StatusBits[2];
            rdoMoveDirection.Checked = StatusBits[3];
            rdoInPosLimit.Checked = StatusBits[4];
            rdoInNegLimit.Checked = StatusBits[5];
            rdoInEstop.Checked = StatusBits[6];
            rdoInHomeSensor.Checked = StatusBits[7];
            rdoIsHoming.Checked = StatusBits[8];
            rdoMotorInFault.Checked = StatusBits[9];
            rdoMotorEnabled.Checked = StatusBits[10];
            rdoOutsideSoftLimits.Checked = StatusBits[11];
            rdoPosMove.Checked = StatusBits[12];
            rdoHasHomed.Checked = StatusBits[13];
            rdoHLFBOn.Checked = StatusBits[14];
            rdoHasTorqueMesurement.Checked = StatusBits[15];
            rdoReadyToHome.Checked = StatusBits[16];
            rdoShutdownsPresent.Checked = StatusBits[17];
            rdoAddToPosACK.Checked = StatusBits[18];
            rdoLoadPosMoveAck.Checked = StatusBits[19];
            rdoLoadVelocityMoveAck.Checked = StatusBits[20];
            rdoClearMotorFaultAct.Checked = StatusBits[21];

            if (rdoStepsActive.Checked) { button8.Enabled = false; };
            if (!rdoStepsActive.Checked) { button8.Enabled = true; };


            /* Change the StatusReg Radio Buttons */
            byte[] AlertReg = eeipClient.GetAttributeSingle(0x65, myInstance, 8);
            var Alertbits = new BitArray(AlertReg);
            rdoCommandWhileShutdown.Checked = Alertbits[0];
            rdoPosLimit.Checked = Alertbits[1];
            rdoNegLimit.Checked = Alertbits[2];
            rdoSensorEstop.Checked = Alertbits[3];
            rdoSWEstop.Checked = Alertbits[4];
            rdoMotorDisabled.Checked = Alertbits[5];
            rdoSoftLimitsExceeded.Checked = Alertbits[6];
            rdoFollowerAxisFault.Checked = Alertbits[7];
            rdoCommandWhileFollowing.Checked = Alertbits[8];
            rdoMotionCanceledHomingNotReady.Checked = Alertbits[9];
            rdoMotorFaulted.Checked = Alertbits[10];
            rdoFollowingOverspeed.Checked = Alertbits[11];


            /* Feedback Data */
            byte[] CommandedPosition = eeipClient.GetAttributeSingle(0x65, myInstance, 1);
            int myCommandedPosition = BitConverter.ToInt32(CommandedPosition, 0);
            lblCommandedPosition.Text = myCommandedPosition.ToString();

            byte[] CommandedVelocity = eeipClient.GetAttributeSingle(0x65, myInstance, 2);
            int myCommandedVelocity = BitConverter.ToInt32(CommandedVelocity, 0);
            lblCommandedVelocity.Text = myCommandedVelocity.ToString();

            byte[] TargetPosition = eeipClient.GetAttributeSingle(0x65, myInstance, 3);
            int myTargetPosition = BitConverter.ToInt32(TargetPosition, 0);
            lblTargetPosition.Text = myTargetPosition.ToString();

            byte[] TargetVelelocity = eeipClient.GetAttributeSingle(0x65, myInstance, 4);
            int myTargetVelocity = BitConverter.ToInt32(TargetVelelocity, 0);
            lblTargetVelocity.Text = myTargetVelocity.ToString();

            byte[] CapturedPosition = eeipClient.GetAttributeSingle(0x65, myInstance, 5);
            int myCapturedPosition = BitConverter.ToInt32(CapturedPosition, 0);
            lblCapturedPosition.Text = myCapturedPosition.ToString();

            byte[] MeasuredTorque = eeipClient.GetAttributeSingle(0x65, myInstance, 6);
            float myMeasuredTorque = BitConverter.ToSingle(MeasuredTorque, 0);
            lblMeasuredTorque.Text = myMeasuredTorque.ToString("0.####");



            /* MC MOTOR */

            byte[] MCMeasuredTorque = eeipClient.GetAttributeSingle(0x67, myInstance, 6);
            double myMCMeasuredTorque = BitConverter.ToSingle(MeasuredTorque, 0);
            HLFB_Duty.Text = myMCMeasuredTorque.ToString("0.####");


            byte[] MCOutputReg = eeipClient.GetAttributeSingle(0x67, myInstance, 1);
            var myMCOutputReg = new BitArray(MCOutputReg);

            radioButton13.Checked = myMCOutputReg[0];
            radioButton14.Checked = myMCOutputReg[1];
            radioButton15.Checked = myMCOutputReg[2];
            radioButton16.Checked = myMCOutputReg[3];


            byte[] MCStatusReg = eeipClient.GetAttributeSingle(0x67, myInstance, 2);
            var myMCStatusReg = new BitArray(MCStatusReg);

            radioButton8.Checked = myMCStatusReg[0];
            radioButton9.Checked = myMCStatusReg[1];
            radioButton10.Checked = myMCStatusReg[2];
            radioButton11.Checked = myMCStatusReg[3];
            radioButton12.Checked = myMCStatusReg[4];

            byte[] MCPWMA = eeipClient.GetAttributeSingle(0x67, myInstance, 8);
            int myMCPWMA = BitConverter.ToInt16(MCPWMA, 0);
            lblPWMA.Text = myMCPWMA.ToString();

            byte[] MCPWMB = eeipClient.GetAttributeSingle(0x67, myInstance, 9);
            int myMCPWMB = BitConverter.ToInt16(MCPWMB, 0);
            lblPWMB.Text = myMCPWMB.ToString();

            byte[] MCTriggerPulses = eeipClient.GetAttributeSingle(0x67, myInstance, 10);
            lblTriggerTime.Text = MCTriggerPulses[0].ToString();




            /* Step and Direction Motor Configuration Objects */

            /* Config Register DWORD Valid bits 0-5 */
            byte[] thisConfigReg = eeipClient.GetAttributeSingle(0x64, myInstance, 1);


            var myConfigReg = new BitArray(thisConfigReg);
            /*
             * Bit 0 Homing Enable
             * Bit 1 Home Sensor Active Level
             * Bit 2 Enable Inversion
             * Bit 3 HLFB Inversion
             * Bit 4 Position Capture Sensor Active Level
             * Bit 5 Soft Limit Enable
            */

            radioButton2.Checked = myConfigReg[0];
            radioButton3.Checked = myConfigReg[1];
            radioButton4.Checked = myConfigReg[2];
            radioButton5.Checked = myConfigReg[3];
            radioButton6.Checked = myConfigReg[4];
            radioButton7.Checked = myConfigReg[5];


            /* Soft Limit Position1 {DINT}*/
            byte[] SoftLimitPos1 = eeipClient.GetAttributeSingle(0x64, myInstance, 2);
            int mySoftLimitPos1 = BitConverter.ToInt32(SoftLimitPos1, 0);
            lblSoftLimit1.Text = mySoftLimitPos1.ToString();

            /* Soft Limit Position2 {DINT}*/
            byte[] SoftLimitPos2 = eeipClient.GetAttributeSingle(0x64, myInstance, 3);
            int mySoftLimitPos2 = BitConverter.ToInt32(SoftLimitPos2, 0);
            lblSoftLimit2.Text = mySoftLimitPos2.ToString();

            /* Position Limit Connector {SINT} */
            byte[] POSSensor = eeipClient.GetAttributeSingle(0x64, myInstance, 4);
            string POSLimSensor = POSSensor[0].ToString();

            if (string.CompareOrdinal(POSLimSensor, "255") == 0)
            {
                //they're equal
                lblPosLimIn.Text = "NA";
            }
            else
            {
                lblPosLimIn.Text = POSSensor[0].ToString();
            }

            /* Negative Limit Connector {SINT} */
            byte[] NEGSensor = eeipClient.GetAttributeSingle(0x64, myInstance, 5);
            string NEGLimSensor = NEGSensor[0].ToString();
            if (string.CompareOrdinal(NEGLimSensor, "255") == 0)
            {
                //they're equal
                lblNegLimitIn.Text = "NA";
            }
            else
            {
                lblNegLimitIn.Text = NEGSensor[0].ToString();
            }

            /* Home Sensor Connector {SINT} */
            byte[] HomeSensor = eeipClient.GetAttributeSingle(0x64, myInstance, 6);
            string Home_Sensor = HomeSensor[0].ToString();
            if (string.CompareOrdinal(Home_Sensor, "255") == 0)
            {
                //they're equal
                lblHomeSensorIn.Text = "NA";
            }
            else
            {
                lblHomeSensorIn.Text = HomeSensor[0].ToString();
            }

            /* Brake Output {SINT}*/
            byte[] BrakeOutput = eeipClient.GetAttributeSingle(0x64, myInstance, 7);
            string myBrakeOutput = BrakeOutput[0].ToString();


            if (string.CompareOrdinal(myBrakeOutput, "255") == 0)

            {
                //they're equal
                lblBrakeOutput.Text = "NA";
            }
            else
            {
                lblBrakeOutput.Text = BrakeOutput[0].ToString();
            }


            /* Position Capture Sensor Connector {SINT}*/
            byte[] PositionCaptureSensor = eeipClient.GetAttributeSingle(0x64, myInstance, 8);
            string myPositionCaptureSensor = PositionCaptureSensor[0].ToString();

            if (string.CompareOrdinal(myPositionCaptureSensor, "255") == 0)
            {
                //they're equal
                labelPosCapSensor.Text = "NA";
            }
            else
            {
                labelPosCapSensor.Text = PositionCaptureSensor[0].ToString();
            }

            /* Max Deceleration Rate {DINT}*/
            byte[] MaxDecelRate = eeipClient.GetAttributeSingle(0x64, myInstance, 9);
            int myMaxDecelRate = BitConverter.ToInt32(MaxDecelRate, 0);
            lblMaxDecelRate.Text = myMaxDecelRate.ToString();

            /* Stop Sensor Connector {SINT} */

            byte[] EstopSensor = eeipClient.GetAttributeSingle(0x64, myInstance, 10);
            string StopSensor = EstopSensor[0].ToString();

            if (string.CompareOrdinal(StopSensor, "255") == 0)
            {
                //they're equal
                lblStopSensorIn.Text = "NA";
            }
            else
            {
                lblStopSensorIn.Text = EstopSensor[0].ToString();
            }

            /* Follow Encoder Axis {SINT}*/
            byte[] FollowEncoderAxis = eeipClient.GetAttributeSingle(0x64, myInstance, 11);
            string myFollowEncoderAxis = FollowEncoderAxis[0].ToString();

            if (string.CompareOrdinal(myFollowEncoderAxis, "255") == 0)
            {
                //they're equal
                lblFollowEncoderAxis.Text = "NA";
            }
            else
            {
                lblFollowEncoderAxis.Text = FollowEncoderAxis[0].ToString();
            }

            /* Follow Divisor {DINT}*/
            byte[] FollowDivisor = eeipClient.GetAttributeSingle(0x64, myInstance, 12);
            int myFollowDivisor = BitConverter.ToInt32(FollowDivisor, 0);
            lblFollowDivisor.Text = myFollowDivisor.ToString();

            /* Follow Encoder Axis {DINT}*/
            byte[] FollowMultiplier = eeipClient.GetAttributeSingle(0x64, myInstance, 13);
            int myFollowMultiplier = BitConverter.ToInt32(FollowMultiplier, 0);
            lblFollowMultiplier.Text = myFollowMultiplier.ToString();

            /* Format Supply Voltage Display */
            byte[] SupplyVoltage = eeipClient.GetAttributeSingle(0x69, 1, 5);
            float result = BitConverter.ToSingle(SupplyVoltage, 0);
            decimal decimalValue = Math.Round((decimal)result, 4);
            lblVoltage.Text = decimalValue.ToString();

            myCount++; stslblHitCount.Text = myCount.ToString();

            /* End DispatcherTimer Called Code */


        }

        private void btnOpen_Click(object sender, EventArgs e)
        {


            try
            {

                SessionStarted = true;
                eeipClient.IPAddress = txtIPAddy.Text;
                eeipClient.RegisterSession();

                /* MAC Address Display */
                byte[] MacAddress = eeipClient.GetAttributeSingle(0xF6, 1, 3);

                string MacDisplay = BitConverter.ToString(MacAddress);
                label41.Text = MacDisplay;

                byte[] IdentityItems = eeipClient.GetAttributeSingle(0x01, 1, 6);
                int mySerialNumber = BitConverter.ToInt32(IdentityItems);


                byte[] MotorMode = eeipClient.GetAttributeSingle(0x69, 1, 2);



                bool Mode = BitConverter.ToBoolean(MotorMode, 0);
                if (Mode)
                {
                    this.Text = ("ClearLink Monitor (M-Connector Mode)");
                    grpAlertReg.Visible = false;
                    grpStatusReg.Visible = false;
                    grpConfigData.Visible = false;
                    grpFeedback.Visible = false;
                    grpMConnector.Visible = true;
                    motorControls.Visible = false;
                }
                else
                {
                    this.Text = ("ClearLink Monitor (Step and Direction Mode) | Device Serial Number: " + mySerialNumber);
                    grpAlertReg.Visible = true;
                    grpStatusReg.Visible = true;
                    grpConfigData.Visible = true;
                    grpFeedback.Visible = true;
                    grpMConnector.Visible = false;
                    motorControls.Visible = true;





                }

            }
            catch (Exception)
            {
                eeipClient.UnRegisterSession();

                throw;
            }


            checkBox1.Checked = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            rdoShowM0.Checked = true;
            myInstance = 1;
            UpdateOutputRegs();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {


                ThisTimer.Start();

            }

            else
            {
                ThisTimer.Stop();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (SessionStarted)
            {
                eeipClient.UnRegisterSession();
            }

            else
            {

            }

            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                ThisTimer.Stop();
                ThisTimer.Interval = TimeSpan.FromMilliseconds(50);
                ThisTimer.Start();
            }
            else
            {

                ThisTimer.Stop();
                ThisTimer.Interval = TimeSpan.FromMilliseconds(myDelay);
                ThisTimer.Start();


            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (SessionStarted)
            {
                eeipClient.UnRegisterSession();
            }

            else
            {

            }


        }

        private void UpdateLabels(object sender, EventArgs e)
        {
            UpdateMyLabels();


        }
        private void UpdateMyLabels()
        {
            if (rdoShowM0.Checked) { M0Bit = true; }
            else { M0Bit = false; }

            if (rdoShowM1.Checked) { M1Bit = true; }
            else { M1Bit = false; }

            if (rdoShowM2.Checked) { M2Bit = true; }
            else { M2Bit = false; }

            if (rdoShowM3.Checked) { M3Bit = true; }
            else { M3Bit = false; }


            if (M0Bit)
            {
                grpAlertReg.Text = "Motor 0 Alert Reg";
                grpStatusReg.Text = "Motor 0 Status Reg";
                grpFeedback.Text = "Motor 0 Motion Data";
                grpConfigData.Text = "Motor 0 Config Data";
                myInstance = 1; 
                UpdateOutputRegs();


            }

            if (M1Bit)
            {
                grpAlertReg.Text = "Motor 1 Alert Reg";
                grpStatusReg.Text = "Motor 1 Status Reg";
                grpFeedback.Text = "Motor 1 Motion Data";
                grpConfigData.Text = "Motor 1 Config Data";
                myInstance = 2;
                UpdateOutputRegs();

            }

            if (M2Bit)
            {
                grpAlertReg.Text = "Motor 2 Alert Reg";
                grpStatusReg.Text = "Motor 2 Status Reg";
                grpFeedback.Text = "Motor 2 Motion Data";
                grpConfigData.Text = "Motor 2 Config Data";
                myInstance = 3;
                UpdateOutputRegs();

            }

            if (M3Bit)
            {
                grpAlertReg.Text = "Motor 3 Alert Reg";
                grpStatusReg.Text = "Motor 3 Status Reg";
                grpFeedback.Text = "Motor 3 Motion Data";
                grpConfigData.Text = "Motor 3 Config Data";
                myInstance = 4;
                UpdateOutputRegs();

            }




        }



        private void grpCCIOIOStatus_Enter(object sender, EventArgs e)
        {

        }

        private void grpMConnector_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            try
            {



                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {

            Process.Start("explorer", "https://teknic.com/files/downloads/clearlink_ethernet-ip_object_reference.pdf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Discover discover = new Discover();
            discover.ShowDialog();
        }



        private void button2_Click(object sender, EventArgs e)

        {

            int myVelocity = Convert.ToInt32(textBox1.Text);


            byte[] intBytes = BitConverter.GetBytes(myVelocity);
            //Array.Reverse(intBytes);
            byte[] result = intBytes;


            eeipClient.SetAttributeSingle(0x66, myInstance, 2, result);
            checkBox7.Checked = true;
        }

        private void updateDWORD()
        {

            uint myBoxes = bitOne | bitTwo | bitThree | bitFour | bitFive | bitSix | bitSeven | bitEight;
            byte[] bytes = BitConverter.GetBytes(myBoxes);
            eeipClient.SetAttributeSingle(0x66, myInstance, 6, bytes);

        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked)
            {
                bitOne = 0b_0000_0001;
            }
            else if (!checkBox3.Checked)
            {
                bitOne = 0b_0000_0000;
            }
            updateDWORD();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox4.Checked)
            {
                bitTwo = 0b_0000_0010;
            }
            else if (!checkBox4.Checked)
            {
                bitTwo = 0b_0000_0000;
            }
            updateDWORD();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                bitThree = 0b_0000_0100;
            }
            else if (!checkBox5.Checked)
            {
                bitThree = 0b_0000_0000;
            }
            updateDWORD();

        }


        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                bitFour = 0b_0000_1000;
            }
            else if (!checkBox6.Checked)
            {
                bitFour = 0b_0000_0000;
            }
            updateDWORD();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                bitFive = 0b_0001_0000;
            }
            else if (!checkBox7.Checked)
            {
                bitFive = 0b_0000_0000;
            }
            updateDWORD();

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                bitSix = 0b_0010_0000;
            }
            else if (!checkBox8.Checked)
            {
                bitSix = 0b_0000_0000;
            }
            updateDWORD();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                bitSeven = 0b_0100_0000;
            }
            else if (!checkBox9.Checked)
            {
                bitSeven = 0b_0000_0000;
            }
            updateDWORD();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                bitEight = 0b_1000_0000;
            }
            else if (!checkBox10.Checked)
            {
                bitEight = 0b_0000_0000;
            }
            updateDWORD();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int myAccel = Convert.ToInt32(txtAccel.Text);


            byte[] intBytes = BitConverter.GetBytes(myAccel);
            //Array.Reverse(intBytes);
            byte[] accelResult = intBytes;


            eeipClient.SetAttributeSingle(0x66, myInstance, 4, accelResult);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int myVelocity = 0;


            byte[] intBytes = BitConverter.GetBytes(myVelocity);
            //Array.Reverse(intBytes);
            byte[] result = intBytes;

            eeipClient.SetAttributeSingle(0x66, myInstance, 2, result);
            checkBox7.Checked = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int myVelocity = Convert.ToInt32(textBox1.Text);

            int myReVelocity = myVelocity * -1;
            byte[] intBytes = BitConverter.GetBytes(myReVelocity);

            byte[] result = intBytes;


            eeipClient.SetAttributeSingle(0x66, myInstance, 2, result);
            checkBox7.Checked = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int myVelocity = Convert.ToInt32(textBox1.Text);


            byte[] intBytes = BitConverter.GetBytes(myVelocity);
            //Array.Reverse(intBytes);
            byte[] result = intBytes;


            eeipClient.SetAttributeSingle(0x66, myInstance, 2, result);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            byte[] CurrentAccel = eeipClient.GetAttributeSingle(0x66, myInstance, 4);
            int myCurrentAccel = BitConverter.ToInt32(CurrentAccel, 0);
            txtAccel.Text = myCurrentAccel.ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] CommandedPosition = eeipClient.GetAttributeSingle(0x65, myInstance, 1);
            int myCommandedPosition = BitConverter.ToInt32(CommandedPosition, 0);
            int myCurrentPosition = myCommandedPosition * -1;
            byte[] intBytes = BitConverter.GetBytes(myCurrentPosition);
            //Array.Reverse(intBytes);
            byte[] result = intBytes;
            eeipClient.SetAttributeSingle(0x66, myInstance, 7, result);



        }

        private void UpdateOutputRegs()
        {
            /* Step and Direction Motor Output Register Objects */

            /* Output Register DWORD Valid bits 0-7 */
            byte[] thisControlReg = eeipClient.GetAttributeSingle(0x66, myInstance, 6);


            var myControlReg = new BitArray(thisControlReg);
            /*
             * Bit 0 Motor Enable
             * Bit 1 Absolute Flag
             * Bit 2 Homing Move Flag
             * Bit 3 Load Position Move Flag
             * Bit 4 Load Velocity Move Flag
             * Bit 5 SW E-Stop
             * Bit 6 Clear Alerts
             * Bit 7 Clear Motor Fault
            */

            checkBox3.Checked = myControlReg[0];
            checkBox4.Checked = myControlReg[1];
            checkBox5.Checked = myControlReg[2];
            checkBox6.Checked = myControlReg[3];
            checkBox7.Checked = myControlReg[4];
            checkBox8.Checked = myControlReg[5];
            checkBox9.Checked = myControlReg[6];
            checkBox10.Checked = myControlReg[7];

            byte[] CurrentAccel = eeipClient.GetAttributeSingle(0x66, myInstance, 4);
            int myCurrentAccel = BitConverter.ToInt32(CurrentAccel, 0);
            txtAccel.Text = myCurrentAccel.ToString();


            byte[] CurrentVelocity = eeipClient.GetAttributeSingle(0x66, myInstance, 2);
            int myCurrentVeloc = BitConverter.ToInt32(CurrentVelocity, 0);
            textBox1.Text = myCurrentVeloc.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateOutputRegs();
        }
    }
}