using UnityEngine;
using System.Collections;
using GolfUniverse.Library;
using System;

public class Launcher : MonoBehaviour
{
    private const float STANDARD_DIAMETER = 0.04267F; // (meters)
    private const float STANDARD_WEIGHT = 0.04593F; // (Kg)
    private const int STANDARD_DIMPEL_AMOUNT = 336;
    private const float STANDARD_DIMPEL_SIZE = 0.0035F; // (meters)
    private const float STANDARD_DIMPEL_DEPTH = 0.00025F; // (meters)
    private const float MIN_RESTITUTION = 0.64F;
    private const float MAX_RESTITUTION = 0.75F;

	public Rigidbody Ball;
	public Transform Target;
    public float Diameter { get; private set; }
    public float Weight { get; private set; }
    public int Dimpels { get; private set; }
    public float DimpelSize { get; private set; }
    public float DimpelDepth { get; private set; }
    private float DimpelDiameterRatio => DimpelSize / Diameter;
    private float DimpelDepthRatio => DimpelDepth / Diameter;
    private float Altitute => Ball.position.y;
    private float Radius => Diameter / 2F;
    private float Circumference => 2F * Mathf.PI * Radius;
    private float CrossSectionArea => Mathf.PI * Mathf.Sqrt(Radius);

    void Start()
    {
        Ball.useGravity = false;
        Ball.mass = STANDARD_WEIGHT;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    void Launch()
    {

        IGolfer Golfer = new Golfer("Thomas", string.Empty, "Angeland", new DateTime(1994, 1, 16), Gender.Male, 66F, 0.14F, 0.6F);

        IGolfClub GolfClub = new Iron(5, 10F, 10F, 0.2F, 0.1F, 0.1F, 1F, 15F);

        SwingCondition Swing = new SwingCondition(
            "Type I", 60F, 135F, 0F, 120F, 0F,
            0F, 0F, 100F, 0.01F,
            20F, 135F, 0.01F, -50F, 0F);

        string Method = "Solution"; // Simulation method, ["Solution 1", "Solution 2", "Solution 3"]
        float VC = float.NaN; // Clubhead impact velocity (m/sec)
        string error_VC = string.Empty; // Systematic error of clubhead impact velocity (m/sec)
        float VC_angle = float.NaN; // Clubhead impact angle (degree)
        string error_VC_angle = string.Empty; // Systematic error of clubhead impact angle (degree)

        /// 6. Set golf ball parameters
        float COR = 0.775F; // COR
        float dragCoefficient = 0.285F; // Drag coefficient
        float liftCoefficient = 0.1F; // Lift coefficient

        /// 7. Set environmental conditions
        var air = new AirProperties(20F, 0.2F);
        var wind = WindProperties.FromDegrees(20F, 20F, 20F);

        /// 8. Set initial conditions of golf ball
        var ballLaunchSpeed = 50F; // Launch speed (absolute value) (m/sec)
        var ballElevationAngle = Angle.FromDegrees(20F); // Launch elevation angle (degree)
        var ballDirectionAngle = Angle.FromDegrees(10F); // Launch direction angle (degree)
        var ballSpinElevationAngle = Angle.FromDegrees(0F); // Spin elevation angle (degree)
        var ballSpinDirectionAngle = Angle.FromDegrees(-90F); // Spin direction angle (degree)

        var airDensity = air.Density(Ball.position.z);

        Physics.gravity = Vector3.up * -PhysicsKek.Gravity;
        Ball.useGravity = true;
        Ball.velocity = UpdateVelocity(airDensity, STANDARD_WEIGHT, STANDARD_DIAMETER, air, dragCoefficient, liftCoefficient, ballLaunchSpeed, ballElevationAngle, ballDirectionAngle, ballSpinElevationAngle, ballSpinDirectionAngle, wind);
    }

    private static Vector3 UpdateVelocity(float airDensity, float golfballMass, float golfballDiameter, AirProperties air, float dragCoefficient, float liftCoefficient, float ballLaunchSpeed, Angle ballElevation, Angle ballDirection, Angle ballSpinElevation, Angle ballSpinDirection, WindProperties wind)
    {
        // ball velocity vector
        var velocity = new Vector3(
            x: ballLaunchSpeed * Mathf.Cos(ballElevation.Radians) * Mathf.Cos(ballDirection.Radians),
            y: ballLaunchSpeed * Mathf.Cos(ballElevation.Radians) * Mathf.Sin(ballDirection.Radians),
            z: ballLaunchSpeed * Mathf.Sin(ballElevation.Radians));

        // angular unit vector
        var w_unit = new Vector3(
            x: Mathf.Cos(ballSpinElevation.Radians) * Mathf.Cos(ballSpinDirection.Radians),
            y: Mathf.Cos(ballSpinElevation.Radians) * Mathf.Sin(ballSpinDirection.Radians),
            z: Mathf.Sin(ballSpinElevation.Radians));

        var v_wind = wind.Velocity();

        var timeStep = Time.deltaTime;

        var k1 = A(velocity, v_wind, w_unit, dragCoefficient, liftCoefficient, airDensity, golfballMass, golfballDiameter);

        var v_ball_k1 = velocity + k1 * (timeStep / 2F);
        var k2 = A(v_ball_k1, v_wind, w_unit, dragCoefficient, liftCoefficient, airDensity, golfballMass, golfballDiameter);

        var v_ball_k2 = velocity + k2 * (timeStep / 2F);
        var k3 = A(v_ball_k2, v_wind, w_unit, dragCoefficient, liftCoefficient, airDensity, golfballMass, golfballDiameter);

        var v_ball_k3 = velocity + k2 * timeStep;
        var k4 = A(v_ball_k3, v_wind, w_unit, dragCoefficient, liftCoefficient, airDensity, golfballMass, golfballDiameter);

        var nextVBall = new Vector3(
            x: velocity.x + timeStep * (k1.x + 2F * k2.x + 2F * k3.x + k4.x) / 6F,
            y: velocity.y + timeStep * (k1.y + 2F * k2.y + 2F * k3.y + k4.y) / 6F,
            z: velocity.z + timeStep * (k1.z + 2F * k2.z + 2F * k3.z + k4.z) / 6F);

        //var nextPosition = new Vector3(
        //    x: position.x + (velocity.x + nextVBall.x) * timeStep / 2F,
        //    y: position.y + (velocity.y + nextVBall.y) * timeStep / 2F,
        //    z: position.z + (velocity.z + nextVBall.z) * timeStep / 2F);

        return nextVBall;
    }

    private static Vector3 A(Vector3 v_ball, Vector3 v_wind, Vector3 w_unit, float C_D, float C_L, float rho_air, float m, float D)
    {
        var A = (D / 2F).Squared() * Mathf.PI;

        var U = v_ball.Negative() + v_wind;

        var abs_FD = C_D * A * rho_air * (U.x.Squared() + U.y.Squared() + U.z.Squared()) / 2F;
        var abs_FL = C_L * A * rho_air * (U.x.Squared() + U.y.Squared() + U.z.Squared()) / 2F;

        var U_unit = U.Unit();
        var FL_unit = Vector3.Cross(U_unit, w_unit);

        var ansX = abs_FD * U_unit.x + abs_FL * FL_unit.x;
        var ansY = abs_FD * U_unit.y + abs_FL * FL_unit.y;
        var ansZ = abs_FD * U_unit.z + abs_FL * FL_unit.z - m * Physics.gravity.magnitude;

        return new Vector3(ansX / m, ansY / m, ansZ / m);
    }

    /// <summary>
    /// The force put on the golf ball due to its interaction with air molecules, commonly called
    /// aerodynamic drag or air resistance.
    /// </summary>
    /// <param name="air">The current air-properties.</param>
    /// <returns></returns>
    private float DragForce(AirProperties air, WindProperties wind)
    {
        throw new NotImplementedException();
        // https://patentimages.storage.googleapis.com/0e/57/f5/72db85fa024f2c/US20120150502A1.pdf
        // http://www.ijimt.org/papers/419-D0260.pdf
        // https://upcommons.upc.edu/bitstream/handle/2117/105606/soccer_paper_Sept.pdf
        // https://www.slideshare.net/chengchinchiang1/gtsnotephysics THIS IS GOOD

        //// Calculate drag coefficent for dimpel size (diameter)
        //const float A_1 = 0.9295, A_2 = 0.2326;
        //const float B_1 = 0.06474, B_2 = -0.00263;
        //const float R_1 = 1.0, R_2 = 1.0;

        //var C_D_size = (DimpelDiameterRatio < 0.08)
        //    ? R_1 * (-3.125 * DimpelDiameterRatio + 0.25)
        //    : 0;

        //// Calculate drag coefficent for dimpel depth
        //var Y_1 = A_1 * X_1.Squared() + B_1 * X_1;
        //var Y_2 = A_2 * X_2.Squared() + B_2 * X_2;
        //var K_1_depth = Math.Abs(Math.Pow((DimpelDepthRatio - 0.5).Squared(), 0.1) * Math.Sign(DimpelDepthRatio - 0.5));
        //var C_D_depth = R_2 * (Y_1 * K_1_depth + Y_2 * (1.0 - K_1_depth));

        //// calculate final drag coefficient
        //const float C_0 = 0.2136, C_d1 = 0.25, C_d3 = 0.0001;
        //const float Re_crit = 0.6e+5;

        //var airDensity = air.Density(Altitute);
        //var relativeVelocity = wind.GetVelocity(Altitute) - Velocity;

        //var Re = Physics.ReynoldsNumber(Diameter, airDensity, relativeVelocity.Length);
        //var K_1 = Re * C_d3 - Dimpels;
        //var C_d2 = (Re - Re_crit) * C_d3;
        //var K_2 = K_1 - C_d2 - Dimpels;

        //var DRe = (Re < Re_crit)
        //    ? K_1 + K_1 - 1.0
        //    : K_2 + C_d1 * K_2 - 0.0225 * C_d2 - 1.0;

        //var dragCoefficent = C_0 * (-2.1 * Math.Exp(-0.12 * (DRe + CrossSectionArea + 0.35)) + 8.9 * Math.Exp(-0.22 * (DRe + 0.35)));
        //dragCoefficent += C_D_size + C_D_depth;

        //return (1.0 / 2.0) * dragCoefficent * airDensity * CrossSectionArea * relativeVelocity.Length.Squared();
    }

    /// <summary>
    /// The Magnus force lifting the ball is caused by the rotation and the velocity of
    /// the ball. The rotation causes air disturbances perpendicular to the direction
    /// of the angular velocity causing the direction of flight is altered perpendicular
    /// to the linear velocity. This relationship shows that the Magnus force is
    /// calculated using a cross product.
    /// </summary>
    /// <param name="magnusCoefficient"></param>
    /// <returns></returns>
    private float LiftForce(AirProperties air, WindProperties wind)
    {
        var airDensity = air.Density(Altitute);
        var relativeVelocity = Ball.velocity - wind.Velocity();
        var liftCoefficient = LiftCoefficient(Radius, Ball.rotation.eulerAngles.magnitude, relativeVelocity.magnitude);
        return (1F / 2F) * liftCoefficient * airDensity * CrossSectionArea * relativeVelocity.magnitude.Squared();
    }

    private void UpdateSpin(AirProperties air, float altitude)
    {
        throw new NotImplementedException();
        //Rotation = -air.Pressure(Altitute) * CrossSectionArea * 
    }

    //public void Launch(GolferSkillSet skillSet, IGolfClub golfclub, ITerrain terrain, AirProperties air)
    //{
    //    var loftForce = (Mathf.Cos(golfclub.Loft).Squared() * Mathf.Sin(90F - golfclub.Loft));
    //    Velocity = loftForce * (golfclub.HeadMass * golfclub.GetVelocity(skillSet, terrain.Friction) * (1F + Restitution(air))) / (golfclub.HeadMass + Weight);
    //}

    public void Fly(float weightForce, AirProperties air)
    {
        // http://www.ijimt.org/papers/419-D0260.pdf

        throw new NotImplementedException();

        //var airDensity = air.Density(Altitute);

        //// Aerodynamic Resistance Force, F_D, k_D
        //var kd = (1.0 / 2.0) * air.DragCoefficient * airDensity * CrossSectionArea;
        //var dragForce = kd * Velocity.Squared;
        //// Aerodynamic Lift Force, F_M, k_L
        //var liftForce = (1.0 / 2.0) * air.LiftCoefficient * airDensity * CrossSectionArea * (1 / (Rotation.Absolute * Velocity.Absolute));
        //// Aerodynamic resistance moment
        //var dragMoment = (1.0 / 2.0) * air.DragMomentCoefficient * airDensity * CrossSectionArea * (1F / Rotation.Absolute);
    }

    public void BounceAndRoll(ITerrain terrain)
    {
        // http://raypenner.com/golf-run.pdf

        throw new NotImplementedException();

        //if (terrain.Friction < criticalFriction)
        //{
        //    Slide(terrain, restitution, velocityReference);
        //}
        //else
        //{
        //    Roll(terrain, restitution, velocityReference);
        //}
    }

    private static float LiftCoefficient(float radius, float rotationSpeed, float velocitySpeed)
    {
        return -0.05F + Mathf.Sqrt(0.0025F + 0.36F * ((radius * rotationSpeed) / velocitySpeed));
    }

    public static float Restitution(AirProperties air)
    {
        const float minTemperature = 0F;
        const float maxTemperature = 27F;

        return air.Temperature.Remap(minTemperature, maxTemperature, MIN_RESTITUTION, MAX_RESTITUTION);
    }
}