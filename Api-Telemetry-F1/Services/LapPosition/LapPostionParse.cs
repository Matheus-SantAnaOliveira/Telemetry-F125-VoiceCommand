using Api_Telemetry_F1.Common;
using Api_Telemetry_F1.Elastic;
using Api_Telemetry_F1.Models.LapPosition;
using Nest;

namespace Api_Telemetry_F1.Services.LapPosition
{
    public class LapPostionParse
    {
        public static PacketLapPosition ParsePacketLapPositionsData(byte[] data, List<CachedDriversInfo> driversInfos, ElasticClientWrapper elkClient)
        {
            int index = 0;
            PacketLapPosition packet = new PacketLapPosition();
            packet.EventDate = DateTime.UtcNow;

            packet.NumLaps = data[index++];
            packet.LapStart = data[index++];

            const int maxLaps = 50;
            const int maxCars = 22;

            var documentsToIndex = new List<LapPositionDocument>();

            for (int lapIdx = 0; lapIdx < maxLaps && lapIdx < packet.NumLaps; lapIdx++)
            {
                int lapNumber = packet.LapStart + lapIdx;

                for (int vehicleIdx = 0; vehicleIdx < maxCars; vehicleIdx++)
                {
                    byte position = data[index++];

                    if (position == 0) continue;

                    var driver = driversInfos.ElementAtOrDefault(vehicleIdx);

                    var doc = new LapPositionDocument
                    {
                        EventDate = DateTime.UtcNow,
                        LapNumber = lapNumber,
                        VehicleIdx = vehicleIdx,
                        Position = position,
                        DriverName = driver?.DriverName ?? "Unknown",
                        DriverTeam = driver?.DriverTeam ?? "Unknown",
                    };

                    documentsToIndex.Add(doc);
                }
            }

            if (documentsToIndex.Any())
            {
                var bulkDescriptor = new BulkDescriptor();
                foreach (var doc in documentsToIndex)
                {
                    bulkDescriptor.Index<LapPositionDocument>(op => op
                        .Document(doc)
                        .Index("telemetryf1-lappositions-by-driver")
                    );
                }

                var bulkResponse = elkClient.Client.Bulk(bulkDescriptor);
                if (!bulkResponse.IsValid)
                {
                    Console.WriteLine($"Erro no bulk index: {bulkResponse.OriginalException?.Message}");
                }
            }

            return packet;
        }
    }
}