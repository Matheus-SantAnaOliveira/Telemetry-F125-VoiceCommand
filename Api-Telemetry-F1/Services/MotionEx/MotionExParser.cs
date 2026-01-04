using Api_Telemetry_F1.Models.Header;
using Api_Telemetry_F1.Models.MotionEx;

namespace Api_Telemetry_F1.Services.MotionEx
{
    public class MotionExParser
    {
        private static float[] ReadFloatArray4(byte[] data, ref int index)
        {
            float[] array = new float[4];
            array[0] = BitConverter.ToSingle(data, index); index += 4;
            array[1] = BitConverter.ToSingle(data, index); index += 4;
            array[2] = BitConverter.ToSingle(data, index); index += 4;
            array[3] = BitConverter.ToSingle(data, index); index += 4;
            return array;
        }

        public static PacketMotionEx ParseMotionEx(byte[] data)
        {
            int index = 0;
            var packet = new PacketMotionEx();

            packet.SuspensionPosition = ReadFloatArray4(data, ref index);
            packet.SuspensionVelocity = ReadFloatArray4(data, ref index);
            packet.SuspensionAcceleration = ReadFloatArray4(data, ref index);
            packet.WheelSpeed = ReadFloatArray4(data, ref index);
            packet.WheelSlipRatio = ReadFloatArray4(data, ref index);
            packet.WheelSlipAngle = ReadFloatArray4(data, ref index);
            packet.WheelLatForce = ReadFloatArray4(data, ref index);
            packet.WheelLongForce = ReadFloatArray4(data, ref index);

            packet.HeightOfCOGAboveGround = BitConverter.ToSingle(data, index); index += 4;
            packet.LocalVelocityX = BitConverter.ToSingle(data, index); index += 4;
            packet.LocalVelocityY = BitConverter.ToSingle(data, index); index += 4;
            packet.LocalVelocityZ = BitConverter.ToSingle(data, index); index += 4;
            packet.AngularVelocityX = BitConverter.ToSingle(data, index); index += 4;
            packet.AngularVelocityY = BitConverter.ToSingle(data, index); index += 4;
            packet.AngularVelocityZ = BitConverter.ToSingle(data, index); index += 4;
            packet.AngularAccelerationX = BitConverter.ToSingle(data, index); index += 4;
            packet.AngularAccelerationY = BitConverter.ToSingle(data, index); index += 4;
            packet.AngularAccelerationZ = BitConverter.ToSingle(data, index); index += 4;
            packet.FrontWheelsAngle = BitConverter.ToSingle(data, index); index += 4;

            packet.WheelVertForce = ReadFloatArray4(data, ref index);
            packet.FrontAeroHeight = BitConverter.ToSingle(data, index); index += 4;
            packet.RearAeroHeight = BitConverter.ToSingle(data, index); index += 4;
            packet.FrontRollAngle = BitConverter.ToSingle(data, index); index += 4;
            packet.RearRollAngle = BitConverter.ToSingle(data, index); index += 4;
            packet.ChassisYaw = BitConverter.ToSingle(data, index); index += 4;
            packet.ChassisPitch = BitConverter.ToSingle(data, index); index += 4;

            packet.WheelCamber = ReadFloatArray4(data, ref index);
            packet.WheelCamberGain = ReadFloatArray4(data, ref index);

            return packet;
        }
    }
}