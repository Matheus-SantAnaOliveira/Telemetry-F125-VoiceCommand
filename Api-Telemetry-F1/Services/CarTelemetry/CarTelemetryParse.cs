using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.Models.Header;
using Api_Telemetry_F1.TelemetryUtils;
using Nest;

namespace Api_Telemetry_F1.Models.CarTelemetry
{
    public class CarTelemetryParse
    {
        public static CarTelemetryData ParseSingleCarTelemetry(byte[] data,ref int index, List<CachedDriversInfo> driversInfos, int position)
        {
            var ct = new CarTelemetryData();
            var driver = CachedDriversInfoExtensions.GetDriverByPosition(driversInfos, position);
            if (driver != null)
            {
                ct.DriverName = driver.DriverName;
                ct.DriverTeam = driver.DriverTeam;
            }
            ct.ReceivedAt = DateTime.UtcNow;
            ct.Speed = BitConverter.ToUInt16(data, index); index += 2;
            ct.Throttle = BitConverter.ToSingle(data, index); index += 4;
            ct.Steer = BitConverter.ToSingle(data, index); index += 4;
            ct.Brake = BitConverter.ToSingle(data, index); index += 4;
            ct.Clutch = data[index++];
            ct.Gear = (sbyte)data[index++];
            ct.EngineRPM = BitConverter.ToUInt16(data, index); index += 2;
            ct.Drs = data[index++];
            ct.DrsDesc = TranslateByteType.OnOffValue(ct.Drs);
            ct.RevLightsPercent = data[index++];
            ct.RevLightsBitValue = BitConverter.ToUInt16(data, index); index += 2;
            for (int i = 0; i < 4; i++)
            {
                ct.BrakesTemperature[i] = BitConverter.ToUInt16(data, index);
                index += 2;
            }
            for (int i = 0; i < 4; i++) 
                ct.TyresSurfaceTemperature[i] = data[index++];
            for (int i = 0; i < 4; i++) 
                ct.TyresInnerTemperature[i] = data[index++];
            ct.EngineTemperature = BitConverter.ToUInt16(data, index); index += 2;

            for (int i = 0; i < 4; i++)
            {
                ct.TyresPressure[i] = BitConverter.ToSingle(data, index);
                index += 4;
            }
            for (int i = 0; i < 4; i++) 
                ct.SurfaceType[i] = data[index++];

            return ct;
        }
        public static PacketTelemetryCar ParsePacketCarTelemetryData(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            int index = 0;
            var packet = new PacketTelemetryCar();
            packet.EventDate = DateTime.Now;
            for (int i = 0; i < 22; i++)
            {
                var carTelemetry = ParseSingleCarTelemetry(data,ref index, driversInfos, i);
                elkClient.Client.Index(carTelemetry, req => req.Index("telemetryf1-data-car-telemetry-individual"));
                packet.CarTelemetryData.Add(carTelemetry);
            }

            packet.MfdPanelIndex = data[index++];
            packet.MfdPanelIndexDescription = TranslateByteType.MfdPanel(packet.MfdPanelIndex);
            packet.MfdPanelIndexSecondaryPlayer = data[index++];
            packet.MfdPanelIndexSecondaryPlayerDescription = TranslateByteType.MfdPanel(packet.MfdPanelIndexSecondaryPlayer);
            packet.SuggestedGear = (sbyte)data[index++];

            return packet;
        }
    }
}
