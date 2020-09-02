namespace GolfUniverse.Library
{
    /// 3. Set swing conditions
    public struct SwingCondition
    {
        /// <summary>
        /// Swing type ['Type I', 'Type II'], Type, "Type I"
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// Swing plane angle (degree), phi, 60
        /// </summary>
        public float PlaneAngle { get; private set; }
        /// <summary>
        /// Initial arm angle (degree), theta, 135
        /// </summary>
        public float InitialArmAngle { get; private set; }
        /// <summary>
        /// Impact arm angle (degree), theta_final, 0.0
        /// </summary>
        public float ImpactArmAngle { get; private set; }
        /// <summary>
        /// Initial wrist-cock angle (degree), beta, 120.0
        /// </summary>
        public float InitialWristCockAngle { get; private set; }
        /// <summary>
        /// Impact wrist-cock angle (degree), beta_final, 0.0
        /// </summary>
        public float ImpactWristCockAngle { get; private set; }
        /// <summary>
        /// Arm acceleration in horizontal direction (m/sec^2), a_x, 0.0
        /// </summary>
        public float ArmAccelerationHorizontal { get; private set; }
        /// <summary>
        /// Arm acceleration in vertical direction (m/sec^2), a_y, 0.0
        /// </summary>
        public float ArmAccelerationVertical { get; private set; }
        /// <summary>
        /// Arm torque (N-m), Q_alpha, 100.0
        /// </summary>
        public float ArmTorque { get; private set; }
        /// <summary>
        /// Raising time of arm torque (sec), tau_Q_alpha, 0.01
        /// </summary>
        public float ArmTorqueRaisingTime { get; private set; }
        /// <summary>
        /// Wrist-cock torque (N-m), Q_beta, 20.0
        /// </summary>
        public float WristCockTorque { get; private set; }
        /// <summary>
        /// At which arm angle the wrist-cock torque started (degree). The angle should be equal or smaller than the initial arm angle (theta). set_theta, 135.0
        /// </summary>
        public float InitialWristTorqueArmAngle { get; private set; }
        /// <summary>
        /// Raising time of wrist-cock torque (sec), tau_Q_beta, 0.01
        /// </summary>
        public float WristCockTorqueRaisingTime { get; private set; }
        /// <summary>
        /// Minimum of wrist-cock torque (N-m), Q_beta_min, -50.0
        /// </summary>
        public float WristCockTorqueMinimum { get; private set; }
        /// <summary>
        /// Maximum of wrist-cock torque (N-m), Q_beta_max, 0.0
        /// </summary>
        public float WristCockTorqueMaximum { get; private set; }

        public SwingCondition(
            string type, float planeAngle, float initialArmAngle, float impactArmAngle, float initialWristCockAngle, float impactWristCockAngle,
            float horizontalAcceleration, float verticalAcceleration, float armTorque, float armTorqueRaisingTime,
            float wristCockTorque, float initialWristTorqueArmAngle, float wristCockTorqueRaisingTime, float wristCockTorqueMinimum, float wristCockTorqueMaximum)
        {
            Type = type;
            PlaneAngle = planeAngle;
            InitialArmAngle = initialArmAngle;
            ImpactArmAngle = impactArmAngle;
            InitialWristCockAngle = initialWristCockAngle;
            ImpactWristCockAngle = impactWristCockAngle;
            ArmAccelerationHorizontal = horizontalAcceleration;
            ArmAccelerationVertical = verticalAcceleration;
            ArmTorque = armTorque;
            ArmTorqueRaisingTime = armTorqueRaisingTime;
            WristCockTorque = wristCockTorque;
            InitialWristTorqueArmAngle = initialWristTorqueArmAngle;
            WristCockTorqueRaisingTime = wristCockTorqueRaisingTime;
            WristCockTorqueMinimum = wristCockTorqueMinimum;
            WristCockTorqueMaximum = wristCockTorqueMaximum;
        }
    }
}
